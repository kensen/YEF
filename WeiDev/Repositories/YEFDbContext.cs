using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

using YEF.Infrastructure;
using YEF.Infrastructure.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace YEF.Repositories
{
    public class YEFDbContext : DbContext,IUnitOfWork, IDependency
    {

       public YEFDbContext()
           :base(GetConnectionStringName())
       { }

       //public YEFDbContext(string connectionString )
       //    : base(connectionString)
       //{ }

       public bool TransactionEnabled
       {
           get;
           set;
       }


       private static string GetConnectionStringName()
       {
           string name = ConfigurationManager.AppSettings.Get("ConnectionStringName") ?? "default";
           return name;
       }


        /// <summary>
       /// 重写 DbContext  SaveChanges
        /// </summary>
        /// <returns></returns>
       public override int  SaveChanges()
       {
           return SaveChanges(true);
       }

        /// <summary>
       /// 扩展 DbContext 的数据保存方法
        /// </summary>
        /// <param name="validateOnSaveEnabled">是否开启数据校验</param>
        /// <returns></returns>
       internal int SaveChanges(bool validateOnSaveEnabled)
       {
           bool isReturn = Configuration.ValidateOnSaveEnabled != validateOnSaveEnabled;
           try
           {
               Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;

               int count = base.SaveChanges(); 
               if (count > 0)
               {
                   //TODO 写入日志
               }
               TransactionEnabled = false;
               return count;
           }
           catch(DbUpdateException e)
           {
               if(e.InnerException !=null && e.InnerException.InnerException is SqlException)
               {
                   SqlException sqlEx = e.InnerException.InnerException as SqlException;
                   string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                   throw new Exception("提交数据更新时发生异常：" + msg, sqlEx);
               }
               throw;
           }
           finally
           {
               if (isReturn)
               {
                   Configuration.ValidateOnSaveEnabled = !validateOnSaveEnabled;
               }
           }
       }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           //移除一对多的级联删除
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

           //注册实体配置信息
           ICollection<IEntityMapper> entityMappers = DatabaseInitializer.EntityMappers;
           foreach (IEntityMapper mapper in entityMappers)
           {
               mapper.RegistTo(modelBuilder.Configurations);
           }
       }
    }
}
