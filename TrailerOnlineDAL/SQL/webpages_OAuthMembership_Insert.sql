-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[webpages_OAuthMembership_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[webpages_OAuthMembership_Insert]
    END
GO

CREATE PROCEDURE [dbo].[webpages_OAuthMembership_Insert]
    @Provider NVarChar(30),
    @ProviderUserId NVarChar(100),
    @UserId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[webpages_OAuthMembership]
	(
        [Provider],
        [ProviderUserId],
        [UserId]
    ) VALUES (
        @Provider,
        @ProviderUserId,
        @UserId
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END