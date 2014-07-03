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
    /// Provides data access methods for the UserProfile database table
    /// </summary>
    /// <remarks>
    public partial class UserProfile
    {
        
        /// <summary>
        /// Creates a new UserProfile record
        /// </summary>
        public static int Create(UserProfileDO DO)
        {
            SqlParameter _UserName = new SqlParameter("UserName", SqlDbType.NVarChar);
            
            _UserName.Value = DO.UserName;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserName
            };

            return DataCommon.ExecuteScalar("[dbo].[UserProfile_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a UserProfile record and returns the number of records affected
        /// </summary>
        public static int Update(UserProfileDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _UserName = new SqlParameter("UserName", SqlDbType.NVarChar);
            
            _UserId.Value = DO.UserId;
            _UserName.Value = DO.UserName;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _UserName
            };

            return DataCommon.ExecuteScalar("[dbo].[UserProfile_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a UserProfile record
        /// </summary>
        public static int Delete(UserProfileDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            
            _UserId.Value = DO.UserId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId
            };

            return DataCommon.ExecuteScalar("[dbo].[UserProfile_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all UserProfile records
        /// </summary>
        public static UserProfileDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[UserProfile_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<UserProfileDO> objs = new List<UserProfileDO>();
            
            while(sr.Read()){

                UserProfileDO obj = new UserProfileDO();
                
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.UserName = sr.GetString(sr.GetOrdinal("UserName"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects UserProfile records by PK
        /// </summary>
        public static UserProfileDO[] GetByPK(Int32 UserId)
        {

            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
			
            _UserId.Value = UserId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _UserId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[UserProfile_GetByPK]", _params, "dbo");

            List<UserProfileDO> objs = new List<UserProfileDO>();
			
            while(sr.Read())
            {
                UserProfileDO obj = new UserProfileDO();
				
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.UserName = sr.GetString(sr.GetOrdinal("UserName"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects UserProfile records by UQ__UserProf__C9F28456684D5839
        /// </summary>
        public static UserProfileDO[] GetByUQ__UserProf__C9F28456684D5839(String UserName)
        {

            SqlParameter _UserName = new SqlParameter("UserName", SqlDbType.NVarChar);
			
            _UserName.Value = UserName;
			
            SqlParameter[] _params = new SqlParameter[] {
                _UserName
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[UserProfile_GetByUQ__UserProf__C9F28456684D5839]", _params, "dbo");

            List<UserProfileDO> objs = new List<UserProfileDO>();
			
            while(sr.Read())
            {
                UserProfileDO obj = new UserProfileDO();
				
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.UserName = sr.GetString(sr.GetOrdinal("UserName"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the UserProfile Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "UserProfile");
        }

    }
}