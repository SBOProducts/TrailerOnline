-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[webpages_Roles_GetByUQ__webpages__8A2B61609622F04F]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[webpages_Roles_GetByUQ__webpages__8A2B61609622F04F]
    END
GO

CREATE PROCEDURE [dbo].[webpages_Roles_GetByUQ__webpages__8A2B61609622F04F]
    @RoleName NVarChar(256)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [RoleId],
        [RoleName]
    FROM [dbo].[webpages_Roles]
    WHERE 
        [RoleName] = @RoleName

END