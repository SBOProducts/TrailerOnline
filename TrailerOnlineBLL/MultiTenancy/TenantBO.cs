using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL.MultiTenancy
{
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
            this.Name = data.Name;
            this.Title = data.Title;
            this.Theme = data.Theme;
            this.Layout = data.Layout;
            this.Host = data.Host;
            this.Created = data.Created;
            this.Owner = data.Owner;
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
                Name = this.Name,
                TenantId = this.TenantId,
                Host = this.Host,
                Created = this.Created,
                Owner = this.Owner
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
        /// the name used to reference the tenent
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the lowercase version of the tenent name
        /// </summary>
        public string NameLower { get { return Name.ToLower(); } }

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


    }
}
