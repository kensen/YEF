using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using YEF.Infrastructure;
using YEF.Utility;
using YEF.Utility.Extensions;
using YEF.Utility.Data;
using YEF.AppServices.ViewModels;
using System.Web;

namespace YEF.AppServices.Services.System
{
   public  class StaticOptionService:XmlBase,IStaticOption,IDependency
    {

       public StaticOptionService()
       {
         //  string pathstr = ;
           string path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings.Get("StaticOptions"));
          
           SetXML(path);
       }

       /// <summary>
       /// 根据父ID获取对应的选项列表
       /// </summary>
       /// <param name="pid"></param>
       /// <returns></returns>
        public List<StaticOptionModel> GetItemList(string pid = "")
        {
            XmlQueryParm xq = new XmlQueryParm();
            xq.strNode = "item";
            xq.pstrAtt = new Dictionary<string, string>();
            xq.pstrAtt.Add("name", pid);
            // IEnumerable<XElement> newlist = GetElement(xq);
            //  return newlist;

            List<StaticOptionModel> mList = new List<StaticOptionModel>();
            try
            {
                foreach (var m in XML.QueryElements(xq))
                {
                    StaticOptionModel model = new StaticOptionModel();
                    model.ShowName = m.Value;
                    model.ShowValue = m.Attribute("value").Value;
                    mList.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return mList;
        }

       /// <summary>
       /// 根据具体 Value 值，获取对应的 Text 描述
       /// </summary>
       /// <param name="pid"></param>
       /// <param name="itemval"></param>
       /// <returns>返回对应的 Text</returns>
        public string GetItemText(string pid = "", string itemval = "")
        {
            XmlQueryParm xq = new XmlQueryParm();
            xq.strNode = "item";
            xq.pstrAtt = new Dictionary<string, string>();
            xq.pstrAtt.Add("name", pid);
            xq.strAtt = new Dictionary<string, string>();
            xq.strAtt.Add("value", itemval);
            try
            {
                return XML.QueryElements(xq).First().Value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
