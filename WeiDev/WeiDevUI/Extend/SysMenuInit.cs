using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using YEF.Utility;
using WeiDevUI.Models;

namespace WeiDevUI
{
    public class SysMenuInit:XmlHelp
    {


        public SysMenuInit(string strXml="" ) {
            if (string.IsNullOrEmpty(strXml))
            {
                string path = HttpContext.Current.Server.MapPath(@"~/Config/SysSchema.xml");
                SetXML(path);
            }
            else
            {
                SetXMLByString(strXml);
            }
        
            
        }

        

        public List<MenuModel> GetModelList(string c="",string a="")
        {
            XmlQueryParm xq = new XmlQueryParm();
            xq.strNode = "Model";
            //xq.strAtt=new Dictionary<string,string>();
            //xq.strAtt.Add("Id", "SystemSetting");
            //xq.strAtt.Add("IsShow", "1");
           // IEnumerable<XElement> newlist = GetElement(xq);
          //  return newlist;

            List<MenuModel> mList = new List<MenuModel>();
            try
            {
                foreach (var m in GetElement(xq))
                {
                    MenuModel model = new MenuModel();
                    model.ID = m.Attribute("Id").Value;
                    model.Icon = m.Attribute("Icon").Value;
                    model.IsShow = m.Attribute("IsShow").Value == "1" ? true : false;
                    model.Name = m.Attribute("Name").Value;
                    model.Sort = Convert.ToInt32(m.Attribute("Sort").Value);
                    model.Item = new List<ItemModel>();

                   

                    foreach (var i in m.Elements("Menu"))
                    {
                        ItemModel item = new ItemModel();
                        item.ID = i.Attribute("Id").Value;
                        item.IsShow = i.Attribute("IsShow").Value == "1" ? true : false;
                        item.Name = i.Attribute("Name").Value;
                        // item.Sort = Convert.ToInt32( i.Attribute("Sort").Value);
                        item.Action = i.Attribute("Action").Value;
                        item.Controller = i.Attribute("Controller").Value;


                        if (c == item.Controller)//&& a==item.Action
                        {
                            item.CurrentCssClass = "active";
                            model.CurrentCssClass = "active";
                            model.CurrentCss = "display: block;";
                        }
                        else
                        {
                            item.CurrentCssClass = "";
                        }

                        model.Item.Add(item);
                    }

                    mList.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          

            return mList;

        }

        public List<MenuModel> GetAllRoleAuthorityList()
        {
            XmlQueryParm xq = new XmlQueryParm();
            xq.strNode = "Model";
            //  xq.strAtt=new Dictionary<string,string>();
            //  xq.strAtt.Add("Id", "SystemSetting");
            // IEnumerable<XElement> newlist = GetElement(xq);
            //  return newlist;

            List<MenuModel> mList = new List<MenuModel>();
            try
            {
                foreach (var m in GetElement(xq))
                {
                    MenuModel model = new MenuModel();
                    model.ID = m.Attribute("Id").Value;
                    model.Icon = m.Attribute("Icon").Value;
                    model.IsShow = m.Attribute("IsShow").Value == "1" ? true : false;
                    model.Name = m.Attribute("Name").Value;
                    model.Sort = Convert.ToInt32(m.Attribute("Sort").Value);
                    model.Item = new List<ItemModel>();



                    foreach (var i in m.Elements("Menu"))
                    {
                        ItemModel item = new ItemModel();
                        item.ID = i.Attribute("Id").Value;
                        item.IsShow = i.Attribute("IsShow").Value == "1" ? true : false;
                        item.Name = i.Attribute("Name").Value;
                        // item.Sort = Convert.ToInt32( i.Attribute("Sort").Value);
                        item.Action = i.Attribute("Action").Value;
                        item.Controller = i.Attribute("Controller").Value;
                        item.Authoritys = new List<AuthorityModel>();

                        foreach (var a in i.Elements("Authority"))
                        {
                            AuthorityModel amodel = new AuthorityModel();
                            amodel.IsShow =  a.Attribute("IsShow").Value=="1"?true:false;
                            amodel.ID = a.Attribute("Id").Value;
                            amodel.Name = a.Value;
                            item.Authoritys.Add(amodel);
                        }

                        //if (c == item.Controller)//&& a==item.Action
                        //{
                        //    item.CurrentCssClass = "active";
                        //    model.CurrentCssClass = "active";
                        //    model.CurrentCss = "display: block;";
                        //}
                        //else
                        //{
                        //    item.CurrentCssClass = "";
                        //}

                        model.Item.Add(item);
                    }

                    mList.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return mList;
        }

        public string UpdataAllRoleAuthority(List<MenuModel> MenuLists)
        {
            XmlQueryParm xq = new XmlQueryParm();
            xq.strNode = "Model";
            //  xq.strAtt=new Dictionary<string,string>();
            //  xq.strAtt.Add("Id", "SystemSetting");
            // IEnumerable<XElement> newlist = GetElement(xq);
            //  return newlist;

            List<MenuModel> mList = new List<MenuModel>();
            try
            {
                foreach (var m in GetElement(xq))
                {
                    string attval= m.Attribute("Id").Value;
                    m.SetAttributeValue("IsShow", MenuLists.Where(p => p.ID == attval).First().IsShow==true ? "1" : "0");

             

                    ICollection<ItemModel> items=MenuLists.Where(p => p.ID == m.Attribute("Id").Value).First().Item;

                    foreach (var i in m.Elements("Menu"))
                    {


                        i.SetAttributeValue("IsShow", items.Where(p => p.ID == i.Attribute("Id").Value).First().IsShow ? "1" : "0");



                        ICollection<AuthorityModel> Authoritys = items.Where(p => p.ID == i.Attribute("Id").Value).First().Authoritys;

                        foreach (var a in i.Elements("Authority"))
                        {

                             a.SetAttributeValue("IsShow", Authoritys.Where(p => p.ID == a.Attribute("Id").Value).First().IsShow ? "1" : "0");

                        }

                    }
              
                }

                return XML.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}