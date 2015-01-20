using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;
using YEF.Utility;
using YEF.Utility.Msgs;
using AutoMapper;
namespace YEF.Repositories
{
    public class Repository<TEntity,TKey>:IRepository<TEntity,TKey> where TEntity:EntityBase<TKey>
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 单元操作对象 （DBContext）
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        /// <summary>
        /// 当前实体类型数据集合
        /// </summary>
        public IQueryable<TEntity> Entities
        {
            get { return_dbSet; }
        }

        /// <summary>
        /// 初始化 Repository 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = ((DbContext)unitOfWork).Set<TEntity>();
        }

        /// <summary>
        /// 新增一个数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(TEntity entity)
        {
            entity.CheckNotNull("entity");
            _dbSet.Add(entity);
            return SaveChanges();
        }

        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert(IEnumerable<TEntity> entities)
        {
            entities = entities as TEntity[] ?? entities.ToArray();
            _dbSet.AddRange(entities);
            return SaveChanges();
        }

        public OperationResult Insert<TAddDto>(ICollection<TAddDto> dtos, Action<TAddDto> checkAction = null, Func<TAddDto, TEntity, TEntity> updateFunc = null) where TAddDto : IAddDto
        {
            dtos.CheckNotNull("dtos");
            List<string> names = new List<string>();

            foreach (var dto in dtos)
            {
                TEntity entity = Mapper.Map<TEntity>(dto);

                try
                {
                    if (checkAction != null)
                    {
                        checkAction(dto);
                    }
                    if (updateFunc != null)
                    {
                        entity = updateFunc(dto, entity);
                    }
                }
                catch (Exception ex)
                {
                    return new OperationResult(OperationResultType.Error, ex.Message);
                }

                _dbSet.Add(entity);
                string name = GetNameValue(dto);
                if(name!=null)
                {
                    names.Add(name);
                }
            }
            int count = SaveChanges();
            return count>0?new OperationResult(OperationResultType.Success,
                names.Count>0?
                     ? "信息“{0}”添加成功".FormatWith(names.ExpandAndToString())
                        : "{0}个信息添加成功".FormatWith(dtos.Count))
            ：new OperationResult(OperationResultType.NoChanged);

        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Utility.Msgs.OperationResult Delete(ICollection<TKey> ids, Action<TEntity> checkAction = null, Func<TEntity, TEntity> deleteFunc = null)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(System.Linq.Expressions.Expression<Func<TEntity, object>> propertyExpresion, params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Utility.Msgs.OperationResult Update<TEditDto>(ICollection<TEditDto> dtos, Action<TEditDto> checkAction = null, Func<TEditDto, TEntity, TEntity> updateFunc = null) where TEditDto : IEditDto<TKey>
        {
            throw new NotImplementedException();
        }

        public bool ExistsCheck(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, TKey id = default(TKey))
        {
            throw new NotImplementedException();
        }

        public TEntity GetByKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetInclude<TProperty>(System.Linq.Expressions.Expression<Func<TEntity, TProperty>> path)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetIncludes(params string[] paths)
        {
            throw new NotImplementedException();
        }


        public int SaveChanges()
        {
            return _unitOfWork.TransactionEnabled ? 0 : _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// 检查主键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyName"></param>
        private static void CheckEntityKey(object key, string keyName)
        {
            key.CheckNotNull("key");
            keyName.CheckNotNull("keyName");

            Type type = key.GetType();
            if (type == typeof(int))
            {
                //如果是 int 必须大于或者等于 0
                ((int)key).CheckGreaterThan(keyName, 0);
            }
            else if(type==typeof(string))
            {
                //字符串类型判断不能为空
                ((string)key).CheckNotNullOrEmpty(keyName);
            }
            else if(type==typeof(Guid))
            {
                ((Guid)key).CheckNotEmpty(keyName);
            }
        }

        private static string GetNameValue(object value)
        {
            dynamic obj = value;
            try
            {
                return obj.Name;
            }
            catch
            {
                return null;
            }
        }

    }
}
