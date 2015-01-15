using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace YEF.Utility
{
    public static class ClearHTML
    {
        /**/
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
          //  Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }


        public static string  FilterHTML(string html)
        {
            System.Text.RegularExpressions.Regex regex1 =
                  new System.Text.RegularExpressions.Regex(@"<script[sS]+</script *>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 =
                  new System.Text.RegularExpressions.Regex(@" href *= *[sS]*script *:",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 =
                  new System.Text.RegularExpressions.Regex(@" no[sS]*=",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 =
                  new System.Text.RegularExpressions.Regex(@"<iframe[sS]+</iframe *>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 =
                  new System.Text.RegularExpressions.Regex(@"<frameset[sS]+</frameset *>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 =
                  new System.Text.RegularExpressions.Regex(@"<img[^>]+>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 =
                  new System.Text.RegularExpressions.Regex(@"</p>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 =
                  new System.Text.RegularExpressions.Regex(@"<p>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 =
                  new System.Text.RegularExpressions.Regex(@"<[^>]*>",
                  System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记   
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性   
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件   
            html = regex4.Replace(html, ""); //过滤iframe   
            html = regex5.Replace(html, ""); //过滤frameset   
            html = regex6.Replace(html, ""); //过滤frameset   
            html = regex7.Replace(html, ""); //过滤frameset   
            html = regex8.Replace(html, ""); //过滤frameset   
            html = regex9.Replace(html, "");
            //html = html.Replace(" ", "");  
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = Regex.Replace(html, "[\f\n\r\t\v]", "");  //过滤回车换行制表符  
            return html;
        }  

    }
}
