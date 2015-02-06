using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Repositories.Migrations
{
    /// <summary>
    /// 初始化数据库，没有数据库的时候创建。
    /// </summary>
    public class CreateNewDataBase:CreateDatabaseIfNotExists<YEFDbContext>
    {
        public static ICollection<ISeedAction> SeedActions { get; private set; }

        static CreateNewDataBase()
        {
            SeedActions=new List<ISeedAction>();     
        }

        protected override void Seed(YEFDbContext context)
        {
            IEnumerable<ISeedAction> seedActions = SeedActions.OrderBy(m => m.Order);
            foreach(ISeedAction sendaction in seedActions)
            {
                sendaction.Action(context);
            }
         // base.Seed(context);
        }

    }
}
