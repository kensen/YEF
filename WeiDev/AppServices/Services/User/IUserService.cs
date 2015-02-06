using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YEF.AppServices.ViewModels;
using YEF.Infrastructure;
using YEF.Infrastructure.Data;
using YEF.Models;
using YEF.Utility.Msgs;

namespace YEF.AppServices.Services.User
{
    public interface IUserService:IDependency
    {  /// <summary>
        /// 获取 用户信息查询数据集
        /// </summary>
        IQueryable<YEFUser> Users { get; }

        AccountDto LoginUser { get; set; }

        /// <summary>
        /// 检查用户信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的用户信息编号</param>
        /// <returns>用户信息是否存在</returns>
        bool CheckUserExists(Expression<Func<YEFUser, bool>> predicate, Guid? id = null );

        /// <summary>
        /// 添加用户信息信息
        /// </summary>
        /// <param name="dtos">要添加的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddUsers(params UserDto[] dtos);

        /// <summary>
        /// 更新用户信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditUsers(params UserDto[] dtos);

        /// <summary>
        /// 删除用户信息信息
        /// </summary>
        /// <param name="ids">要删除的用户信息编号</param>
        /// <returns>业务操作结果</returns>
        OperationResult DeleteUsers(params Guid[] ids);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Login(AccountDto dto);

        bool logout();

       // AccountDto GetLoginUser()
        
    }
}
