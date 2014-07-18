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
    /// Encapsulates a row of data in the Product table
    /// </summary>
    public partial class ProductDO
    {

        public virtual Int32 TenantId {get; set;}
        public virtual Int32 CategoryId {get; set;}
        public virtual Int32 ProductId {get; set;}
        public virtual String Name {get; set;}
        public virtual Decimal Price {get; set;}
        public virtual String Description {get; set;}
        public virtual Boolean DisplayToPublic {get; set;}
        public virtual DateTime CreateDate {get; set;}
        public virtual Int32 Sequence {get; set;}

    }
}