using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YEF.Models;
using YEF.Repositories;
using WeiDevUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeiDevUI.Controllers
{
    public class RoleApiController : ApiController
    {
        // GET api/roleapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/roleapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/roleapi
      
        public string Post(JObject AuthList)
        {
            List<MenuModel> MenuLists = new List<MenuModel>();

            var pgroup = (from p in AuthList["AuthList"].Children()
                          select (string)p["pgroup"]).Distinct().ToList();

            var group = (from p in AuthList["AuthList"].Children()
                         select (string)p["group"]).Distinct().ToList();

            foreach (var i in pgroup)
            {
                MenuModel mm = new MenuModel();
                mm.ID = (string)i;
                mm.Item = new List<ItemModel>();
                mm.IsShow = false;

                foreach (var a in group)
                {
                    ItemModel item = new ItemModel();
                    item.ID = a;
                    item.IsShow = false;
                    item.Authoritys = new List<AuthorityModel>();

                    var authoritys = (from p in AuthList["AuthList"].Children()
                                      where (string)p["group"] == a
                                      select new
                                      {
                                          ID = (string)p["ID"],
                                          IsShow = (bool)p["IsShow"]
                                      }).ToList();

                    foreach (var x in authoritys)
                    {
                        AuthorityModel am = new AuthorityModel();
                        am.ID = x.ID;
                        am.IsShow = x.IsShow;
                        if (am.IsShow)
                        {
                            item.IsShow = true;
                            mm.IsShow = true;
                        }
                        item.Authoritys.Add(am);
                    }
                    mm.Item.Add(item);
                }
                MenuLists.Add(mm);
            }
            

            SysMenuInit minit = new SysMenuInit();

            return minit.UpdataAllRoleAuthority(MenuLists);

        }

        // PUT api/roleapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/roleapi/5
        public void Delete(int id)
        {
        }
    }
}
