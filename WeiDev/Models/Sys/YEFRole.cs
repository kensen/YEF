using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models
{
    public class YEFRole : EntityBase<int>
    {
        public YEFRole()
        {
            this.YEFUsers = new HashSet<YEFUser>();
        }

        [Display(Name = "角色名称")]
        [Required, StringLength(200)]
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
        public string RoleAuthority { get; set; }

        public virtual YEFOrganization YEFOrganization { get; set; }
        public virtual ICollection<YEFUser> YEFUsers { get; set; }
    }
}
