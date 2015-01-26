using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.AppServices.ViewModels;

namespace YEF.AppServices.Services.System
{
    public interface IStaticOption
    {
        List<StaticOptionModel> GetItemList(string pid = "");
        string GetItemText(string pid = "", string itemval = "");
    }
}
