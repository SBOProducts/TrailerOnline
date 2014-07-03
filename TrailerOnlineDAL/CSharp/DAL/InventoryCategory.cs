// CREATED BY: Nathan Townsend
// CREATED DATE: 7/3/2014
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
    /// Provides data access methods for the InventoryCategory database table
    /// </summary>
    /// <remarks>
    public partial class InventoryCategory
    {
        
        /// <summary>
        /// Creates a new InventoryCategory record
        /// </summary>
        public static int Create(InventoryCategoryDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _MenuName = new SqlParameter("MenuName", SqlDbType.VarChar);
            SqlParameter _PageTitle = new SqlParameter("PageTitle", SqlDbType.VarChar);
            SqlParameter _DisplayToPublic = new SqlParameter("DisplayToPublic", SqlDbType.Bit);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            
            _TenantId.Value = DO.TenantId;
            _MenuName.Value = DO.MenuName;
            _PageTitle.Value = DO.PageTitle;
            _DisplayToPublic.Value = DO.DisplayToPublic;
            _HtmlId.Value = DO.HtmlId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _MenuName,
                _PageTitle,
                _DisplayToPublic,
                _HtmlId
            };

            return DataCommon.ExecuteScalar("[dbo].[InventoryCategory_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a InventoryCategory record and returns the number of records affected
        /// </summary>
        public static int Update(InventoryCategoryDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            SqlParameter _MenuName = new SqlParameter("MenuName", SqlDbType.VarChar);
            SqlParameter _PageTitle = new SqlParameter("PageTitle", SqlDbType.VarChar);
            SqlParameter _DisplayToPublic = new SqlParameter("DisplayToPublic", SqlDbType.Bit);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            
            _TenantId.Value = DO.TenantId;
            _CategoryId.Value = DO.CategoryId;
            _MenuName.Value = DO.MenuName;
            _PageTitle.Value = DO.PageTitle;
            _DisplayToPublic.Value = DO.DisplayToPublic;
            _HtmlId.Value = DO.HtmlId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId,
                _MenuName,
                _PageTitle,
                _DisplayToPublic,
                _HtmlId
            };

            return DataCommon.ExecuteScalar("[dbo].[InventoryCategory_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a InventoryCategory record
        /// </summary>
        public static int Delete(InventoryCategoryDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _CategoryId = new SqlParameter("CategoryId", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            _CategoryId.Value = DO.CategoryId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _CategoryId
            };

            return DataCommon.ExecuteScalar("[dbo].[InventoryCategory_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all InventoryCategory records
        /// </summary>
        public static InventoryCategoryDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[InventoryCategory_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<InventoryCategoryDO> objs = new List<InventoryCategoryDO>();
            
            while(sr.Read()){

                InventoryCategoryDO obj = new InventoryCategoryDO();
                
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects InventoryCategory records by InventoryCategory_TenantId
        /// </summary>
        public static InventoryCategoryDO[] GetByInventoryCategory_TenantId(Int32 TenantId)
        {

            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
			
            _TenantId.Value = TenantId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[InventoryCategory_GetByInventoryCategory_TenantId]", _params, "dbo");

            List<InventoryCategoryDO> objs = new List<InventoryCategoryDO>();
			
            while(sr.Read())
            {
                InventoryCategoryDO obj = new InventoryCategoryDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects InventoryCategory records by PK
        /// </summary>
        public static InventoryCategoryDO[] GetByPK(Int32 TenantId,
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

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[InventoryCategory_GetByPK]", _params, "dbo");

            List<InventoryCategoryDO> objs = new List<InventoryCategoryDO>();
			
            while(sr.Read())
            {
                InventoryCategoryDO obj = new InventoryCategoryDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.CategoryId = sr.GetInt32(sr.GetOrdinal("CategoryId"));
                obj.MenuName = sr.GetString(sr.GetOrdinal("MenuName"));
                obj.PageTitle = sr.GetString(sr.GetOrdinal("PageTitle"));
                obj.DisplayToPublic = sr.GetBoolean(sr.GetOrdinal("DisplayToPublic"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the InventoryCategory Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "InventoryCategory");
        }

    }
}