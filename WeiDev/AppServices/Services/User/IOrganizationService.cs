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
    public interface IOrganizationService : IDependency
    {
        IQueryable<YEFOrganization> Organizations { get; }

        bool CheckOrganizationExists(Expression<Func<YEFOrganization, bool>> predicate, int id = 0);

        /// <summary>
        /// 添加组织机构信息信息
        /// </summary>
        /// <param name="dtos">要添加的组织机构信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddOrganizations(params OrganizationDto[] dtos);

        /// <summary>
        /// 更新组织机构信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的组织机构信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditOrganizations(params OrganizationDto[] dtos);

        /// <summary>
        /// 删除组织机构信息信息
        /// </summary>
        /// <param name="ids">要删除的组织机构信息编号</param>
        /// <returns>业务操作结果</returns>
        OperationResult DeleteOrganizations(params int[] ids);
    }
}
