// CREATED BY: Nathan Townsend
// CREATED DATE: 7/17/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.ComponentModel.DataAnnotations;

namespace TrailerOnline.DAL.DO.dbo
{
    /// <summary>
    /// Encapsulates a row of data in the webpages_UsersInRoles table
    /// </summary>
    public partial class webpages_UsersInRolesDO
    {

        public virtual Int32 UserId {get; set;}
        public virtual Int32 RoleId {get; set;}

    }
}