﻿using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Overt.Core.Grpc
{
    /// <summary>
    /// Endpoint 策略工厂
    /// </summary>
    internal class StrategyFactory
    {
        private readonly static object _lockHelper = new object();
        private readonly static ConcurrentDictionary<Type, Exitus> _exitusMap = new ConcurrentDictionary<Type, Exitus>();

        /// <summary>
        /// 获取EndpointStrategy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Exitus Get<T>(GrpcClientOptions options) where T : ClientBase
        {
            if (_exitusMap.TryGetValue(typeof(T), out Exitus exitus) &&
                exitus?.EndpointStrategy != null)
                return exitus;

            lock (_lockHelper)
            {
                if (_exitusMap.TryGetValue(typeof(T), out exitus) &&
                    exitus?.EndpointStrategy != null)
                    return exitus;

                exitus = ResolveConfiguration(options);
                _exitusMap.AddOrUpdate(typeof(T), exitus, (k, v) => exitus);
                return exitus;
            }
        }

        #region Private Method
        /// <summary>
        /// 解析配置文件
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        private static Exitus ResolveConfiguration(GrpcClientOptions options)
        {
            var service = ResolveServiceConfiguration(options.ConfigPath);
            if (string.IsNullOrWhiteSpace(options.ServiceName))
                options.ServiceName = service.Name;
            if (options.MaxRetry <= 0)
                options.MaxRetry = service.MaxRetry;
            options.ChannelOptions = options.ChannelOptions ?? GrpcConstants.DefaultChannelOptions;

            IEndpointStrategy endpointStrategy;
            if (EnableConsul(service.Discovery, out ConsulServiceElement consulOption))
                endpointStrategy = ResolveStickyConfiguration(consulOption, options);
            else
                endpointStrategy = ResolveEndpointConfiguration(service, options);
            return new Exitus(options.ServiceName, endpointStrategy);
        }

        /// <summary>
        /// 解析服务配置
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        private static Client.GrpcServiceElement ResolveServiceConfiguration(string configFile)
        {
            var grpcSection = ConfigBuilder.Build<GrpcClientSection>(GrpcConstants.GrpcClientSectionName, configFile);
            if (grpcSection == null || grpcSection.Service == null)
                throw new ArgumentNullException($"service config error");

            return grpcSection.Service;
        }

        /// <summary>
        /// 解析Consul配置
        /// </summary>
        /// <param name="serviceElement"></param>
        /// <returns></returns>
        private static IEndpointStrategy ResolveStickyConfiguration(ConsulServiceElement consulOption, GrpcClientOptions options)
        {
            // consul
            var stickyEndpointDiscovery = new StickyEndpointDiscovery(options, consulOption);
            EndpointStrategy.Instance.AddServiceDiscovery(stickyEndpointDiscovery);
            return EndpointStrategy.Instance;
        }

        /// <summary>
        /// 解析Endpoint配置
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        private static IEndpointStrategy ResolveEndpointConfiguration(Client.GrpcServiceElement service, GrpcClientOptions options)
        {
            var discovery = service.Discovery;

            List<Tuple<string, int>> ipEndPoints = null;
#if !ASP_NET_CORE
            ipEndPoints = discovery.EndPoints.ToList();
#else
            ipEndPoints = discovery.EndPoints.Select(oo => Tuple.Create(oo.Host, oo.Port)).ToList();
#endif
            var iPEndpointDiscovery = new IPEndpointDiscovery(options, ipEndPoints);
            EndpointStrategy.Instance.AddServiceDiscovery(iPEndpointDiscovery);
            return EndpointStrategy.Instance;
        }

        /// <summary>
        /// 是否是使用Consul
        /// </summary>
        /// <param name="discovery"></param>
        /// <returns></returns>
        private static bool EnableConsul(GrpcDiscoveryElement discovery, out ConsulServiceElement consulOption)
        {
            consulOption = new ConsulServiceElement();
            var configPath = discovery?.Consul?.Path;
            if (string.IsNullOrEmpty(configPath))
                return false;

            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, discovery.Consul.Path)))
                throw new Exception($"[{discovery.Consul.Path}] not exist at [{AppDomain.CurrentDomain.BaseDirectory}]");

            var consulSection = ConfigBuilder.Build<ConsulServerSection>(GrpcConstants.ConsulServerSectionName, configPath);
            if (string.IsNullOrEmpty(consulSection?.Service?.Address))
                return false;

            consulOption = consulSection.Service;

            return true;
        }
        #endregion
    }
}
