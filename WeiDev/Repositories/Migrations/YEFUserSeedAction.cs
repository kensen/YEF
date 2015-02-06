using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YEF.Repositories;
using YEF.Models;
using YEF.Infrastructure.Data;
using YEF.Utility;

namespace YEF.Repositories.Migrations
{
   internal class YEFUserSeedAction:ISeedAction
    {
        public int Order
        {
            get { return 3; }
        }

        public void Action(YEFDbContext context)
        {
            IRepository<YEFUser, Guid> _userRepository = new Repository<YEFUser, Guid>(context);

            var organization = new List<YEFUser>
                {
                  new YEFUser{ UserName="admin",LoginID="admin",
                      UserType=UserTypeEnum.Admin,IsSPAdmin=true,
                      Password=MD5Class.GetMd5("123456"),
                      ADPassword=MD5Class.GetMd5("123456")}
                 
                };
            context.TransactionEnabled = true;
            organization.ForEach(s => _userRepository.Insert(s));
            context.SaveChanges();
            context.TransactionEnabled = false;
        }
    }
}
