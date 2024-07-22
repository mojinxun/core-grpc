﻿#if !ASP_NET_CORE
using System.Configuration;
#endif

namespace Overt.Core.Grpc
{
    /// <summary>
    /// Consul
    /// </summary>
    public class ConsulElement
#if !ASP_NET_CORE
        : ConfigurationElement
#endif
    {
        /// <summary>
        /// 服务地址
        /// </summary>
#if !ASP_NET_CORE
        [ConfigurationProperty("path", IsRequired = false)]
#endif
        public string Path
        {
#if !ASP_NET_CORE
            get { return (string)this["path"]; }
#else
        get; set;
#endif
        }
    }
}
