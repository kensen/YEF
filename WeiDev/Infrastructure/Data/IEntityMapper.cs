using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Infrastructure.Data
{
    public interface IEntityMapper
    {
        /// <summary>
        /// 将实体映射配置注册到当前数据上下文中
        /// </summary>
        /// <param name="configurations">实体映射配置</param>
        void RegistTo(ConfigurationRegistrar configurations);
    }
}
