﻿/**  版本信息模板在安装目录下，可自行修改。
* PlayMediaInfo.cs
*
* 功 能： N/A
* 类 名： PlayMediaInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 17:09:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using KryptonAccessController.SQLite.Model.LCDRelation;
namespace KryptonAccessController.SQLite.BLL.LCDRelation
{
	/// <summary>
	/// PlayMediaInfo
	/// </summary>
	public partial class PlayMediaInfo
	{
		private readonly KryptonAccessController.SQLite.DAL.LCDRelation.PlayMediaInfo dal=new KryptonAccessController.SQLite.DAL.LCDRelation.PlayMediaInfo();
		public PlayMediaInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PlayMediaID)
		{
			return dal.Exists(PlayMediaID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PlayMediaID)
		{
			
			return dal.Delete(PlayMediaID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PlayMediaIDlist )
		{
			return dal.DeleteList(PlayMediaIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo GetModel(int PlayMediaID)
		{
			
			return dal.GetModel(PlayMediaID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo GetModelByCache(int PlayMediaID)
		{
			
			string CacheKey = "PlayMediaInfoModel-" + PlayMediaID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PlayMediaID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo> DataTableToList(DataTable dt)
		{
			List<KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo> modelList = new List<KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KryptonAccessController.SQLite.Model.LCDRelation.PlayMediaInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
