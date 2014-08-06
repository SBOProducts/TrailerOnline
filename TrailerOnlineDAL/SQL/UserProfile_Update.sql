-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/24/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[UserProfile_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[UserProfile_Update]
    END
GO

CREATE PROCEDURE [dbo].[UserProfile_Update]
    @UserId Int,
    @UserName NVarChar(56)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[UserProfile]
    SET
        [UserName] = @UserName
    WHERE
        [UserId] = @UserId

    SELECT @@ROWCOUNT AS UPDATED; 
END