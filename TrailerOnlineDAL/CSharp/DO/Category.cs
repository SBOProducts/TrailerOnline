// CREATED BY: Nathan Townsend
// CREATED DATE: 7/25/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.ComponentModel.DataAnnotations;

namespace TrailerOnline.DAL.DO.dbo
{
    /// <summary>
    /// Encapsulates a row of data in the Category table
    /// </summary>
    public partial class CategoryDO
    {

        public virtual Int32 TenantId {get; set;}
        public virtual Int32 CategoryId {get; set;}
        public virtual String MenuName {get; set;}
        public virtual String PageTitle {get; set;}
        public virtual Boolean DisplayToPublic {get; set;}
        public virtual Guid HtmlId {get; set;}
        public virtual Int32 Sequence {get; set;}

    }
}