using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.AppServices.ViewModels
{
    public  class RoleDto:IAddDto,IEditDto<int>
    {
        public int Id { get; set; }

        [Display(Name = "角色名称")]
        [Required, StringLength(200)]
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
        public string RoleAuthority { get; set; }
    }
}
