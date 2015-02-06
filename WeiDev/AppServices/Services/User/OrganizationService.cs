using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class OrganizationService:ServiceBase, IOrganizationService
    {
        private readonly IRepository<YEFOrganization, int> _organizationRepository;

        public OrganizationService(IRepository<YEFOrganization, int> organizationRepository )
            : base(organizationRepository.UnitOfWork)
        {
            this._organizationRepository = organizationRepository;
        }

        public IQueryable<YEFOrganization> Organizations
        {
           get {return _organizationRepository.Entities;}
        }

        public bool CheckOrganizationExists(Expression<Func<YEFOrganization, bool>> predicate, int id = 0)
        {
           return  _organizationRepository.ExistsCheck(predicate,id);
        }

        public OperationResult AddOrganizations(params OrganizationDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            List<YEFOrganization>orglist=new List<YEFOrganization>();

            OperationResult result=_organizationRepository.Insert(dtos,
                dto=>
                    {
                        if(_organizationRepository.ExistsCheck(m=>m.Name ==dto.Name))
                        {
                            throw new Exception("组织机构名称“{0}”已存在，不能重复添加。".FormatWith(dto.Name));
                        }
                    }
                );

            // if (result.ResultType == OperationResultType.Success)
            //{
            //    int[] ids = orglist.Select(m => m.Id).ToArray();
            //    RefreshOrganizationsTreePath(ids);
            //}
            return result;

           
        }

        public OperationResult EditOrganizations(params OrganizationDto[] dtos)
        {
             dtos.CheckNotNull("dtos");
            List<YEFOrganization>orglist=new List<YEFOrganization>();

            OperationResult result=_organizationRepository.Update(dtos,
                dto=>
                    {
                        if(_organizationRepository.ExistsCheck(m=>m.Name ==dto.Name,dto.Id))
                        {
                            throw new Exception("组织机构名称“{0}”已存在，不能重复添加。".FormatWith(dto.Name));
                        }
                    }
                );

            return result;

        }

        public OperationResult DeleteOrganizations(params int[] ids)
        {
           ids.CheckNotNull("ids");
            OperationResult result = _organizationRepository.Delete(ids);
                //entity =>
                //{
                //    if (entity.Children.Any())
                //    {
                //        throw new Exception("组织机构“{0}”的子级不为空，不能删除。".FormatWith(entity.Name));
                //    }
                //});
            return result;
        }
    }
}
