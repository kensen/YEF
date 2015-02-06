using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure;
using YEF.Infrastructure.Data;
using YEF.AppServices.ViewModels;
using YEF.Models;
using YEF.Utility.Msgs;

namespace YEF.AppServices.Services.User
{
   public interface IRoleService:IDependency
    {
       IQueryable<SysRoles> Role { get; }

      // bool CheckRoleEx(Expression<Func<SysRoles, bool>> predicate, int id = 0);

       OperationResult AddRoles(params RoleDto[] dtos);

       OperationResult EditRoles(params RoleDto[] dtos);

       OperationResult DeleteRoles(params int[] ids);

    }
}
