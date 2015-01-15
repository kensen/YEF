using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Infrastructure
{
   public class PageConfig
    {
       public int PageSize{get;set;}

       public int PageIndex { get; set; }

       public int PageTotal { get; set; }

       public SortConfig[] SortConfigs { get; set; }

       public PageConfig()
       {
           PageIndex = 1;
           PageSize = 20;
           SortConfigs = new SortConfig[] { };
       }

       public PageConfig(int pageSize,int pageIndex):this()
       {
           PageSize = pageSize;
           PageIndex = pageIndex;
       }
    }
}
