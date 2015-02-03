using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.AppServices.ViewModels
{
   public class OrganizationDto:IAddDto,IEditDto<int>
    {
       public int Id { get; set; }

       [Display(Name = "组织名称")]
       [Required, StringLength(200)]
       public string Name { get; set; }

       [Display(Name = "组织描述")]
       public string Describe { get; set; }

    }
}
