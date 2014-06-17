using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrailerOnline.Areas.Service.Models
{

    public class CreateWebsiteModel
    {
        /// <summary>
        /// Becomes the first part of the subdomain (tenantname.trailercloud.com)
        /// </summary>
        [Required]
        [Display(Name = "Website Name")]
        [RegularExpression("\\w+")]
        public string TenantName { get; set; }

        /// <summary>
        /// The name of the business
        /// </summary>
        [Required]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

    }
}