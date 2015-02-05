using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YEF.AppServices.ViewModels;
using YEF.AppServices.Services.User;
using YEF.Models;
using YEF.Repositories;
using YEF.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeiDevUI.Controllers
{
    public class RoleController : Controller
    {
       // private WeiDevContext db = new WeiDevContext();
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        // GET: /Role/
        public ActionResult Index()
        {
            return View(_roleService.Role.ToList());
        }

        // GET: /Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysRoles sysrole =_roleService.Role.Where(m => m.Id == id.Value).First();
            if (sysrole == null)
            {
                return HttpNotFound();
            }
            return View(sysrole);
        }

        // GET: /Role/Create
        public ActionResult Create()
        {
            SysMenuInit minit=new SysMenuInit();
            ViewBag.AuthorityList = minit.GetAllRoleAuthorityList();
            return View();
        }

        // POST: /Role/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="SysRoleID,RoleName,RoleDescribe,RoleAuthority")] SysRoles sysrole)
        {
            //if (ModelState.IsValid)
            //{
            //    db.SysRoles.Add(sysrole);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(sysrole);
            return View();
        }

        // GET: /Role/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SysRole sysrole = db.SysRoles.Find(id);
            //if (sysrole == null)
            //{
            //    return HttpNotFound();
            //}
            //else
            //{

            //    SysMenuInit minit = new SysMenuInit(sysrole.RoleAuthority);
            //    ViewBag.AuthorityList = minit.GetAllRoleAuthorityList();
            //}
            //return View(sysrole);
            return View();
        }

        // POST: /Role/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="SysRoleID,RoleName,RoleDescribe,RoleAuthority")] SysRoles sysrole)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(sysrole).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(sysrole);
            return View();
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public string SetRoleAuthority(JObject AuthList)
        {
            List<MenuModel> MenuLists = new List<MenuModel>();

            var pgroup = (from p in AuthList.Children()
                             select (string)p["pgroup"]).Distinct().ToList();

            var group = (from p in AuthList.Children()
                         select (string)p["group"]).Distinct().ToList();

            foreach (var i in pgroup)
            {
                MenuModel mm = new MenuModel();
                mm.ID = (string)i;
                mm.Item = new List<ItemModel>();
                mm.IsShow=false;

                foreach (var a in group)
                {
                    ItemModel item = new ItemModel();
                    item.ID = a;
                    item.IsShow=false;
                    item.Authoritys = new List<AuthorityModel>();

                    var authoritys = (from p in AuthList.Children()
                                      where (string)p["group"]==a
                                      select new {
                                                ID =   (string)p["ID"],
                                                IsShow=   (bool)p["IsShow"]
                                        }).ToList();

                    foreach(var x in authoritys){
                        AuthorityModel am=new AuthorityModel();
                        am.ID=x.ID;
                        am.IsShow = x.IsShow;
                        if(am.IsShow){
                            item.IsShow=true;
                            mm.IsShow=true;
                        }
                        item.Authoritys.Add(am);
                    }
                     mm.Item.Add(item);
                }

            }

            SysMenuInit minit = new SysMenuInit();

            return minit.UpdataAllRoleAuthority(MenuLists);
           
        }

        // GET: /Role/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SysRole sysrole = db.SysRoles.Find(id);
            //if (sysrole == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(sysrole);
            return View();
        }

        // POST: /Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SysRole sysrole = db.SysRoles.Find(id);
            //db.SysRoles.Remove(sysrole);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
