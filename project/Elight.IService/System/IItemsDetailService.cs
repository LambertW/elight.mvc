using Elight.Entity;
using Elight.Entity.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IService
{
    public partial interface IItemsDetailService : IBaseService<Sys_ItemsDetail, Guid>
    {
        /// <summary>
        /// 分页获取指定字典选项。
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="itemId">字典ID</param>
        /// <param name="keyWord">选项名称或编码</param>
        /// <returns></returns>
        Page<Sys_ItemsDetail> GetList(int pageIndex, int pageSize, Guid itemId, string keyWord);
    }
}
