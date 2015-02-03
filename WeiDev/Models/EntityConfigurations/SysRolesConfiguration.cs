using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models.EntityConfigurations
{
   public  class SysRolesConfiguration:EntityConfigurationBase<SysRoles,int>
    {
       public SysRolesConfiguration()
       {
           HasOptional(m=>m.SysOrganizations).WithMany(n=>n.SysRoles);
       }
    }
}
