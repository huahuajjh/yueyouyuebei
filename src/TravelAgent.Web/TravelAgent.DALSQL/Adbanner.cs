﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TravelAgent.Tool;
using TravelAgent.IDAL;

namespace TravelAgent.DALSQL
{
    /// <summary>
	/// 广告条数据访问类
	/// </summary>
	public class Adbanner:IAdbanner
	{
		public Adbanner()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Adbanner");
			strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Adbanner ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(TravelAgent.Model.Adbanner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Adbanner(");
			strSql.Append("Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,IsLock,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@Aid,@Title,@StartTime,@EndTime,@AdUrl,@LinkUrl,@AdRemark,@IsLock,@AddTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@Aid", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@AdUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@AdRemark", SqlDbType.NVarChar,0),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Aid;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.StartTime;
			parameters[3].Value = model.EndTime;
			parameters[4].Value = model.AdUrl;
			parameters[5].Value = model.LinkUrl;
			parameters[6].Value = model.AdRemark;
			parameters[7].Value = model.IsLock;
			parameters[8].Value = model.AddTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TravelAgent.Model.Adbanner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Adbanner set ");
			strSql.Append("Aid=@Aid,");
			strSql.Append("Title=@Title,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("AdUrl=@AdUrl,");
			strSql.Append("LinkUrl=@LinkUrl,");
			strSql.Append("AdRemark=@AdRemark,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Aid", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@AdUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@AdRemark", SqlDbType.NVarChar,0),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Aid;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.StartTime;
			parameters[3].Value = model.EndTime;
			parameters[4].Value = model.AdUrl;
			parameters[5].Value = model.LinkUrl;
			parameters[6].Value = model.AdRemark;
			parameters[7].Value = model.IsLock;
			parameters[8].Value = model.AddTime;
            parameters[9].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Adbanner ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByAID(int Aid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Adbanner ");
            strSql.Append(" where Aid=@aid ");
            SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)};
            parameters[0].Value = Aid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgent.Model.Adbanner GetModel(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,IsLock,AddTime from Adbanner ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			TravelAgent.Model.Adbanner model=new TravelAgent.Model.Adbanner();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Aid"].ToString()!="")
				{
					model.Aid=int.Parse(ds.Tables[0].Rows[0]["Aid"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				model.AdUrl=ds.Tables[0].Rows[0]["AdUrl"].ToString();
				model.LinkUrl=ds.Tables[0].Rows[0]["LinkUrl"].ToString();
				model.AdRemark=ds.Tables[0].Rows[0]["AdRemark"].ToString();
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,IsLock,AddTime ");
			strSql.Append(" FROM Adbanner ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,Aid,Title,StartTime,EndTime,AdUrl,LinkUrl,AdRemark,IsLock,AddTime ");
            strSql.Append(" FROM Adbanner ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
