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
   public class UserDto:IAddDto,IEditDto<Guid>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public Guid Id { get; set; }

        [Display(Name = "用户名")]
        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Display(Name = "登录ID")]
        [Required, StringLength(50)]
        public string LoginID { get; set; }
       

        [Required]
        public UserTypeEnum UserType { get; set; }

        [Display(Name = "是否是超级管理员")]
        public bool IsSPAdmin { get; set; }
    }
}
