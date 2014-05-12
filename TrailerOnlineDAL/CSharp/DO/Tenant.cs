// CREATED BY: Nathan Townsend
// CREATED DATE: 5/12/2014
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
        public virtual String Name {get; set;}
        public virtual String NameLower {get; set;}
        public virtual String Title {get; set;}
        public virtual String Theme {get; set;}
        public virtual String Layout {get; set;}

    }
}