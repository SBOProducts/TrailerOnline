// CREATED BY: Nathan Townsend
// CREATED DATE: 7/25/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using TrailerOnline.DAL.DAL;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.DAL.DAL.dbo
{
    /// <summary>
    /// Provides data access methods for the Category database table
    /// </summary>
    /// <remarks>
    public partial class Category
    {
        
        /// <summary>
        /// Creates a new Category record
        /// </summary>
        public static int Create(CategoryDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _MenuName = new SqlParameter("MenuName", SqlDbType.VarChar);
            SqlParameter _PageTitle = new SqlParameter("PageTitle", SqlDbType.VarChar);
            SqlParameter _DisplayToPublic = new SqlParameter("DisplayToPublic", SqlDbType.Bit);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            SqlParameter _Sequence = new SqlParameter("Sequence", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            _MenuName.Value = DO.MenuName;
            _PageTitle.Value = DO.PageTitle;
            _DisplayToPublic.Value = DO.DisplayToPublic;
            _HtmlId.Value = DO.HtmlId;
            _Sequence.Value = DO.Sequence;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _MenuName,
                _PageTitle,
                _DisplayToPublic,
                _HtmlId,
                _Sequence
            };

            return DataCommon.ExecuteScalar("[dbo].[Category_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a Category record and returns the number of records affected
        /// </summary>
        public static int Update(CategoryDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            SqlParameter _MenuName = new SqlParameter("MenuName", SqlDbType.VarChar);
            SqlParameter _PageTitle = new SqlParameter("PageTitle", SqlDbType.VarChar);
            SqlParameter _DisplayToPublic = new SqlParameter("DisplayToPublic", SqlDbType.Bit);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            SqlParameter _Sequence = new SqlParameter("Sequence", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            _CategoryId.Value = DO.CategoryId;
            _MenuName.Value = DO.MenuName;
            _PageTitle.Value = DO.PageTitle;
            _DisplayToPublic.Value = DO.DisplayToPublic;
            _HtmlId.Value = DO.HtmlId;
            _Sequence.Value = DO.Sequence;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId,
                _MenuName,
                _PageTitle,
                _DisplayToPublic,
                _HtmlId,
                _Sequence
            };

            return DataCommon.ExecuteScalar("[dbo].[Category_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a Category record
        /// </summary>
        public static int Delete(CategoryDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            _CategoryId.Value = DO.CategoryId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId
            };

            return DataCommon.ExecuteScalar("[dbo].[Category_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all Category records
        /// </summary>
        public static CategoryDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Category_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<CategoryDO> objs = new List<CategoryDO>();
            
            while(sr.Read()){

                CategoryDO obj = new CategoryDO();
                
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                obj.Sequence = sr.GetInt32(sr.GetOrdinal("Sequence"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Category records by Category_CategoryId
        /// </summary>
        public static CategoryDO[] GetByCategory_CategoryId(Int32 CategoryId)
        {

            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
			
            _CategoryId.Value = CategoryId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _CategoryId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Category_GetByCategory_CategoryId]", _params, "dbo");

            List<CategoryDO> objs = new List<CategoryDO>();
			
            while(sr.Read())
            {
                CategoryDO obj = new CategoryDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                obj.Sequence = sr.GetInt32(sr.GetOrdinal("Sequence"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Category records by Category_TenantId
        /// </summary>
        public static CategoryDO[] GetByCategory_TenantId(Int32 TenantId)
        {

            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
			
            _TenantId.Value = TenantId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Category_GetByCategory_TenantId]", _params, "dbo");

            List<CategoryDO> objs = new List<CategoryDO>();
			
            while(sr.Read())
            {
                CategoryDO obj = new CategoryDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                obj.Sequence = sr.GetInt32(sr.GetOrdinal("Sequence"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Category records by PK
        /// </summary>
        public static CategoryDO[] GetByPK(Int32 TenantId,
 Int32 CategoryId)
        {

            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
			
            _TenantId.Value = TenantId;
            _CategoryId.Value = CategoryId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Category_GetByPK]", _params, "dbo");

            List<CategoryDO> objs = new List<CategoryDO>();
			
            while(sr.Read())
            {
                CategoryDO obj = new CategoryDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                obj.Sequence = sr.GetInt32(sr.GetOrdinal("Sequence"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Category Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "Category");
        }

    }
}