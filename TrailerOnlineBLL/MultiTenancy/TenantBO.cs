using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL.MultiTenancy
{
    /// <summary>
    /// The default tenant when none is provided
    /// </summary>
    public class DefaultTenantBO: TenantBO
    {
        public DefaultTenantBO()
        {
            this.Created = DateTime.Now;
            this.Host = TenantBLL.DefaultHost;
            this.Layout = TenantBLL.DefaultLayout;
            this.Owner = null;
            this.TenantId = 0;
            this.Theme = TenantBLL.DefaultTheme;
            this.Title = TenantBLL.DefaultTenantTitle;
            this.Promotional = true;
        }
    }

    public class TenantBO
    {


        /// <summary>
        /// Creates a new default instance of the business object
        /// </summary>
        public TenantBO() { }

        /// <summary>
        /// Creates a business object from a data object
        /// </summary>
        /// <param name="data"></param>
        internal TenantBO(TenantDO data)
        {
            this.TenantId = data.TenantId;
            this.Title = data.Title;
            this.Theme = data.Theme;
            this.Layout = data.Layout;
            this.Host = data.Host;
            this.Created = data.Created;
            this.Owner = data.Owner;
            this.Promotional = data.Promotional;
            this.ReferredByTenantId = data.ReferrerTenantId;
        }


        /// <summary>
        /// Gets the underlying data object
        /// </summary>
        /// <returns></returns>
        internal TenantDO GetDataObject()
        {
            return new TenantDO()
            {
                Layout = this.Layout,
                Theme = this.Theme,
                Title = this.Title,
                TenantId = this.TenantId,
                Host = this.Host,
                Created = this.Created,
                Owner = this.Owner,
                Promotional = this.Promotional,
                ReferrerTenantId = this.ReferredByTenantId
            };
        }



        /// <summary>
        /// the id of the tenant
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// the host name
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// the lower case version of the host name
        /// </summary>
        public string HostLower { get { return Host.ToLower(); } }
        

        /// <summary>
        /// If the site promotes Trailer Online by displaying links to create a demo
        /// </summary>
        public bool Promotional { get; set; }

        /// <summary>
        /// the business title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// the theme to use
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// the layout to use
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// when it was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The login name of the tenant 
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// If the user presented is the tenant
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool IsOwner(string UserName)
        {
            return string.Compare(UserName, Owner, true) == 0;
        }

        /// <summary>
        /// The tenant that referred this tenant
        /// </summary>
        public int ReferredByTenantId { get; set; }


    }
}
