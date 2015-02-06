using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models.EntityConfigurations
{
   public  class YEFRoleConfiguration:EntityConfigurationBase<YEFRole,int>
    {
       public YEFRoleConfiguration()
       {
           HasOptional(m=>m.YEFOrganization).WithMany(n=>n.YEFRoles);
       }
    }
}
