using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YEF.Repositories;
using YEF.Models;
using YEF.Infrastructure.Data;
namespace YEF.Repositories.Migrations
{
    internal class YEFRoleSeedAction:ISeedAction
    {
        public int Order
        {
            get { return 2; }
        }

        public void Action(YEFDbContext context)
        {
            IRepository<YEFRole, int> _roleRepository = new Repository<YEFRole, int>(context);

            var organization = new List<YEFRole>
                {
                  new YEFRole{ RoleName="管理员",RoleDescribe="管理员"},
                   new YEFRole{ RoleName="用户",RoleDescribe="用户"}
                 
                };
            context.TransactionEnabled = true;
            organization.ForEach(s => _roleRepository.Insert(s));
            context.SaveChanges();
            context.TransactionEnabled = false;
        }
    }
}
