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
    /// Provides data access methods for the webpages_UsersInRoles database table
    /// </summary>
    /// <remarks>
    public partial class webpages_UsersInRoles
    {
        
        /// <summary>
        /// Creates a new webpages_UsersInRoles record
        /// </summary>
        public static void Create(webpages_UsersInRolesDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
            
            _UserId.Value = DO.UserId;
            _RoleId.Value = DO.RoleId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _RoleId
            };

            DataCommon.ExecuteNonQuery("[dbo].[webpages_UsersInRoles_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a webpages_UsersInRoles record and returns the number of records affected
        /// </summary>
        public static int Update(webpages_UsersInRolesDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
            
            _UserId.Value = DO.UserId;
            _RoleId.Value = DO.RoleId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _RoleId
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_UsersInRoles_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a webpages_UsersInRoles record
        /// </summary>
        public static int Delete(webpages_UsersInRolesDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
            
            _UserId.Value = DO.UserId;
            _RoleId.Value = DO.RoleId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _RoleId
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_UsersInRoles_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all webpages_UsersInRoles records
        /// </summary>
        public static webpages_UsersInRolesDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_UsersInRoles_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<webpages_UsersInRolesDO> objs = new List<webpages_UsersInRolesDO>();
            
            while(sr.Read()){

                webpages_UsersInRolesDO obj = new webpages_UsersInRolesDO();
                
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.RoleId = sr.GetInt32(sr.GetOrdinal("RoleId"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects webpages_UsersInRoles records by PK
        /// </summary>
        public static webpages_UsersInRolesDO[] GetByPK(Int32 UserId,
 Int32 RoleId)
        {

            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _RoleId = new SqlParameter("RoleId", SqlDbType.Int);
			
            _UserId.Value = UserId;
            _RoleId.Value = RoleId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _RoleId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_UsersInRoles_GetByPK]", _params, "dbo");

            List<webpages_UsersInRolesDO> objs = new List<webpages_UsersInRolesDO>();
			
            while(sr.Read())
            {
                webpages_UsersInRolesDO obj = new webpages_UsersInRolesDO();
				
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.RoleId = sr.GetInt32(sr.GetOrdinal("RoleId"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the webpages_UsersInRoles Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "webpages_UsersInRoles");
        }

    }
}