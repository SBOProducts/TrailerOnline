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
    /// Provides data access methods for the webpages_OAuthMembership database table
    /// </summary>
    /// <remarks>
    public partial class webpages_OAuthMembership
    {
        
        /// <summary>
        /// Creates a new webpages_OAuthMembership record
        /// </summary>
        public static void Create(webpages_OAuthMembershipDO DO)
        {
            SqlParameter _Provider = new SqlParameter("Provider", SqlDbType.NVarChar);
            SqlParameter _ProviderUserId = new SqlParameter("ProviderUserId", SqlDbType.NVarChar);
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            
            _Provider.Value = DO.Provider;
            _ProviderUserId.Value = DO.ProviderUserId;
            _UserId.Value = DO.UserId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Provider,
                _ProviderUserId,
                _UserId
            };

            DataCommon.ExecuteNonQuery("[dbo].[webpages_OAuthMembership_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a webpages_OAuthMembership record and returns the number of records affected
        /// </summary>
        public static int Update(webpages_OAuthMembershipDO DO)
        {
            SqlParameter _Provider = new SqlParameter("Provider", SqlDbType.NVarChar);
            SqlParameter _ProviderUserId = new SqlParameter("ProviderUserId", SqlDbType.NVarChar);
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            
            _Provider.Value = DO.Provider;
            _ProviderUserId.Value = DO.ProviderUserId;
            _UserId.Value = DO.UserId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Provider,
                _ProviderUserId,
                _UserId
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_OAuthMembership_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a webpages_OAuthMembership record
        /// </summary>
        public static int Delete(webpages_OAuthMembershipDO DO)
        {
            SqlParameter _Provider = new SqlParameter("Provider", SqlDbType.NVarChar);
            SqlParameter _ProviderUserId = new SqlParameter("ProviderUserId", SqlDbType.NVarChar);
            
            _Provider.Value = DO.Provider;
            _ProviderUserId.Value = DO.ProviderUserId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Provider,
                _ProviderUserId
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_OAuthMembership_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all webpages_OAuthMembership records
        /// </summary>
        public static webpages_OAuthMembershipDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_OAuthMembership_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<webpages_OAuthMembershipDO> objs = new List<webpages_OAuthMembershipDO>();
            
            while(sr.Read()){

                webpages_OAuthMembershipDO obj = new webpages_OAuthMembershipDO();
                
                obj.Provider = sr.GetString(sr.GetOrdinal("Provider"));
                obj.ProviderUserId = sr.GetString(sr.GetOrdinal("ProviderUserId"));
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects webpages_OAuthMembership records by PK
        /// </summary>
        public static webpages_OAuthMembershipDO[] GetByPK(String Provider,
 String ProviderUserId)
        {

            SqlParameter _Provider = new SqlParameter("Provider", SqlDbType.NVarChar);
            SqlParameter _ProviderUserId = new SqlParameter("ProviderUserId", SqlDbType.NVarChar);
			
            _Provider.Value = Provider;
            _ProviderUserId.Value = ProviderUserId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Provider,
                _ProviderUserId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_OAuthMembership_GetByPK]", _params, "dbo");

            List<webpages_OAuthMembershipDO> objs = new List<webpages_OAuthMembershipDO>();
			
            while(sr.Read())
            {
                webpages_OAuthMembershipDO obj = new webpages_OAuthMembershipDO();
				
                obj.Provider = sr.GetString(sr.GetOrdinal("Provider"));
                obj.ProviderUserId = sr.GetString(sr.GetOrdinal("ProviderUserId"));
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the webpages_OAuthMembership Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "webpages_OAuthMembership");
        }

    }
}