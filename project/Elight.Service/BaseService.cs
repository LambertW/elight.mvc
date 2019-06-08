﻿using System;
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
        private IBaseRepository<TEntity, TPrimaryKey> _baseDal;

        public BaseService()
        {
            if (_baseDal == null)
            {
                _baseDal = new BaseRepository<TEntity, TPrimaryKey>();
            }
        }

        public bool Exists(object primaryKey)
        {
            return _baseDal.Exists(primaryKey);
        }

        public TEntity Get(object primaryKey)
        {
            return _baseDal.Get(primaryKey);
        }

        public virtual object Insert(TEntity model)
        {
            return _baseDal.Insert(model);
        }

        public virtual int Update(TEntity model)
        {
            return _baseDal.Update(model);
        }

        public virtual int Delete(object primaryKey)
        {
            return _baseDal.Delete(primaryKey);
        }

    }
}
