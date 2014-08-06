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
    /// Encapsulates a row of data in the Tenant table
    /// </summary>
    public partial class TenantDO
    {

        public virtual Int32 TenantId {get; set;}
        public virtual String Host {get; set;}
        public virtual String Title {get; set;}
        public virtual String Theme {get; set;}
        public virtual String Layout {get; set;}
        public virtual String Owner {get; set;}
        public virtual DateTime Created {get; set;}
        public virtual Boolean Promotional {get; set;}

    }
}