using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.DAL.DAL.dbo;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL.MultiTenancy
{
    /// <summary>
    /// Occurs when a requested tenant is not found
    /// </summary>
    public class TenantNotFoundException : Exception
    {
        /// <summary>
        /// Tenanat could not be found by id
        /// </summary>
        /// <param name="TenantId"></param>
        public TenantNotFoundException(int TenantId) : base(string.Format("The Tenant with Id={0} could not be found", TenantId)) { }
        

        /// <summary>
        /// Tenanat could not be found by name
        /// </summary>
        /// <param name="Name"></param>
        public TenantNotFoundException(string Name) : base(string.Format("The Tenant with Name='{0}' could not be found", Name)) { }

    }


    /// <summary>
    /// Occurs when attempting to create a new tenant with the same name of an existing tenant
    /// </summary>
    public class DuplicateTenantException : Exception
    {
        public DuplicateTenantException(string Name) : base(string.Format("A Tenant with the name '{0}' already exists. Tenant names must be unique.", Name)) { }
    }


    /// <summary>
    /// Provides a robust system for managing tenants in the system
    /// </summary>
    public class TenantBLL
    {

        #region Private Fields / Properties

        /// <summary>
        /// an internal instance of the tenants
        /// </summary>
        private static List<TenantBO> _tenants = null;


        /// <summary>
        /// A list of all tenants in the system
        /// </summary>
        private static List<TenantBO> Tenants
        {
            get
            {
                // load all tenant records
                if (_tenants == null)
                {
                    _tenants = new List<TenantBO>();
                    foreach (TenantDO obj in Tenant.GetAll())
                        _tenants.Add(GetTenantBO(obj));
                }

                return _tenants;
            }
        }


        /// <summary>
        /// returns a TenantBO from a TenantDO
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static TenantBO GetTenantBO(TenantDO data)
        {
            if (data == null)
                return null;

            return new TenantBO(data);
        }

        #endregion


        /// <summary>
        /// Get a tenant by Name or null if the tenant doesn't exist
        /// </summary>
        /// <param name="Name">The unique name of the tenant</param>
        /// <returns></returns>
        public static TenantBO GetTenant(string Name)
        {
            return Tenants.Where(t => t.NameLower == Name.ToLower()).FirstOrDefault();
        }


        /// <summary>
        /// Get a tenant by Id or null if the tenant doesn't exist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static TenantBO GetTenant(int Id)
        {
            return Tenants.Where(t => t.TenantId == Id).FirstOrDefault();
        }


        /// <summary>
        /// Creates a new tenant
        /// </summary>
        /// <param name="tenant">The new tenant object</param>
        /// <returns>
        /// The new tenant object with the database-generated id
        /// </returns>
        public static TenantBO Create(TenantBO tenant)
        {
            // tenants must be unique by name
            if (TenantExists(tenant.Name))
                throw new DuplicateTenantException(tenant.Name);

            // create the new record
            TenantDO obj = tenant.GetDataObject();
            obj.TenantId = Tenant.Create(obj);
            
            // get the business object and add to cache
            TenantBO bo = GetTenantBO(obj);
            Tenants.Add(bo);

            return bo;
        }


        /// <summary>
        /// Updates a tenant
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        public static TenantBO Update(TenantBO tenant)
        {
            
            // get the tenant from cache
            TenantBO obj = GetTenant(tenant.TenantId);

            // throw an exception if the tenant doesn't exist
            if (obj == null)
                throw new TenantNotFoundException(tenant.TenantId);

            // throw an exception if the name has changed to an already existing tenant name
            if (string.Compare(obj.Name, tenant.Name, true) != 0)
            {
                if (TenantExists(tenant.Name))
                    throw new DuplicateTenantException(tenant.Name);
            }

            // update the cached version
            obj = tenant;

            // update the database
            Tenant.Update(tenant.GetDataObject());

            return tenant;
        }


        /// <summary>
        /// Deltes a tenant
        /// </summary>
        /// <param name="tenant"></param>
        public static void Delete(TenantBO tenant)
        {
            Delete(tenant.TenantId);
        }


        /// <summary>
        /// Deletes a tenant
        /// </summary>
        /// <param name="tenantId"></param>
        public static void Delete(int tenantId)
        {
            // get the tenant object from the cache
            TenantBO obj = Tenants.Where(t => t.TenantId == tenantId).FirstOrDefault();

            // if it's not in the cache then ignore
            if (obj == null)
                return;

            // remove it from the cache
            Tenants.Remove(obj);

            // delete it from the database
            Tenant.Delete(obj.GetDataObject());
        }


        /// <summary>
        /// True if a tenant exists with the name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool TenantExists(string Name)
        {
            TenantBO obj = GetTenant(Name);
            return obj != null;
        }


        /// <summary>
        /// True if a tenant exists with the Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool TenantExists(int Id)
        {
            TenantBO obj = GetTenant(Id);
            return obj != null;
        }
        
    }
}
