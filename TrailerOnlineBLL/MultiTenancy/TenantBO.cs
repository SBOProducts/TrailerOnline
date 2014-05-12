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
                NameLower = this.NameLower,
                TenantId = this.TenantId
            };
        }


        public int TenantId { get; set; }

        public string Name { get; set; }

        public string NameLower { get { return Name.ToLower(); } }

        public string Title { get; set; }

        public string Theme { get; set; }

        public string Layout { get; set; }


    }
}
