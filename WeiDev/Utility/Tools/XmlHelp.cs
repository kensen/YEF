using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YEF.Utility
{
    /// <summary>
    /// XML操作的抽象类
    /// 针对不同XML文件，继承之后通过初始化赋值XML属性。然后通过 GetElement 方法实现读取扩展
    /// 余庆元 2014-09-04
    /// </summary>
    public abstract class XmlHelp
    {
        public XElement XML { get; set; }     

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="path"></param>
        protected void SetXML(string path)
        {
            XML = XElement.Load(path);
        }

        protected void SetXMLByString(string XMLString)
        {
            XML = XElement.Parse(XMLString);
        }

        
        /// <summary>
        /// 获取节点XML
        /// </summary>
        /// <param name="descendants"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public IEnumerable<XElement> GetElement(XmlQueryParm parm)
        {
            IEnumerable<XElement> newlist = from item in XML.Descendants(parm.strNode) select item;

           

            if (parm.strAtt!=null && parm.strAtt.Count>0)
            {
                 foreach (KeyValuePair<string, string> i in parm.strAtt)
                 {
                     newlist = newlist.Where(p => (string)p.Attribute(i.Key) == i.Value);
                }
            }

            if (parm.pstrAtt!=null&& parm.pstrAtt.Count > 0)
            {
                foreach (KeyValuePair<string, string> i in parm.pstrAtt)
                {
                    newlist = newlist.Where(p => (string)p.Parent.Attribute(i.Key) == i.Value );
                }
            }

            return newlist;
        }

        //public bool SetElement(XmlQueryParm parm, Dictionary<string,string> attrValueList)
        //{
        //    bool req = false;

        //    IEnumerable<XElement> list = GetElement(parm);
            
        //    //IEnumerable<XElement> selt = ucBLL.GetChildElementByTid(xml, hidTid.Value.ToString());


        //    foreach (XElement item in list)
        //    {
        //        item.SetAttributeValue("show", chklist.Items.FindByValue(col.Attribute("cName").Value).Selected.ToString());
        //    }


        //    return req;
        //}
      
    }

    /// <summary>
    /// 查询条件
    /// </summary>
    public class XmlQueryParm{
       /// <summary>
       /// 节点名称
       /// </summary>
        public string strNode { get; set; }

       /// <summary>
       /// 节点属性及赋值
       /// </summary>
        public  Dictionary<string,string> strAtt { get; set; }   
       
        /// <summary>
        /// 节点父级属性及赋值
        /// </summary>
        public Dictionary<string, string> pstrAtt { get; set; }       
      
    }

    ///// <summary>
    ///// 节点属性赋值
    ///// </summary>
    //public class ElementAttrValue
    //{
        
    //}
}
