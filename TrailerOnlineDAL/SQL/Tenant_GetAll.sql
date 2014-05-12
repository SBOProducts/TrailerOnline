-- CREATED BY: Nathan Townsend
-- CREATED DATE: 5/12/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Tenant_GetAll]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Tenant_GetAll]
    END
GO

CREATE PROCEDURE [dbo].[Tenant_GetAll]

AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [TenantId],
        [Name],
        [NameLower],
        [Title],
        [Theme],
        [Layout]
    FROM [dbo].[Tenant]

END