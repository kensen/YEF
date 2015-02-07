using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;

namespace YEF.Models.EntityConfigurations
{
    public class YEFUserConfiguration:EntityConfigurationBase<YEFUser,Guid>
    {
        public YEFUserConfiguration()
        {
            HasOptional(m => m.YEFRole).WithMany(n => n.YEFUsers);
            HasOptional(m => m.YEFOrganization).WithMany(n => n.YEFUsers);
        }
    }
}
