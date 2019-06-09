//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://www.freesql.net
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Elight.Entity {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dbo.Sys_Permission")]
    public partial class Sys_Permission : IEntity<Guid>
    {

		/// <summary>
		/// 主键
		/// </summary>
		[JsonProperty]
		public Guid Id { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string CreateUser { get; set; }

		[JsonProperty]
		public bool? DeleteMark { get; set; }

		[JsonProperty, Column(DbType = "varchar(50)")]
		public string EnCode { get; set; }

		/// <summary>
		/// 图标
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Icon { get; set; }

		/// <summary>
		/// 允许编辑
		/// </summary>
		[JsonProperty]
		public bool? IsEdit { get; set; }

		/// <summary>
		/// 是否可用
		/// </summary>
		[JsonProperty]
		public bool? IsEnable { get; set; }

		/// <summary>
		/// 是否公开
		/// </summary>
		[JsonProperty]
		public bool? IsPublic { get; set; }

		/// <summary>
		/// 事件
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string JsEvent { get; set; }

		/// <summary>
		/// 层次
		/// </summary>
		[JsonProperty]
		public int? Layer { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[JsonProperty]
		public DateTime? ModifyTime { get; set; }

		/// <summary>
		/// 修改人
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string ModifyUser { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Name { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		[JsonProperty]
		public Guid? ParentId { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(500)")]
		public string Remark { get; set; }

		/// <summary>
		/// 排序码
		/// </summary>
		[JsonProperty]
		public int? SortCode { get; set; }

		/// <summary>
		/// 模块类型：1-菜单 2-按钮
		/// </summary>
		[JsonProperty]
		public int? Type { get; set; }

		/// <summary>
		/// 链接
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(300)")]
		public string Url { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}
