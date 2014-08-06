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
    /// Provides data access methods for the Html database table
    /// </summary>
    /// <remarks>
    public partial class Html
    {
        
        /// <summary>
        /// Creates a new Html record
        /// </summary>
        public static void Create(HtmlDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            SqlParameter _Content = new SqlParameter("Content", SqlDbType.VarChar);
            
            _TenantId.Value = DO.TenantId;
            _HtmlId.Value = DO.HtmlId;
            _Content.Value = DO.Content;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _HtmlId,
                _Content
            };

            DataCommon.ExecuteNonQuery("[dbo].[Html_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a Html record and returns the number of records affected
        /// </summary>
        public static int Update(HtmlDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            SqlParameter _Content = new SqlParameter("Content", SqlDbType.VarChar);
            
            _TenantId.Value = DO.TenantId;
            _HtmlId.Value = DO.HtmlId;
            _Content.Value = DO.Content;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _HtmlId,
                _Content
            };

            return DataCommon.ExecuteScalar("[dbo].[Html_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a Html record
        /// </summary>
        public static int Delete(HtmlDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
            
            _TenantId.Value = DO.TenantId;
            _HtmlId.Value = DO.HtmlId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _HtmlId
            };

            return DataCommon.ExecuteScalar("[dbo].[Html_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all Html records
        /// </summary>
        public static HtmlDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Html_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<HtmlDO> objs = new List<HtmlDO>();
            
            while(sr.Read()){

                HtmlDO obj = new HtmlDO();
                
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                obj.Content = sr.GetString(sr.GetOrdinal("Content"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Html records by PK
        /// </summary>
        public static HtmlDO[] GetByPK(Int32 TenantId,
 Guid HtmlId)
        {

            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _HtmlId = new SqlParameter("HtmlId", SqlDbType.UniqueIdentifier);
			
            _TenantId.Value = TenantId;
            _HtmlId.Value = HtmlId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _HtmlId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Html_GetByPK]", _params, "dbo");

            List<HtmlDO> objs = new List<HtmlDO>();
			
            while(sr.Read())
            {
                HtmlDO obj = new HtmlDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.HtmlId = sr.GetGuid(sr.GetOrdinal("HtmlId"));
                obj.Content = sr.GetString(sr.GetOrdinal("Content"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Html Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "Html");
        }

    }
}