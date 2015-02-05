using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace YEF.Repositories
{
   public  class WeiDevContext:DbContext
    {
       public WeiDevContext() : base("YEFDBContext") { }

       public DbSet<SysUsers> SysUsers { get; set; }
       public DbSet<SysRoles> SysRoles { get; set; }
     

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
       }
    }
}
