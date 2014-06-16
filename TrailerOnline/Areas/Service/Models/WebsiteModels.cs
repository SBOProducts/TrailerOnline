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

        [Required]
        public string PrimaryPhone { get; set; }

        public string AlternatePhone { get; set; }

        public string FaxNumber { get; set; }

        [Required]
        [Display(Name="Address")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string OperatingHours { get; set; }

        public string LogoImageUrl { get; set; }

    }
}