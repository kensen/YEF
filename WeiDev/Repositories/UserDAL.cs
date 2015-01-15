using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using YEF.Models;


namespace YEF.Repositories
{

    public class UserDAL : IDisposable
    {
        private WeiDevContext db;

        public UserDAL()
        {
            db = new WeiDevContext();
        }

        public SysUser GetModel(int id)
        {
         
                return db.SysUsers.Find(id);
          
           
        }

        public bool ValidateUser(string LoginID, string PWD)
        {
         
                try
                {
                    SysUser model = db.SysUsers.Where(s => s.LoginID == LoginID
                        && s.Password == PWD).SingleOrDefault();
                    if (model != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }
          
        }

        public bool ValidateUser(string LoginID)
        {
            
                try
                {
                    SysUser model = db.SysUsers.Where(s => s.LoginID == LoginID).SingleOrDefault();
                    if (model != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }
              
               
                  
        }



        public void Dispose()
        {
            db.Dispose();
        }
    }
}
