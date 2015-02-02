using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models
{
   public class SysOrganizations:EntityBase<int>
    {
        public SysOrganizations()
        {
            this.SysUsers = new HashSet<SysUsers>();
            this.SysRoles = new HashSet<SysRoles>();
        }

       [Display("组织名称")]
       [Required,StringLength(200)]
        public string Name { get; set; }

       [Display("组织描述")]
        public string Describe { get; set; }

        public virtual ICollection<SysUsers> SysUsers { get; set; }
        public virtual ICollection<SysRoles> SysRoles { get; set; }
    }
}
