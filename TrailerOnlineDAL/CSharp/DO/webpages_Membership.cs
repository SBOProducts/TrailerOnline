// CREATED BY: Nathan Townsend
// CREATED DATE: 7/3/2014
// DO NOT MODIFY THIS CODE
// CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
// GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



using System;
using System.ComponentModel.DataAnnotations;

namespace TrailerOnline.DAL.DO.dbo
{
    /// <summary>
    /// Encapsulates a row of data in the webpages_Membership table
    /// </summary>
    public partial class webpages_MembershipDO
    {

        public virtual Int32 UserId {get; set;}
        public virtual DateTime? CreateDate {get; set;}
        public virtual String ConfirmationToken {get; set;}
        public virtual Boolean? IsConfirmed {get; set;}
        public virtual DateTime? LastPasswordFailureDate {get; set;}
        public virtual Int32 PasswordFailuresSinceLastSuccess {get; set;}
        public virtual String Password {get; set;}
        public virtual DateTime? PasswordChangedDate {get; set;}
        public virtual String PasswordSalt {get; set;}
        public virtual String PasswordVerificationToken {get; set;}
        public virtual DateTime? PasswordVerificationTokenExpirationDate {get; set;}

    }
}