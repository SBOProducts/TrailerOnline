-- CREATED BY: Nathan Townsend
-- CREATED DATE: 5/13/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Tenant_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Tenant_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[Tenant_GetByPK]
    @TenantId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [TenantId],
        [Name],
        [Host],
        [Title],
        [Theme],
        [Layout],
        [Owner],
        [Created]
    FROM [dbo].[Tenant]
    WHERE 
        [TenantId] = @TenantId

END