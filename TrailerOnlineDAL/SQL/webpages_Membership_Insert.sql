-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[webpages_Membership_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[webpages_Membership_Insert]
    END
GO

CREATE PROCEDURE [dbo].[webpages_Membership_Insert]
    @UserId Int,
    @CreateDate DateTime = null,
    @ConfirmationToken NVarChar(128) = null,
    @IsConfirmed Bit = null,
    @LastPasswordFailureDate DateTime = null,
    @PasswordFailuresSinceLastSuccess Int,
    @Password NVarChar(128),
    @PasswordChangedDate DateTime = null,
    @PasswordSalt NVarChar(128),
    @PasswordVerificationToken NVarChar(128) = null,
    @PasswordVerificationTokenExpirationDate DateTime = null
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[webpages_Membership]
	(
        [UserId],
        [CreateDate],
        [ConfirmationToken],
        [IsConfirmed],
        [LastPasswordFailureDate],
        [PasswordFailuresSinceLastSuccess],
        [Password],
        [PasswordChangedDate],
        [PasswordSalt],
        [PasswordVerificationToken],
        [PasswordVerificationTokenExpirationDate]
    ) VALUES (
        @UserId,
        @CreateDate,
        @ConfirmationToken,
        @IsConfirmed,
        @LastPasswordFailureDate,
        @PasswordFailuresSinceLastSuccess,
        @Password,
        @PasswordChangedDate,
        @PasswordSalt,
        @PasswordVerificationToken,
        @PasswordVerificationTokenExpirationDate
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END