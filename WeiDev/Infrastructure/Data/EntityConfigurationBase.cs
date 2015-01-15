using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Infrastructure.Data
{
    /// <summary>
    /// 数据实体映射配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TKey">主键</typeparam>
    public abstract class EntityConfigurationBase<TEntity,TKey>:EntityTypeConfiguration<TEntity>,IEntityMapper 
        where TEntity :EntityBase<TKey>
    {
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
