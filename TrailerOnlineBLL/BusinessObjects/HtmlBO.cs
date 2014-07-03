using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL.BusinessObjects
{
    /// <summary>
    /// Encapsulates htlm content that displays on a page
    /// </summary>
    public class HtmlBO
    {
        public HtmlBO()
        {

        }

        /// <summary>
        /// Creates a new business object from a data object
        /// </summary>
        /// <param name="DataObject"></param>
        internal HtmlBO(HtmlDO DataObject)
        {
            this.HtmlId = DataObject.HtmlId;
            this.TenantId = DataObject.TenantId;
            this.Content = DataObject.Content;
        }

        /// <summary>
        /// Gets the data object encapsulated by this business object
        /// </summary>
        /// <returns></returns>
        internal HtmlDO GetDataObject()
        {
            return new HtmlDO()
            {
                Content = this.Content,
                HtmlId = this.HtmlId,
                TenantId = this.TenantId
            };
        }

        /// <summary>
        /// The id of the html content
        /// </summary>
        public virtual Guid HtmlId { get; set; }

        /// <summary>
        /// The tenant that owns the content
        /// </summary>
        public virtual Int32 TenantId { get; set; }

        /// <summary>
        /// The html content
        /// </summary>
        public virtual String Content { get; set; }
    }
}
