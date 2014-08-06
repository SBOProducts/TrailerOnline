-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Tenant_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Tenant_Update]
    END
GO

CREATE PROCEDURE [dbo].[Tenant_Update]
    @TenantId Int,
    @Host VarChar(50),
    @Title VarChar(100),
    @Theme VarChar(50),
    @Layout VarChar(50),
    @Owner NVarChar(56),
    @Created DateTime,
    @Promotional Bit
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[Tenant]
    SET
        [Host] = @Host,
        [Title] = @Title,
        [Theme] = @Theme,
        [Layout] = @Layout,
        [Owner] = @Owner,
        [Created] = @Created,
        [Promotional] = @Promotional
    WHERE
        [TenantId] = @TenantId

    SELECT @@ROWCOUNT AS UPDATED; 
END