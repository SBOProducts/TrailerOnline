-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Tenant_Delete]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Tenant_Delete]
    END
GO

CREATE PROCEDURE [dbo].[Tenant_Delete]
    @TenantId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE 
        [dbo].[Tenant]
    WHERE
        [TenantId] = @TenantId

    SELECT @@ROWCOUNT AS DELETED; 
END