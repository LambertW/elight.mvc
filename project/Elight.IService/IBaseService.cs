﻿using Elight.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IService
{
    /// <summary>
    /// 业务逻辑层父接口。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IBaseService<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 记录是否存在。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        bool Exists(TPrimaryKey primaryKey);
        /// <summary>
        /// 查询一条记录。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        TEntity Get(TPrimaryKey primaryKey);
        List<TEntity> GetList();
        /// <summary>
        /// 新增一条记录。
        /// </summary>
        /// <param name="model">新增对象</param>
        /// <returns></returns>
        object Insert(TEntity model);
        /// <summary>
        /// 删除一条记录。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        int Delete(TPrimaryKey primaryKey);
        int Delete(TPrimaryKey[] primaryKey);
        /// <summary>
        /// 更新一条记录。
        /// </summary>
        /// <param name="model">修改对象</param>
        /// <returns></returns>
        int Update(TEntity model);
    }
}
