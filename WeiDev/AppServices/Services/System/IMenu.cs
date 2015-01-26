using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.AppServices.ViewModels;

namespace YEF.AppServices.Services.System
{
    public interface IMenu
    {
        /// <summary>
        /// 初始化XML配置源，读取用户配置，如果没有默认读取系统配置文件
        /// </summary>
        void InitXML(int ? UserID=null);

        /// <summary>
        /// 获取系统菜单，并根据当前controller 和 action 设置展开样式
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        List<MenuModel> GetMenuList(string controller = "", string action = "");

        /// <summary>
        /// 获取角色权限配置列表
        /// </summary>
        /// <returns></returns>
        List<MenuModel> GetAllRoleAuthoritySettingList();

        /// <summary>
        /// 更新角色权限配置表，并返回XML 字符串。
        /// </summary>
        /// <param name="MenuLists"></param>
        /// <returns></returns>
        string UpdataAllRoleAuthoritySetting(List<MenuModel> MenuLists);

    }
}
