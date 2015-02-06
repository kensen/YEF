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
    internal class YEFOrganizationsSeedAction : ISeedAction
    {
        public int Order
        {
            get { return 1; }
        }

        public void Action(YEFDbContext context)
        {
            IRepository<YEFOrganization, int> _organizationRepository = new Repository<YEFOrganization, int>(context);
           
            var organization = new List<YEFOrganization>
                {
                  new YEFOrganization{Name="YEF",Describe="YEF"}                
                };
            context.TransactionEnabled=true;
            organization.ForEach(s => _organizationRepository.Insert(s));
            context.SaveChanges();
             context.TransactionEnabled=false;

        }
       
    }
}
