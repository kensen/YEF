using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YEF.Infrastructure.Data
{
 
   public abstract class EntityBase<TKey>
    {
        /// <summary>
        /// 构造函数初始化默认值
        /// </summary>
        protected EntityBase()
        {
            IsDelete = false;
            AddTime = DateTime.Now;
        }

        /// <summary>
        /// 动态主键类型
        /// </summary>
        [Key]
        public TKey Id { get; set; }

        /// <summary>
        /// 伪删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        #region 方法

        /// <summary>
        /// 判断两个实体是否是同一数据记录的实体
        /// </summary>
        /// <param name="obj">要比较的实体信息</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            EntityBase<TKey> entity = obj as EntityBase<TKey>;
            if (entity == null)
            {
                return false;
            }
            return Id.Equals(entity.Id);
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>
        /// 当前 <see cref="T:System.Object"/> 的哈希代码。
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ AddTime.GetHashCode();
        }

        #endregion
    }
}
