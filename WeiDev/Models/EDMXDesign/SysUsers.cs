//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YEF.Models.EDMXDesign
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysUsers
    {
        public SysUsers()
        {
            this.IsSPAdmin = false;
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string ADPassword { get; set; }
        public UserTypeEnum UserType { get; set; }
        public bool IsSPAdmin { get; set; }
    
        public virtual SysOrganizations SysOrganizations { get; set; }
        public virtual SysRoles SysRoles { get; set; }
    }
}
