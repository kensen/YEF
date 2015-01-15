using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Models
{
    public class SysUser
    {
        public int SysUserID { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name="账号")]
        public string LoginID { get; set; }

        [Display(Name = "密码")]       
        public string Password { get; set; }

        [Display(Name = "管理员密码")]
        public string ADPasswor { get; set; }

        [Display(Name = "用户类型")]
        public byte UserType { get; set; }

        [Display(Name = "超级管理员")]
        public bool IsSPAdmin { get; set; }

        [Display(Name = "角色ID")]
        public int  SysRoleID {get;set;}
        public virtual SysRole SysRole {get; set;}
    }
}
