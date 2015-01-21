using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEF.Infrastructure.Data;
using YEF.Utility;
using YEF.Utility.Msgs;
using YEF.Utility.Extensions;

using AutoMapper;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
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
            get { return _dbSet; }
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
                names.Count>0
                     ? "信息“{0}”添加成功".FormatWith(names.ExpandAndToString())
                        : "{0}个信息添加成功".FormatWith(dtos.Count))
                        :new OperationResult(OperationResultType.NoChanged);

        }

        public int Delete(TEntity entity)
        {
            entity.CheckNotNull("entity");
            _dbSet.Remove(entity);
            return SaveChanges();
        }

        public int Delete(TKey key)
        {
           CheckEntityKey(key,"key");
            TEntity entity=_dbSet.Find(key);
            return entity==null?0:Delete(entity);
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
          predicate.CheckNotNull("predicate");
            TEntity[] entities=_dbSet.Where(predicate).ToArray();
            return entities.Length ==0?0:Delete(entities);
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            entities=entities as TEntity[]??entities.ToArray();
            _dbSet.RemoveRange(entities);
            return SaveChanges();
        }

        public OperationResult Delete(ICollection<TKey> ids, Action<TEntity> checkAction = null, Func<TEntity, TEntity> deleteFunc = null)
        {
            ids.CheckNotNull("ids");
            List<string> names=new List<string>();
           
                foreach(var id in ids){

                    TEntity entity=_dbSet.Find(id);
                    try
                    {
                         if(checkAction !=null)
                         {
                               checkAction(entity);
                         }
                        if(deleteFunc!=null)
                        {
                            entity=deleteFunc(entity);
                        }
                  
                     }
                    catch(Exception ex)
                    {
                        return new OperationResult(OperationResultType.Error,ex.Message);
                     }
                    _dbSet.Remove(entity);
                    string name=GetNameValue(entity);

                    if(name !=null){
                        names.Add(name);
                    }
                }

            int count=SaveChanges();
            return count > 0 ? new OperationResult(OperationResultType.Success,
                names.Count>0
                 ? "信息“{0}”删除成功".FormatWith(names.ExpandAndToString())
                        : "{0}个信息删除成功".FormatWith(ids.Count))
                        : new OperationResult(OperationResultType.NoChanged);
         
        }

        public int Update(TEntity entity)
        {
           entity.CheckNotNull("entity");
           ( (DbContext)_unitOfWork).Update<TEntity,TKey>(entity);
           return SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyExpresion"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update(Expression<Func<TEntity, object>> propertyExpresion, params TEntity[] entities)
        {
            propertyExpresion.CheckNotNull("propertyExpresion");
            entities.CheckNotNull("entities");
            YEFDbContext context = new YEFDbContext();
            context.Update<TEntity, TKey>(propertyExpresion, entities);
            try
            {
                return context.SaveChanges(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                TKey[] ids = entities.Select(m => m.ID).ToArray();
                context.Set<TEntity>().Where(m => ids.Contains(m.ID)).Load();
                context.Update<TEntity, TKey>(propertyExpresion, entities);
                return context.SaveChanges(false);
            }
        }

        public OperationResult Update<TEditDto>(ICollection<TEditDto> dtos, Action<TEditDto> checkAction = null, Func<TEditDto, TEntity, TEntity> updateFunc = null) where TEditDto : IEditDto<TKey>
        {
            dtos.CheckNotNull("dtos");
            List<string> names = new List<string>();
            foreach (var dto in dtos)
            {
                TEntity entity = _dbSet.Find(dto.Id);
                if(entity ==null)
                {
                    return new OperationResult(OperationResultType.QueryNull);
                }
                entity = Mapper.Map(dto, entity);

                try
                {
                    if(checkAction !=null)
                    {
                        checkAction(dto);
                    }
                    if(updateFunc!=null)
                    {
                        entity = updateFunc(dto, entity);
                    }
                }
                catch(Exception ex)
                {
                    return new OperationResult(OperationResultType.Error, ex.Message);

                }
                ((DbContext)_unitOfWork).Update<TEntity, TKey>(entity);
                string name = GetNameValue(dto);
                if(name !=null)
                {
                    names.Add(name);
                }

            }

            int count = SaveChanges();
            return count > 0 ? new OperationResult(OperationResultType.Success,
                names.Count > 0
                ? "信息“{0}”更新成功".FormatWith(names.ExpandAndToString())
                : "{0}个信息更新成功".FormatWith(dtos.Count))
                : new OperationResult(OperationResultType.NoChanged);
        }

        public bool ExistsCheck(Expression<Func<TEntity, bool>> predicate, TKey id = default(TKey))
        {
            TKey defaultId = default(TKey);
            var entity = _dbSet.Where(predicate).Select(m => new { m.ID }).SingleOrDefault();
            bool exists = id.Equals(defaultId) ? entity != null : entity != null && entity.ID.Equals(defaultId);
            return exists;
        }

        public TEntity GetByKey(TKey key)
        {
            CheckEntityKey(key, "key");
            return _dbSet.Find(key);
        }

        public IQueryable<TEntity> GetInclude<TProperty>(Expression<Func<TEntity, TProperty>> path)
        {
            path.CheckNotNull("path");
            return _dbSet.Include(path);
        }

        public IQueryable<TEntity> GetIncludes(params string[] paths)
        {
            paths.CheckNotNull("paths");
            IQueryable<TEntity> source = _dbSet;
            foreach (var path in paths)
            {
                source = source.Include(path);
            }
            return source;
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
