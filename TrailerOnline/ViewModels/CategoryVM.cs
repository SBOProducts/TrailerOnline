using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrailerOnline.BLL.BusinessObjects;

namespace TrailerOnline.ViewModels
{
    public class CategoryVM
    {

        public CategoryVM()
        {
            
        }

        public CategoryVM(CategoryBO data)
        {
            this.CategoryId = data.CategoryId;
            this.DisplayToPublic = data.DisplayToPublic;
            this.HtmlId = data.HtmlId;
            this.MenuName = data.MenuName;
            this.PageTitle = data.PageTitle;
            this.Sequence = data.Sequence;
            this.TenantId = data.TenantId;
        }


        public CategoryBO GetBusinessObject()
        {
            return new CategoryBO()
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

        [Display(Name= "Menu Name")]
        [Required]
        public virtual String MenuName { get; set; }

        [Display(Name = "Page Title")]
        [Required]
        public virtual String PageTitle { get; set; }

        [Display(Name = "Display To Public")]
        public virtual Boolean DisplayToPublic { get; set; }

        public virtual Guid HtmlId { get; set; }

        public virtual Int32 Sequence { get; set; }

    }



}