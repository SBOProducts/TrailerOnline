// CREATED BY: Nathan Townsend - Small Business Online, LLC
// CREATED DATE: 7/17/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.ComponentModel.DataAnnotations;

namespace TrailerOnline.DAL.DO.dbo
{
    /// <summary>
    /// Encapsulates a row of data in the Html table
    /// </summary>
    public partial class HtmlDO
    {

        public virtual Int32 TenantId {get; set;}
        public virtual Guid HtmlId {get; set;}
        public virtual String Content {get; set;}

    }
}