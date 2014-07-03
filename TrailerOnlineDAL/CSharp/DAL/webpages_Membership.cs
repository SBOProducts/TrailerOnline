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
    /// Provides data access methods for the webpages_Membership database table
    /// </summary>
    /// <remarks>
    public partial class webpages_Membership
    {
        
        /// <summary>
        /// Creates a new webpages_Membership record
        /// </summary>
        public static void Create(webpages_MembershipDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _CreateDate = new SqlParameter("CreateDate", SqlDbType.DateTime);
            SqlParameter _ConfirmationToken = new SqlParameter("ConfirmationToken", SqlDbType.NVarChar);
            SqlParameter _IsConfirmed = new SqlParameter("IsConfirmed", SqlDbType.Bit);
            SqlParameter _LastPasswordFailureDate = new SqlParameter("LastPasswordFailureDate", SqlDbType.DateTime);
            SqlParameter _PasswordFailuresSinceLastSuccess = new SqlParameter("PasswordFailuresSinceLastSuccess", SqlDbType.Int);
            SqlParameter _Password = new SqlParameter("Password", SqlDbType.NVarChar);
            SqlParameter _PasswordChangedDate = new SqlParameter("PasswordChangedDate", SqlDbType.DateTime);
            SqlParameter _PasswordSalt = new SqlParameter("PasswordSalt", SqlDbType.NVarChar);
            SqlParameter _PasswordVerificationToken = new SqlParameter("PasswordVerificationToken", SqlDbType.NVarChar);
            SqlParameter _PasswordVerificationTokenExpirationDate = new SqlParameter("PasswordVerificationTokenExpirationDate", SqlDbType.DateTime);
            
            _UserId.Value = DO.UserId;
            _CreateDate.Value = DO.CreateDate;
            _ConfirmationToken.Value = DO.ConfirmationToken;
            _IsConfirmed.Value = DO.IsConfirmed;
            _LastPasswordFailureDate.Value = DO.LastPasswordFailureDate;
            _PasswordFailuresSinceLastSuccess.Value = DO.PasswordFailuresSinceLastSuccess;
            _Password.Value = DO.Password;
            _PasswordChangedDate.Value = DO.PasswordChangedDate;
            _PasswordSalt.Value = DO.PasswordSalt;
            _PasswordVerificationToken.Value = DO.PasswordVerificationToken;
            _PasswordVerificationTokenExpirationDate.Value = DO.PasswordVerificationTokenExpirationDate;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _CreateDate,
                _ConfirmationToken,
                _IsConfirmed,
                _LastPasswordFailureDate,
                _PasswordFailuresSinceLastSuccess,
                _Password,
                _PasswordChangedDate,
                _PasswordSalt,
                _PasswordVerificationToken,
                _PasswordVerificationTokenExpirationDate
            };

            DataCommon.ExecuteNonQuery("[dbo].[webpages_Membership_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a webpages_Membership record and returns the number of records affected
        /// </summary>
        public static int Update(webpages_MembershipDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            SqlParameter _CreateDate = new SqlParameter("CreateDate", SqlDbType.DateTime);
            SqlParameter _ConfirmationToken = new SqlParameter("ConfirmationToken", SqlDbType.NVarChar);
            SqlParameter _IsConfirmed = new SqlParameter("IsConfirmed", SqlDbType.Bit);
            SqlParameter _LastPasswordFailureDate = new SqlParameter("LastPasswordFailureDate", SqlDbType.DateTime);
            SqlParameter _PasswordFailuresSinceLastSuccess = new SqlParameter("PasswordFailuresSinceLastSuccess", SqlDbType.Int);
            SqlParameter _Password = new SqlParameter("Password", SqlDbType.NVarChar);
            SqlParameter _PasswordChangedDate = new SqlParameter("PasswordChangedDate", SqlDbType.DateTime);
            SqlParameter _PasswordSalt = new SqlParameter("PasswordSalt", SqlDbType.NVarChar);
            SqlParameter _PasswordVerificationToken = new SqlParameter("PasswordVerificationToken", SqlDbType.NVarChar);
            SqlParameter _PasswordVerificationTokenExpirationDate = new SqlParameter("PasswordVerificationTokenExpirationDate", SqlDbType.DateTime);
            
            _UserId.Value = DO.UserId;
            _CreateDate.Value = DO.CreateDate;
            _ConfirmationToken.Value = DO.ConfirmationToken;
            _IsConfirmed.Value = DO.IsConfirmed;
            _LastPasswordFailureDate.Value = DO.LastPasswordFailureDate;
            _PasswordFailuresSinceLastSuccess.Value = DO.PasswordFailuresSinceLastSuccess;
            _Password.Value = DO.Password;
            _PasswordChangedDate.Value = DO.PasswordChangedDate;
            _PasswordSalt.Value = DO.PasswordSalt;
            _PasswordVerificationToken.Value = DO.PasswordVerificationToken;
            _PasswordVerificationTokenExpirationDate.Value = DO.PasswordVerificationTokenExpirationDate;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId,
                _CreateDate,
                _ConfirmationToken,
                _IsConfirmed,
                _LastPasswordFailureDate,
                _PasswordFailuresSinceLastSuccess,
                _Password,
                _PasswordChangedDate,
                _PasswordSalt,
                _PasswordVerificationToken,
                _PasswordVerificationTokenExpirationDate
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_Membership_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a webpages_Membership record
        /// </summary>
        public static int Delete(webpages_MembershipDO DO)
        {
            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
            
            _UserId.Value = DO.UserId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _UserId
            };

            return DataCommon.ExecuteScalar("[dbo].[webpages_Membership_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all webpages_Membership records
        /// </summary>
        public static webpages_MembershipDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_Membership_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<webpages_MembershipDO> objs = new List<webpages_MembershipDO>();
            
            while(sr.Read()){

                webpages_MembershipDO obj = new webpages_MembershipDO();
                
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.PasswordFailuresSinceLastSuccess = sr.GetInt32(sr.GetOrdinal("PasswordFailuresSinceLastSuccess"));
                obj.Password = sr.GetString(sr.GetOrdinal("Password"));
                obj.PasswordSalt = sr.GetString(sr.GetOrdinal("PasswordSalt"));
                if (sr.IsDBNull(sr.GetOrdinal("CreateDate"))) { obj.CreateDate = null; } else { obj.CreateDate = sr.GetDateTime(sr.GetOrdinal("CreateDate")); }
                if (sr.IsDBNull(sr.GetOrdinal("ConfirmationToken"))) { obj.ConfirmationToken = null; } else { obj.ConfirmationToken = sr.GetString(sr.GetOrdinal("ConfirmationToken")); }
                if (sr.IsDBNull(sr.GetOrdinal("IsConfirmed"))) { obj.IsConfirmed = null; } else { obj.IsConfirmed = sr.GetBoolean(sr.GetOrdinal("IsConfirmed")); }
                if (sr.IsDBNull(sr.GetOrdinal("LastPasswordFailureDate"))) { obj.LastPasswordFailureDate = null; } else { obj.LastPasswordFailureDate = sr.GetDateTime(sr.GetOrdinal("LastPasswordFailureDate")); }
                if (sr.IsDBNull(sr.GetOrdinal("PasswordChangedDate"))) { obj.PasswordChangedDate = null; } else { obj.PasswordChangedDate = sr.GetDateTime(sr.GetOrdinal("PasswordChangedDate")); }
                if (sr.IsDBNull(sr.GetOrdinal("PasswordVerificationToken"))) { obj.PasswordVerificationToken = null; } else { obj.PasswordVerificationToken = sr.GetString(sr.GetOrdinal("PasswordVerificationToken")); }
                if (sr.IsDBNull(sr.GetOrdinal("PasswordVerificationTokenExpirationDate"))) { obj.PasswordVerificationTokenExpirationDate = null; } else { obj.PasswordVerificationTokenExpirationDate = sr.GetDateTime(sr.GetOrdinal("PasswordVerificationTokenExpirationDate")); }


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects webpages_Membership records by PK
        /// </summary>
        public static webpages_MembershipDO[] GetByPK(Int32 UserId)
        {

            SqlParameter _UserId = new SqlParameter("UserId", SqlDbType.Int);
			
            _UserId.Value = UserId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _UserId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[webpages_Membership_GetByPK]", _params, "dbo");

            List<webpages_MembershipDO> objs = new List<webpages_MembershipDO>();
			
            while(sr.Read())
            {
                webpages_MembershipDO obj = new webpages_MembershipDO();
				
                obj.UserId = sr.GetInt32(sr.GetOrdinal("UserId"));
                obj.PasswordFailuresSinceLastSuccess = sr.GetInt32(sr.GetOrdinal("PasswordFailuresSinceLastSuccess"));
                obj.Password = sr.GetString(sr.GetOrdinal("Password"));
                obj.PasswordSalt = sr.GetString(sr.GetOrdinal("PasswordSalt"));
                if (sr.IsDBNull(sr.GetOrdinal("CreateDate"))) { obj.CreateDate = null; } else { obj.CreateDate = sr.GetDateTime(sr.GetOrdinal("CreateDate")); }
                if (sr.IsDBNull(sr.GetOrdinal("ConfirmationToken"))) { obj.ConfirmationToken = null; } else { obj.ConfirmationToken = sr.GetString(sr.GetOrdinal("ConfirmationToken")); }
                if (sr.IsDBNull(sr.GetOrdinal("IsConfirmed"))) { obj.IsConfirmed = null; } else { obj.IsConfirmed = sr.GetBoolean(sr.GetOrdinal("IsConfirmed")); }
                if (sr.IsDBNull(sr.GetOrdinal("LastPasswordFailureDate"))) { obj.LastPasswordFailureDate = null; } else { obj.LastPasswordFailureDate = sr.GetDateTime(sr.GetOrdinal("LastPasswordFailureDate")); }
                if (sr.IsDBNull(sr.GetOrdinal("PasswordChangedDate"))) { obj.PasswordChangedDate = null; } else { obj.PasswordChangedDate = sr.GetDateTime(sr.GetOrdinal("PasswordChangedDate")); }
                if (sr.IsDBNull(sr.GetOrdinal("PasswordVerificationToken"))) { obj.PasswordVerificationToken = null; } else { obj.PasswordVerificationToken = sr.GetString(sr.GetOrdinal("PasswordVerificationToken")); }
                if (sr.IsDBNull(sr.GetOrdinal("PasswordVerificationTokenExpirationDate"))) { obj.PasswordVerificationTokenExpirationDate = null; } else { obj.PasswordVerificationTokenExpirationDate = sr.GetDateTime(sr.GetOrdinal("PasswordVerificationTokenExpirationDate")); }

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the webpages_Membership Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "webpages_Membership");
        }

    }
}