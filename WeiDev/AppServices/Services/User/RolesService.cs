using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.AppServices.ViewModels;
using YEF.Models;
using YEF.Repositories;
using YEF.Utility;
using YEF.Utility.Extensions;
using YEF.Utility.Msgs;
using YEF.Infrastructure;
using YEF.Infrastructure.Data;


namespace YEF.AppServices.Services.User
{
    public class RolesService:ServiceBase, IRoleService
    {
         private readonly IRepository<SysRoles, int> _rolesRepository;

        public RolesService(IRepository<SysRoles,int> rolesRepository)
            :base(rolesRepository.UnitOfWork)
        {
            this._rolesRepository=rolesRepository;
        }
        public IQueryable<SysRoles> Role
        {
	        get{return _rolesRepository.Entities;}
        }

        public OperationResult AddRoles(params RoleDto[] dtos)
        {
 	       dtos.CheckNotNullOrEmpty("dtos");
            return _rolesRepository.Insert(dtos);
        }

        public OperationResult EditRoles(params RoleDto[] dtos)
        {
 	       dtos.CheckNotNullOrEmpty("dtos");
            return _rolesRepository.Update(dtos);
        }

        public OperationResult DeleteRoles(params int[] ids)
        {
 	         ids.CheckNotNull("ids");
             OperationResult result = _rolesRepository.Delete(ids);

            return result;
        }
    }
}
