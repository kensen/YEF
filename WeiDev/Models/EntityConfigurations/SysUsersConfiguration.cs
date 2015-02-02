using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models.EntityConfigurations
{
    public class SysUsersConfiguration:EntityConfigurationBase<SysUsers,Guid>
    {
        public SysUsersConfiguration()
        {
            HasOptional(m => m.SysRoles).WithMany(n => n.SysUsers);
            HasOptional(m => m.SysOrganizations).WithMany(n => n.SysUsers);
        }
    }
}
