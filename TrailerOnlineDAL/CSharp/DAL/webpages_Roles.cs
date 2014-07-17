// CREATED BY: Nathan Townsend
// CREATED DATE: 7/17/2014
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
    /// Provides data access methods for the webpages_Roles database table
    /// </summary>
    /// <remarks>
    public partial class webpages_Roles
    {
        
        /// <summary>
        /// Creates a new webpages_Roles record
        /// </summary>
        public static int Create(webpages_RolesDO DO)
        {
            SqlParameter _RoleName = new SqlParameter("RoleName", SqlDbType.NVarChar);
            
            _RoleName.Value = DO.RoleName;
            
            SqlParameter[] _params = new SqlParameter[] {
                _RoleName
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_Roles_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a webpages_Roles record and returns the number of records affected
        /// </summary>
        public static int Update(webpages_RolesDO DO)
        {
            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
            SqlParameter _RoleName = new SqlParameter("RoleName", SqlDbType.NVarChar);
            
            _RoleId.Value = DO.RoleId;
            _RoleName.Value = DO.RoleName;
            
            SqlParameter[] _params = new SqlParameter[] {
                _RoleId,
                _RoleName
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_Roles_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a webpages_Roles record
        /// </summary>
        public static int Delete(webpages_RolesDO DO)
        {
            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
            
            _RoleId.Value = DO.RoleId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _RoleId
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_Roles_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all webpages_Roles records
        /// </summary>
        public static webpages_RolesDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_Roles_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<webpages_RolesDO> objs = new List<webpages_RolesDO>();
            
            while(sr.Read()){

                webpages_RolesDO obj = new webpages_RolesDO();
                
                obj.RoleId = sr.GetInt32(sr.GetOrdinal("RoleId"));
                obj.RoleName = sr.GetString(sr.GetOrdinal("RoleName"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects webpages_Roles records by PK
        /// </summary>
        public static webpages_RolesDO[] GetByPK(Int32 RoleId)
        {

            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
			
            _RoleId.Value = RoleId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _RoleId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_Roles_GetByPK]", _params, "dbo");

            List<webpages_RolesDO> objs = new List<webpages_RolesDO>();
			
            while(sr.Read())
            {
                webpages_RolesDO obj = new webpages_RolesDO();
				
                obj.RoleId = sr.GetInt32(sr.GetOrdinal("RoleId"));
                obj.RoleName = sr.GetString(sr.GetOrdinal("RoleName"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects webpages_Roles records by UQ__webpages__8A2B61609622F04F
        /// </summary>
        public static webpages_RolesDO[] GetByUQ__webpages__8A2B61609622F04F(String RoleName)
        {

            SqlParameter _RoleName = new SqlParameter("RoleName", SqlDbType.NVarChar);
			
            _RoleName.Value = RoleName;
			
            SqlParameter[] _params = new SqlParameter[] {
                _RoleName
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_Roles_GetByUQ__webpages__8A2B61609622F04F]", _params, "dbo");

            List<webpages_RolesDO> objs = new List<webpages_RolesDO>();
			
            while(sr.Read())
            {
                webpages_RolesDO obj = new webpages_RolesDO();
				
                obj.RoleId = sr.GetInt32(sr.GetOrdinal("RoleId"));
                obj.RoleName = sr.GetString(sr.GetOrdinal("RoleName"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the webpages_Roles Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "webpages_Roles");
        }

    }
}