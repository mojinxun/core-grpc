﻿using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Overt.Core.Grpc
{
    /// <summary>
    /// 注册中心服务发现
    /// </summary>
    internal sealed class StickyEndpointDiscovery : IEndpointDiscovery
    {
        #region 构造函数
        private readonly ConsulClient _client;
        public StickyEndpointDiscovery(GrpcClientOptions options, ConsulServiceElement consulOption, bool startWatch = true)
        {
            if (string.IsNullOrEmpty(consulOption?.Address))
                throw new ArgumentNullException("consul address");

            _client = new ConsulClient((cfg) =>
            {
                var uriBuilder = new UriBuilder(consulOption.Address);

                cfg.Address = uriBuilder.Uri;
                cfg.Token = consulOption.Token;
            });

            Options = options;

            if (startWatch)
                StartWatchService();
        }
        #endregion

        #region Public Property
        public GrpcClientOptions Options { get; set; }

        public Action Watched { get; set; }
        #endregion

        #region Public Method
        public List<Tuple<string, string>> FindServiceEndpoints(bool filterBlack = true)
        {
            if (_client == null)
                throw new ArgumentNullException("consul client");

            var targets = new List<Tuple<string, string>>();
            try
            {
                var r = _client.Health.Service(Options.ServiceName, "", true).Result;
                if (r.StatusCode != HttpStatusCode.OK)
                    throw new ApplicationException($"failed to query consul server");

                targets = r.Response
                           .Select(x => Tuple.Create(x.Service.ID, $"{x.Service.Address}:{x.Service.Port}"))
                           .Where(target => !ServiceBlackPolicy.In(Options.ServiceName, target.Item2) || !filterBlack)
                           .ToList();
            }
            catch { }
            return targets;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 开始监听服务变动
        /// </summary>
        private void StartWatchService()
        {
            Task.Factory.StartNew(async () =>
            {
                ulong lastWaitIndex = 0;
                do
                {
                    try
                    {
                        var serviceQueryResult = await _client.Catalog.Service(Options.ServiceName, "", new QueryOptions()
                        {
                            WaitTime = TimeSpan.FromSeconds(30),
                            WaitIndex = lastWaitIndex
                        });
                        var waitIndex = serviceQueryResult.LastIndex;
                        if (lastWaitIndex <= 0)
                        {
                            lastWaitIndex = waitIndex;
                            continue;
                        }
                        if (waitIndex == lastWaitIndex)
                            continue;

                        // 重置服务
                        lastWaitIndex = waitIndex;
                        if (Watched != null)
                            Watched.Invoke();
                    }
                    catch { }

                } while (true);
            });
        }
        #endregion
    }
}