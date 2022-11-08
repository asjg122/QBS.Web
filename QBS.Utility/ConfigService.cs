﻿namespace QBS.Utility
{
    /// <summary>
    /// 配置服务
    /// </summary>
    public class ConfigService
    {
        private Microsoft.Extensions.Configuration.IConfiguration m_Configuration;

        public ConfigService(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            m_Configuration = configuration;
        }

        /// <summary>
        /// 读取 appsettings.json中的配置文件
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return m_Configuration["ConnectionStrings:QBSDB"];
        }
    }
}