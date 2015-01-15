using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeiDevUI.Models;
using YEF.Models;
using YEF.Repositories;
using YEF.Utility;
//using PagedList;  //使用 PagedList 分页
using Webdiyer.WebControls.Mvc; //使用 MvcPager 分页
namespace WeiDevUI.Controllers
{
    public class UserController : Controller
    {
        private WeiDevContext db = new WeiDevContext();

        // GET: /User/
        public ActionResult Index(int page=1)
        {
            var sysusers = db.SysUsers.Include(s => s.SysRole);

           // int pageIndex = 0;
            int pageSize = 1;
            //var orders = sysusers.OrderByDescending(o => o.SysUserID)
            //.Skip(pageIndex * pageSize)
            //.Take(pageSize);
           // sysusers.Count();
            return View(sysusers.OrderBy(o => o.SysUserID).ToPagedList(page, pageSize));
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            using (UserDAL UDAL = new UserDAL())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SysUser sysuser = UDAL.GetModel(id.Value);

                if (sysuser == null)
                {
                    return HttpNotFound();
                }
                return View(sysuser);

            }
           
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            StaticOptionXML Utype = new StaticOptionXML();
            List<StaticOptionModel> utList = Utype.GetItemList("UserType");
            ViewBag.UserType = new SelectList(utList, "ShowValue", "ShowName");

            ViewBag.SysRoleID = new SelectList(db.SysRoles, "SysRoleID", "RoleName");
            return View();
        }

        // POST: /User/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SysUserID,UserName,LoginID,Password,ADPasswor,UserType,IsSPAdmin,SysRoleID")] SysUser sysuser)
        {
            if (ModelState.IsValid)
            {
                //sysuser.Password = MD5Class.GetMD5(sysuser.Password);
                sysuser.Password = MD5Class.GetMD5("123456");
                sysuser.ADPasswor = sysuser.Password;
                db.SysUsers.Add(sysuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            StaticOptionXML Utype = new StaticOptionXML();
            List<StaticOptionModel> utList = Utype.GetItemList("UserType");
            ViewBag.UserType = new SelectList(utList, "ShowValue", "ShowName");

            ViewBag.SysRoleID = new SelectList(db.SysRoles, "SysRoleID", "RoleName", sysuser.SysRoleID);
            return View(sysuser);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysUser sysuser = db.SysUsers.Find(id);
            if (sysuser == null)
            {
                return HttpNotFound();
            }
            StaticOptionXML Utype = new StaticOptionXML();
            List<StaticOptionModel> utList = Utype.GetItemList("UserType");
            ViewBag.UserType = new SelectList(utList, "ShowValue", "ShowName", sysuser.UserType);
            ViewBag.SysRoleID = new SelectList(db.SysRoles, "SysRoleID", "RoleName", sysuser.SysRoleID);
            return View(sysuser);
        }

        // POST: /User/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SysUserID,UserName,LoginID,Password,ADPasswor,UserType,IsSPAdmin,SysRoleID")] SysUser sysuser)
        {
            if (ModelState.IsValid)
            {
                SysUser upsysuser = db.SysUsers.Find(sysuser.SysUserID);
                db.SysUsers.Attach(upsysuser);
                upsysuser.LoginID = sysuser.LoginID;
                upsysuser.IsSPAdmin = sysuser.IsSPAdmin;
                upsysuser.SysRoleID = sysuser.SysRoleID;
                upsysuser.UserName = sysuser.UserName;
                upsysuser.UserType = sysuser.UserType;
                

               // db.Entry(sysuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            StaticOptionXML Utype = new StaticOptionXML();
            List<StaticOptionModel> utList = Utype.GetItemList("UserType");
            ViewBag.UserType = new SelectList(utList, "ShowValue", "ShowName", sysuser.UserType);
            ViewBag.SysRoleID = new SelectList(db.SysRoles, "SysRoleID", "RoleName", sysuser.SysRoleID);
            return View(sysuser);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysUser sysuser = db.SysUsers.Find(id);
            if (sysuser == null)
            {
                return HttpNotFound();
            }
            return View(sysuser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysUser sysuser = db.SysUsers.Find(id);
            db.SysUsers.Remove(sysuser);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
