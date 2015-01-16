using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;
using YEF.Utility;

namespace YEF.Infrastructure.Extensions
{
    public class CollectionExtensions
    {
        /// <summary>
        /// 从指定<see cref="IQueryable{T}"/>集合 中查询指定分页条件的子数据集
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="source">要查询的数据集</param>
        /// <param name="predicate">查询条件谓语表达式</param>
        /// <param name="pageConfig">分页查询条件</param>
        /// <param name="total">输出符合条件的总记录数</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity, TKey>(this IQueryable<TEntity> source,
            Expression<Func<TEntity, bool>> predicate,
            PageConfig pageConfig,
            out int total) where TEntity : EntityBase<TKey>
        {
            source.CheckNotNull("source");
            predicate.CheckNotNull("predicate");
            pageConfig.CheckNotNull("pageCondition");

            return source.Where<TEntity, TKey>(predicate, pageConfig.PageIndex, pageConfig.PageSize, out total, pageConfig.SortConditions);
        }


        /// <summary>
        /// 从指定<see cref="IQueryable{T}"/>集合 中查询指定分页条件的子数据集
        /// </summary>
        /// <typeparam name="TEntity">动态实体类型</typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <param name="source">要查询的数据集</param>
        /// <param name="predicate">查询条件谓语表达式</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="total">输出符合条件的总记录数</param>
        /// <param name="sortConfigs">排序条件集合</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity, TKey>(this IQueryable<TEntity> source,
            Expression<Func<TEntity, bool>> predicate,
            int pageIndex,
            int pageSize,
            out int total,
            SortConfig[] sortConfigs = null) where TEntity : EntityBase<TKey>
        {
            source.CheckNotNull("source");
            predicate.CheckNotNull("predicate");
            pageIndex.CheckGreaterThan("pageIndex", 0);
            pageSize.CheckGreaterThan("pageSize", 0);

            total = source.Count(predicate);
            source = source.Where(predicate);
            if (sortConfigs == null || sortConfigs.Length == 0)
            {
                source = source.OrderBy(m => m.ID);
            }
            else
            {
                int count = 0;
                IOrderedQueryable<TEntity> orderSource = null;
                foreach (SortConfig sortConfig in sortConfigs)
                {
                    orderSource = count == 0
                        ? QueryablePropertySorter<TEntity>.OrderBy(source, sortConfig.SortField, sortConfig.ListSortDirection)
                        : QueryablePropertySorter<TEntity>.ThenBy(orderSource, sortConfig.SortField, sortConfig.ListSortDirection);
                    count++;
                }
                source = orderSource;
            }
            return source != null
                ? source.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                : Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
