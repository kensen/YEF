using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using YEF.Models;
using YEF.Utility;

namespace YEF.Repositories
{
   
        public class WeiDevDBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeiDevContext>
        {
            protected override void Seed(WeiDevContext context)
            {
                var sysRoles = new List<SysRoles>
                {
                new SysRoles{ RoleName="系统管理员", RoleDescribe="系统管理员",RoleAuthority=""}
          
                };
                sysRoles.ForEach(s => context.SysRoles.Add(s));
                context.SaveChanges();
                var sysUsers = new List<SysUsers>
                {
                new SysUsers{ UserName="Admin",LoginID="Admin",Password=MD5Class.GetMd5("123456"), ADPassword=MD5Class.GetMd5("123456"),  IsSPAdmin=true, Id=Guid.NewGuid()}
          
                };

                sysUsers.ForEach(s => context.SysUsers.Add(s));
                context.SaveChanges();
              
            
            }
        }
    
}
