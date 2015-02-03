using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YEF.Models;

namespace YEF.AppServices.ViewModels
{
    public class DtoMappers
    {
        public static void MapperRegister()
        {
            //Identity
            Mapper.CreateMap<OrganizationDto, SysOrganizations>();
            Mapper.CreateMap<UserDto, SysUsers>();
            Mapper.CreateMap<AccountDto, SysUsers>();
            Mapper.CreateMap<RoleDto, SysRoles>();
        }
    }
}
