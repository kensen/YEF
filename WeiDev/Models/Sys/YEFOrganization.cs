using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models
{
    public class YEFOrganization : EntityBase<int>
    {
        public YEFOrganization()
        {
            this.YEFUsers = new HashSet<YEFUser>();
            this.YEFRoles = new HashSet<YEFRole>();
        }

        [Display(Name = "组织名称")]
        [Required, StringLength(200)]
        public string Name { get; set; }

        [Display(Name = "组织描述")]
        public string Describe { get; set; }

        public virtual ICollection<YEFUser> YEFUsers { get; set; }
        public virtual ICollection<YEFRole> YEFRoles { get; set; }
    }
}
