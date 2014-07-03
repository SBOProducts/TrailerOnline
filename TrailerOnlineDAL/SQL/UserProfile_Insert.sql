-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[UserProfile_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[UserProfile_Insert]
    END
GO

CREATE PROCEDURE [dbo].[UserProfile_Insert]
    @UserName NVarChar(56)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[UserProfile]
	(
        [UserName]
    ) VALUES (
        @UserName
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END