-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[webpages_UsersInRoles_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[webpages_UsersInRoles_Update]
    END
GO

CREATE PROCEDURE [dbo].[webpages_UsersInRoles_Update]
    @UserId Int,
    @RoleId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[webpages_UsersInRoles]
    SET
        [UserId] = @UserId,
        [RoleId] = @RoleId
    WHERE
        [UserId] = @UserId AND
        [RoleId] = @RoleId

    SELECT @@ROWCOUNT AS UPDATED; 
END