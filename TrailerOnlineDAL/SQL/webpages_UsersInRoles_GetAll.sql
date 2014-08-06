-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/24/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[webpages_UsersInRoles_GetAll]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[webpages_UsersInRoles_GetAll]
    END
GO

CREATE PROCEDURE [dbo].[webpages_UsersInRoles_GetAll]

AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [UserId],
        [RoleId]
    FROM [dbo].[webpages_UsersInRoles]

END