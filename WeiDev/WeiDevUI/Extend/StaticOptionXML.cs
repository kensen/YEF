using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using YEF.Utility;
using YEF.AppServices.ViewModels;
using YEF.Utility.Extensions;
using YEF.Utility.Data;

namespace WeiDevUI
{
    public class StaticOptionXML:XmlBase
    {
        public StaticOptionXML()
        {
            string path = HttpContext.Current.Server.MapPath(@"~/Config/StaticOptions.xml");
            SetXML(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pval"></param>
        /// <returns></returns>
        public List<StaticOptionModel> GetItemList(string pid = "")
        {
            XmlQueryParm xq = new XmlQueryParm();
            xq.strNode = "item";
            xq.pstrAtt=new Dictionary<string,string>();
            xq.pstrAtt.Add("name", pid);
            // IEnumerable<XElement> newlist = GetElement(xq);
            //  return newlist;
            
            List<StaticOptionModel> mList = new List<StaticOptionModel>();
            try
            {
                foreach (var m in  XML.QueryElements(xq))
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
        /// 按照选项值查找选项的对应描述
        /// </summary>
        /// <param name="pid">父级</param>
        /// <param name="itemval">查询对应值</param>
        /// <returns></returns>
        public string GetItemVal(string pid = "", string itemval = "")
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