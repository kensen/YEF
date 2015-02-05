using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;


namespace YEF.Models
{
    public enum UserTypeEnum : byte
    {
        Admin = 0,
        User = 1
    }
    public class SysUsers:EntityBase<Guid>
    {
        public SysUsers()
        {
            this.IsSPAdmin = false;            
            this.UserType = UserTypeEnum.User;
        }
        [Display(Name = "用户名")]
        [Required,StringLength(50)]
        public string UserName { get; set; }

        [Display(Name = "登录ID")]
        [Required,StringLength(50)]
        public string LoginID { get; set; }

        [Display(Name = "密码")]
        [Required,StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "后台密码")]
        [Required,StringLength(50)]
        public string ADPassword { get; set; }

        [Required]
        public UserTypeEnum UserType { get; set; }

        [Display(Name = "是否是超级管理员")]
        public bool IsSPAdmin { get; set; }

        public virtual SysOrganizations SysOrganizations { get; set; }
        public virtual SysRoles SysRoles { get; set; }
    }
}
