using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Repositories.Migrations
{
    /// <summary>
    /// 数据迁移初始化数据操作接口
    /// </summary>
    public interface ISeedAction
    {
        /// <summary>
        /// 获取操作顺序，数值越小越先执行
        /// </summary>
        int Order { get; }

        /// <summary>
        /// 定义数据初始化过程
        /// </summary>
        /// <param name="context"></param>
        void Action(YEFDbContext context);
    }
}
