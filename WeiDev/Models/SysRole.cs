using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YEF.Models
{
    public  class SysRole
    {
        public int SysRoleID { get; set; }

        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        [Display(Name = "角色描述")]
        public string RoleDescribe { get; set; }

        [Display(Name = "角色权限")]
        public string RoleAuthority { get; set; }
    }
}
