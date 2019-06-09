using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;
using Elight.IService;
using Elight.Repository;

namespace Elight.Service
{
    /// <summary>
    /// 业务逻辑层父类。
    /// </summary>
    public partial class BaseService<TEntity, TPrimaryKey> : IBaseService<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        protected IBaseRepository<TEntity, TPrimaryKey> Repository;

        public BaseService(IBaseRepository<TEntity, TPrimaryKey> repository)
        {
            Repository = repository;
        }

        public bool Exists(TPrimaryKey primaryKey)
        {
            return Repository.Exists(primaryKey);
        }

        public TEntity Get(TPrimaryKey primaryKey)
        {
            return Repository.Get(primaryKey);
        }

        public virtual object Insert(TEntity model)
        {
            return Repository.Insert(model);
        }

        public virtual int Update(TEntity model)
        {
            return Repository.Update(model);
        }

        public virtual int Delete(TPrimaryKey primaryKey)
        {
            return Delete(new TPrimaryKey[] { primaryKey });
        }

        public virtual int Delete(TPrimaryKey[] primaryKeys)
        {
            return Repository.Delete(primaryKeys);
        }

        public virtual List<TEntity> GetList()
        {
            return Repository.GetList();
        }
    }
}
