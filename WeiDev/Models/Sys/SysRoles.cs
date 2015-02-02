using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models
{
   public class SysRoles:EntityBase<int>
    {
        public SysRoles()
        {
            this.SysUsers = new HashSet<SysUsers>();
        }

       [Display("角色名称")]
       [Required ,StringLength(200)]
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
        public string RoleAuthority { get; set; }

        public virtual SysOrganizations SysOrganizations { get; set; }
        public virtual ICollection<SysUsers> SysUsers { get; set; }
    }
}
