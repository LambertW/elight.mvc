using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.Entity.ResponseModels;
using Elight.IRepository;
using FreeSql;

namespace Elight.Repository
{
    /// <summary>
    /// 数据访问层父类。
    /// </summary>
    public partial class BaseRepository<TEntity, TPrimayKey> : Elight.IRepository.IBaseRepository<TEntity, TPrimayKey> where TEntity : class, IEntity<TPrimayKey>
    {
        protected IFreeSql FreeSql;
        protected FreeSql.IBaseRepository<TEntity, TPrimayKey> Repository;

        public BaseRepository()
        {
            FreeSql = FreeSqlFactory.Instance;
            if (typeof(TPrimayKey) == typeof(Guid))
            {
                Repository = (FreeSql.IBaseRepository<TEntity, TPrimayKey>)FreeSqlFactory.Instance.GetGuidRepository<TEntity>();
            }
            else
            {
                Repository = FreeSqlFactory.Instance.GetRepository<TEntity, TPrimayKey>();
            }
        }

        public bool Exists(object primaryKey)
        {
            return Repository.Where(t => t.Id.Equals(primaryKey)).Count() > 0;
        }
        public TEntity Get(object primaryKey)
        {
            return Repository.Get((TPrimayKey)primaryKey);
        }
        public virtual List<TEntity> GetList()
        {
            return Repository.Where(null).ToList();
        }

        public object Insert(TEntity model)
        {
            return Repository.Insert(model);
        }

        public int Delete(object primaryKey)
        {
            return Repository.Delete((TPrimayKey)primaryKey);
        }
        public int Delete(TEntity model)
        {
            return Repository.Delete(model);
        }
        public int Delete(Expression<Func<TEntity, bool>> expression)
        {
            return Repository.Delete(expression);
        }

        public int Update(TEntity model)
        {
            return Repository.Update(model);
        }
        public int Update(TEntity model, IEnumerable<string> columns)
        {
            return FreeSql.Update<TEntity>().SetSource(model).UpdateColumns(columns.ToArray()).ExecuteAffrows();
        }

        public long Count(Expression<Func<TEntity, bool>> expression)
        {
            return FreeSql.Select<Sys_Item>().Where(expression).Count();
        }

        protected virtual Page<TEntity> ToPage(ISelect<TEntity> condition, int pageIndex, int pageSize, string orderBy)
        {
            // 获取总数，分页数据有先后执行顺序要求
            // Count前不允许使用OrderBy
            var total = condition.Count();
            var page = condition
                .OrderBy(!string.IsNullOrWhiteSpace(orderBy), orderBy)
                .Page(pageIndex, pageSize).ToList();

            return new Page<TEntity>
            {
                Items = page,
                TotalItems = total
            };
        }
    }
}
