-- CREATED BY: Nathan Townsend
-- CREATED DATE: 5/19/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Tenant_GetByTenant_Host]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Tenant_GetByTenant_Host]
    END
GO

CREATE PROCEDURE [dbo].[Tenant_GetByTenant_Host]
    @Host VarChar(50)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [TenantId],
        [Host],
        [Title],
        [Theme],
        [Layout],
        [Owner],
        [Created],
        [Promotional],
        [ReferrerTenantId]
    FROM [dbo].[Tenant]
    WHERE 
        [Host] = @Host

END