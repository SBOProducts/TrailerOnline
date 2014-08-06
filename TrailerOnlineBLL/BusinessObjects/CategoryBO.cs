using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL.BusinessObjects
{
    public class CategoryBO
    {
        public CategoryBO()
        {

        }

        /// <summary>
        /// Creates a new business object from a data object
        /// </summary>
        /// <param name="data"></param>
        internal CategoryBO(CategoryDO data)
        {
            this.CategoryId = data.CategoryId;
            this.DisplayToPublic = data.DisplayToPublic;
            this.HtmlId = data.HtmlId;
            this.MenuName = data.MenuName;
            this.PageTitle = data.PageTitle;
            this.Sequence = data.Sequence;
            this.TenantId = data.TenantId;
        }

        /// <summary>
        /// Gets the business object
        /// </summary>
        /// <returns></returns>
        internal CategoryDO GetDataObject()
        {
            return new CategoryDO()
            {
                CategoryId = this.CategoryId,
                DisplayToPublic = this.DisplayToPublic,
                HtmlId = this.HtmlId,
                MenuName = this.MenuName,
                PageTitle = this.PageTitle,
                Sequence = this.Sequence,
                TenantId = this.TenantId
            };
        }


        public virtual Int32 TenantId { get; set; }
        public virtual Int32 CategoryId { get; set; }
        public virtual String MenuName { get; set; }
        public virtual String PageTitle { get; set; }
        public virtual Boolean DisplayToPublic { get; set; }
        public virtual Guid HtmlId { get; set; }
        public virtual Int32 Sequence { get; set; }

    }
}
