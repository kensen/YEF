using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiDevUI
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// 格式化用户类型显示
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string FormatUserType(this HtmlHelper helper, byte val)
        {
            StaticOptionXML opt = new StaticOptionXML();
            return opt.GetItemVal("UserType", val.ToString());
        }
    }
}