using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;
using YEF.Models;



namespace YEF.AppServices.ViewModels
{
    public class AccountDto:IAddDto,IEditDto<Guid>
    {
        public Guid Id { get; set; }

        public string LoginID { get; set; }

        [Display("密码")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display("后台密码")]
        [StringLength(50)]
        public string ADPassword { get; set; }

        [Required]
        public UserTypeEnum UserType { get; set; }

        [Display("是否是超级管理员")]
        public bool IsSPAdmin { get; set; }

        //public virtual SysOrganizations SysOrganizations { get; set; }
        //public virtual SysRoles SysRoles { get; set; }

        [ StringLength(200)]
        public string RoleName { get; set; }
        
        public string RoleAuthority { get; set; }

    }
}
