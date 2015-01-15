using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace YEF.AppServices.ViewModels
{
    public class MenuModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }

        public bool IsShow { get; set; }

        public string Icon { get; set; }

        public string CurrentCss { get; set; }
        public string CurrentCssClass { get; set; }
        public virtual ICollection<ItemModel> Item { get; set; }
    }

    public class ItemModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }

        public bool IsShow { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }

        public string CurrentCssClass { get; set; }

        public virtual ICollection<AuthorityModel> Authoritys { get; set; }
    }

    public class AuthorityModel
    {
        public string ID { get; set; }
        public bool IsShow { get; set; }

        public string Name { get; set; }
    }

    [JsonObject]
    public class AuthSettingModel
    {
        public string ID { get; set; }
        public bool IsShow { get; set; }

        public string group { get; set; }
        public string pgroup { get; set; }
    }
}