using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        #region Defaults

        /// <summary>
        /// The Host name of the system (not a customer domain)
        /// </summary>
        public static string DefaultHost { get { return ConfigurationManager.AppSettings["DefaultHost"]; } }

        /// <summary>
        /// The default layout
        /// </summary>
        public static string DefaultLayout { get { return ConfigurationManager.AppSettings["DefaultLayout"]; } }

        /// <summary>
        /// The default tenant website
        /// </summary>
        public static string DefaultTenantName { get { return ConfigurationManager.AppSettings["DefaultTenantName"]; } }

        /// <summary>
        /// The default tenant title (business name)
        /// </summary>
        public static string DefaultTenantTitle { get { return ConfigurationManager.AppSettings["DefaultTenantTitle"]; } }

        /// <summary>
        /// The default theme
        /// </summary>
        public static string DefaultTheme { get { return ConfigurationManager.AppSettings["DefaultTheme"]; } }

        /// <summary>
        /// The name used to refrerence tenants in the request.item.data collection
        /// </summary>
        private const string DataItemName = "TenantBO";

        #endregion


        /// <summary>
        /// Gets the tennant from the current http context
        /// </summary>
        /// <param name="Context"></param>
        /// <returns></returns>
        /// <remarks>
        /// Either returns the tenant from context data item or by determining it from the request (which adds it to the context data)
        /// </remarks>
        public static TenantBO GetTenant(HttpContext Context)
        {
            if (Context.Items.Contains(DataItemName))
                return (TenantBO)Context.Items[DataItemName];


            HttpRequest Request = Context.Request;
            string host = Request.Headers["Host"].ToString();
            string tenantName = GetTenantName(Request);

            TenantBO tenant = null;

            // is not a custom domain?
            if (string.Compare(host, DefaultHost, true) == 0)
            {
                // use the default tenant if none is specified
                if (string.IsNullOrEmpty(tenantName))
                    tenantName = DefaultTenantName;

                tenant = GetTenantByName(tenantName);
            }
            else
            {
                // is a custom domain
                tenant = GetTenantByHost(host);
            }

            if (tenant == null)
                tenant = new DefaultTenantBO();

            // add tenant to data items
            Context.Items.Add(DataItemName, tenant);

            return tenant;
            
        }




        /// <summary>
        /// Gets the tenant name from the current request
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        private static string GetTenantName(HttpRequest Request)
        {
            string[] parts = Request.Path.Split('/');
            
            if (parts.Length == 0)
                return null;
            
            return parts[1];

        }


        /// <summary>
        /// Get a tenant by Name or null if the tenant doesn't exist
        /// </summary>
        /// <param name="Name">The unique name of the tenant</param>
        /// <returns></returns>
        public static TenantBO GetTenantByName(string Name)
        {
            return Tenants.Where(t => t.NameLower == Name.ToLower()).FirstOrDefault();
        }


        /// <summary>
        /// Gets a tenant by host name
        /// </summary>
        /// <param name="Host"></param>
        /// <returns></returns>
        public static TenantBO GetTenantByHost(string Host)
        {
            return Tenants.Where(t => t.HostLower == Host.ToLower()).FirstOrDefault();
        }


        /// <summary>
        /// Get a tenant by Id or null if the tenant doesn't exist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static TenantBO GetTenantById(int Id)
        {
            return Tenants.Where(t => t.TenantId == Id).FirstOrDefault();
        }


        /// <summary>
        /// Gets a tenant by the Owenr or null if the tenant doesn't exist
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns></returns>
        public static TenantBO GetTenantByOwner(string Owner)
        {
            return Tenants.Where(t => t.Owner == Owner).FirstOrDefault();
        }


        /// <summary>
        /// Creates a new tenant in the system
        /// </summary>
        /// <param name="TenantName"></param>
        /// <param name="TenantTitle"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static TenantBO Create(string TenantName, string TenantTitle, string UserName, int ReferredByTenantId)
        {
            TenantBO bo = new TenantBO()
            {
                Created = DateTime.Now,
                Host = DefaultHost,
                Layout = "~/Views/Shared/_defaultLayout.cshtml",
                Name = TenantName,
                Owner = UserName,
                Theme = "~/Content/default/default.css",
                Title = TenantTitle,
                Promotional = true,
                ReferredByTenantId = ReferredByTenantId
            };

            return Create(bo);
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
            if (TenantExistsByName(tenant.Name))
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
            TenantBO obj = GetTenantById(tenant.TenantId);

            // throw an exception if the tenant doesn't exist
            if (obj == null)
                throw new TenantNotFoundException(tenant.TenantId);

            // throw an exception if the name has changed to an already existing tenant name
            if (string.Compare(obj.Name, tenant.Name, true) != 0)
            {
                if (TenantExistsByName(tenant.Name))
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
        public static bool TenantExistsByHost(string Host)
        {
            TenantBO obj = GetTenantByHost(Host);
            return obj != null;
        }

        
        /// <summary>
        /// True if a tenant exists with the name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool TenantExistsByName(string Name)
        {
            TenantBO obj = GetTenantByName(Name);
            return obj != null;
        }


        /// <summary>
        /// True if a tenant exists with the Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool TenantExistsById(int Id)
        {
            TenantBO obj = GetTenantById(Id);
            return obj != null;
        }
        
    }
}
