-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Tenant_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Tenant_Insert]
    END
GO

CREATE PROCEDURE [dbo].[Tenant_Insert]
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

    INSERT INTO [dbo].[Tenant]
	(
        [Host],
        [Title],
        [Theme],
        [Layout],
        [Owner],
        [Created],
        [Promotional]
    ) VALUES (
        @Host,
        @Title,
        @Theme,
        @Layout,
        @Owner,
        @Created,
        @Promotional
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END