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
        /// Returns true if the host name matches the default host name
        /// </summary>
        /// <param name="HostName"></param>
        /// <returns></returns>
        public static bool IsDefaultHost(string HostName)
        {
            return string.Compare(HostName, DefaultHost, true) == 0;
        }


        /// <summary>
        /// The default layout
        /// </summary>
        public static string DefaultLayout { get { return ConfigurationManager.AppSettings["DefaultLayout"]; } }


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
            TenantBO tenant = null;
            
            tenant = GetTenantByHost(host);

            // The tenant could not be found
            if (tenant == null)
                TenantNotFoundRedirect(Context, host);

            // add tenant to data items
            Context.Items.Add(DataItemName, tenant);

            return tenant;
            
        }

        /// <summary>
        /// Redirects to the default system page when no tenant specified, or to the not found page if the tenant was specified but doesn't exits
        /// </summary>
        /// <param name="Host"></param>
        private static void TenantNotFoundRedirect(HttpContext Context, string Host)
        {
            string redirect = string.Empty;

            if (IsDefaultHost(Host))
                redirect = string.Format("http://{0}/Service", DefaultHost);
            else
                redirect = string.Format("http://{0}/Service/Home/NotFound?id={1}", DefaultHost, HttpContext.Current.Server.UrlEncode(Host));

            Context.Response.Redirect(redirect);
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
                Host = string.Format("{0}.{1}", TenantName, DefaultHost),
                Layout = "~/Views/Shared/_defaultLayout.cshtml",
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
            // don't allow duplicate tenants
            if(TenantExistsByHost(tenant.Host))
                throw new DuplicateTenantException(tenant.Host);

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
            if (string.Compare(obj.Host, tenant.Host, true) != 0)
            {
                if (TenantExistsByHost(tenant.Host))
                    throw new DuplicateTenantException(tenant.Host);
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
