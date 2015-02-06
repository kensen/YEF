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
using System.Linq.Expressions;

namespace YEF.AppServices.Services.User
{
   public class UsersService:IUserService
    {

       private readonly IRepository<YEFUser,Guid> _userRepository;

       public UsersService(IRepository<YEFUser,Guid> userRepository)
       {
           this._userRepository=userRepository;
       }

        public IQueryable<YEFUser> Users
        {
            get { return _userRepository.Entities; }
        }

        public AccountDto LoginUser
        {
	          get 
	        { 
		        throw new NotImplementedException(); 
	        }
	          set 
	        { 
		        throw new NotImplementedException(); 
	        }
        }

        public bool CheckUserExists(Expression<Func<YEFUser,bool>> predicate, Guid? id =null)
        {
 	       return  _userRepository.ExistsCheck(predicate,id.Value);
        }

        public OperationResult AddUsers(params UserDto[] dtos)
        {
 	        dtos.CheckNotNullOrEmpty("dtos");
            List<YEFUser> users=new List<YEFUser>();

             OperationResult result=_userRepository.Insert(dtos,
                dto=>
                    {
                        if(_userRepository.ExistsCheck(m=>m.LoginID ==dto.LoginID))
                        {
                            throw new Exception("登录账号“{0}”已存在，不能重复添加。".FormatWith(dto.LoginID));
                        }
                      
                    },
                (dto,entity)=>
                    {
                        // if (dto.ParentId.HasValue && dto.ParentId.Value > 0)
                        //{
                        //    Organization parent = _organizationRepository.GetByKey(dto.ParentId.Value);
                        //    if (parent == null)
                        //    {
                        //        throw new Exception("指定父组织机构不存在。");
                        //    }
                        //    entity.Parent = parent;
                        //}
                        //organizations.Add(entity);
                        entity.Password=MD5Class.GetMd5("123456");
                        entity.ADPassword=MD5Class.GetMd5("123456");
                        users.Add(entity);
                        return entity;
                    }
                );

            return result;

        }

        public OperationResult EditUsers(params UserDto[] dtos)
        {
 	        dtos.CheckNotNullOrEmpty("dtos");

             OperationResult result=_userRepository.Insert(dtos,
                dto=>
                    {
                        if(_userRepository.ExistsCheck(m=>m.LoginID ==dto.LoginID,dto.Id))
                        {
                            throw new Exception("登录账号“{0}”已存在，不能重复添加。".FormatWith(dto.LoginID));
                        }
                      
                    });
            return result;
        }

        public OperationResult DeleteUsers(params Guid[] ids)
        {
 	        ids.CheckNotNull("ids");
            return _userRepository.Delete(ids);

        }

        public bool Login(AccountDto dto)
        {
 	        throw new NotImplementedException();
        }

        public bool logout()
        {
 	        throw new NotImplementedException();
        }
    }
}
