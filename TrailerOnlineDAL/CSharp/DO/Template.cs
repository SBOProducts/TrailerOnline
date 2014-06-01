// CREATED BY: Nathan Townsend - Small Business Online, LLC
// CREATED DATE: 5/31/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.ComponentModel.DataAnnotations;

namespace TrailerOnline.DAL.DO.dbo
{
    /// <summary>
    /// Encapsulates a row of data in the Template table
    /// </summary>
    public partial class TemplateDO
    {

        public virtual Int32 TemplateId {get; set;}
        public virtual String Type {get; set;}
        public virtual String Category {get; set;}
        public virtual String Name {get; set;}
        public virtual String Content {get; set;}

    }
}