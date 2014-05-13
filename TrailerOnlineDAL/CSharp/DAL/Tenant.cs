// CREATED BY: Nathan Townsend
// CREATED DATE: 5/13/2014
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
    /// Provides data access methods for the Tenant database table
    /// </summary>
    /// <remarks>
    public partial class Tenant
    {
        
        /// <summary>
        /// Creates a new Tenant record
        /// </summary>
        public static int Create(TenantDO DO)
        {
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Host = new SqlParameter("Host", SqlDbType.VarChar);
            SqlParameter _Title = new SqlParameter("Title", SqlDbType.VarChar);
            SqlParameter _Theme = new SqlParameter("Theme", SqlDbType.VarChar);
            SqlParameter _Layout = new SqlParameter("Layout", SqlDbType.VarChar);
            SqlParameter _Owner = new SqlParameter("Owner", SqlDbType.NVarChar);
            SqlParameter _Created = new SqlParameter("Created", SqlDbType.DateTime);
            
            _Name.Value = DO.Name;
            _Host.Value = DO.Host;
            _Title.Value = DO.Title;
            _Theme.Value = DO.Theme;
            _Layout.Value = DO.Layout;
            _Owner.Value = DO.Owner;
            _Created.Value = DO.Created;
            
            SqlParameter[] _params = new SqlParameter[] {
                _Name,
                _Host,
                _Title,
                _Theme,
                _Layout,
                _Owner,
                _Created
            };

            return DataCommon.ExecuteScalar("[dbo].[Tenant_Insert]", _params, "dbo");
            
        }


        /// <summary>
        /// Updates a Tenant record and returns the number of records affected
        /// </summary>
        public static int Update(TenantDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
            SqlParameter _Host = new SqlParameter("Host", SqlDbType.VarChar);
            SqlParameter _Title = new SqlParameter("Title", SqlDbType.VarChar);
            SqlParameter _Theme = new SqlParameter("Theme", SqlDbType.VarChar);
            SqlParameter _Layout = new SqlParameter("Layout", SqlDbType.VarChar);
            SqlParameter _Owner = new SqlParameter("Owner", SqlDbType.NVarChar);
            SqlParameter _Created = new SqlParameter("Created", SqlDbType.DateTime);
            
            _TenantId.Value = DO.TenantId;
            _Name.Value = DO.Name;
            _Host.Value = DO.Host;
            _Title.Value = DO.Title;
            _Theme.Value = DO.Theme;
            _Layout.Value = DO.Layout;
            _Owner.Value = DO.Owner;
            _Created.Value = DO.Created;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId,
                _Name,
                _Host,
                _Title,
                _Theme,
                _Layout,
                _Owner,
                _Created
            };

            return DataCommon.ExecuteScalar("[dbo].[Tenant_Update]", _params, "dbo");
        }


        /// <summary>
        /// Deletes a Tenant record
        /// </summary>
        public static int Delete(TenantDO DO)
        {
            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
            
            _TenantId.Value = DO.TenantId;
            
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId
            };

            return DataCommon.ExecuteScalar("[dbo].[Tenant_Delete]", _params, "dbo");
        }


        /// <summary>
        /// Gets all Tenant records
        /// </summary>
        public static TenantDO[] GetAll()
        {
            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Tenant_GetAll]", new SqlParameter[] { }, "dbo");
            
            List<TenantDO> objs = new List<TenantDO>();
            
            while(sr.Read()){

                TenantDO obj = new TenantDO();
                
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Host = sr.GetString(sr.GetOrdinal("Host"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Theme = sr.GetString(sr.GetOrdinal("Theme"));
                obj.Layout = sr.GetString(sr.GetOrdinal("Layout"));
                obj.Owner = sr.GetString(sr.GetOrdinal("Owner"));
                obj.Created = sr.GetDateTime(sr.GetOrdinal("Created"));
                


                objs.Add(obj);
            }

            return objs.ToArray();
        }


        /// <summary>
        /// Selects Tenant records by PK
        /// </summary>
        public static TenantDO[] GetByPK(Int32 TenantId)
        {

            SqlParameter _TenantId = new SqlParameter("TenantId", SqlDbType.Int);
			
            _TenantId.Value = TenantId;
			
            SqlParameter[] _params = new SqlParameter[] {
                _TenantId
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Tenant_GetByPK]", _params, "dbo");

            List<TenantDO> objs = new List<TenantDO>();
			
            while(sr.Read())
            {
                TenantDO obj = new TenantDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Host = sr.GetString(sr.GetOrdinal("Host"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Theme = sr.GetString(sr.GetOrdinal("Theme"));
                obj.Layout = sr.GetString(sr.GetOrdinal("Layout"));
                obj.Owner = sr.GetString(sr.GetOrdinal("Owner"));
                obj.Created = sr.GetDateTime(sr.GetOrdinal("Created"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Tenant records by Tenant_Host
        /// </summary>
        public static TenantDO[] GetByTenant_Host(String Host)
        {

            SqlParameter _Host = new SqlParameter("Host", SqlDbType.VarChar);
			
            _Host.Value = Host;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Host
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Tenant_GetByTenant_Host]", _params, "dbo");

            List<TenantDO> objs = new List<TenantDO>();
			
            while(sr.Read())
            {
                TenantDO obj = new TenantDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Host = sr.GetString(sr.GetOrdinal("Host"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Theme = sr.GetString(sr.GetOrdinal("Theme"));
                obj.Layout = sr.GetString(sr.GetOrdinal("Layout"));
                obj.Owner = sr.GetString(sr.GetOrdinal("Owner"));
                obj.Created = sr.GetDateTime(sr.GetOrdinal("Created"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Tenant records by Tenant_Name
        /// </summary>
        public static TenantDO[] GetByTenant_Name(String Name)
        {

            SqlParameter _Name = new SqlParameter("Name", SqlDbType.VarChar);
			
            _Name.Value = Name;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Name
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Tenant_GetByTenant_Name]", _params, "dbo");

            List<TenantDO> objs = new List<TenantDO>();
			
            while(sr.Read())
            {
                TenantDO obj = new TenantDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Host = sr.GetString(sr.GetOrdinal("Host"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Theme = sr.GetString(sr.GetOrdinal("Theme"));
                obj.Layout = sr.GetString(sr.GetOrdinal("Layout"));
                obj.Owner = sr.GetString(sr.GetOrdinal("Owner"));
                obj.Created = sr.GetDateTime(sr.GetOrdinal("Created"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }

/// <summary>
        /// Selects Tenant records by Tenant_Owner
        /// </summary>
        public static TenantDO[] GetByTenant_Owner(String Owner)
        {

            SqlParameter _Owner = new SqlParameter("Owner", SqlDbType.NVarChar);
			
            _Owner.Value = Owner;
			
            SqlParameter[] _params = new SqlParameter[] {
                _Owner
            };

            SafeReader sr = DataCommon.ExecuteSafeReader("[dbo].[Tenant_GetByTenant_Owner]", _params, "dbo");

            List<TenantDO> objs = new List<TenantDO>();
			
            while(sr.Read())
            {
                TenantDO obj = new TenantDO();
				
                obj.TenantId = sr.GetInt32(sr.GetOrdinal("TenantId"));
                obj.Name = sr.GetString(sr.GetOrdinal("Name"));
                obj.Host = sr.GetString(sr.GetOrdinal("Host"));
                obj.Title = sr.GetString(sr.GetOrdinal("Title"));
                obj.Theme = sr.GetString(sr.GetOrdinal("Theme"));
                obj.Layout = sr.GetString(sr.GetOrdinal("Layout"));
                obj.Owner = sr.GetString(sr.GetOrdinal("Owner"));
                obj.Created = sr.GetDateTime(sr.GetOrdinal("Created"));
                

                objs.Add(obj);
            }

            return objs.ToArray();
        }




        /// <summary>
        /// Truncates the Tenant Table
        /// </summary>
        public static void Truncate()
        {
            DataCommon.TruncateTable("dbo", "Tenant");
        }

    }
}