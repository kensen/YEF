using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Utility.Data
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class XmlQueryParm
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string strNode { get; set; }

        /// <summary>
        /// 节点属性及赋值
        /// </summary>
        public Dictionary<string, string> strAtt { get; set; }

        /// <summary>
        /// 节点父级属性及赋值
        /// </summary>
        public Dictionary<string, string> pstrAtt { get; set; }

    }
}
