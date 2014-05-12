-- CREATED BY: Nathan Townsend
-- CREATED DATE: 5/12/2014
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
    @Name VarChar(50),
    @NameLower VarChar(50) = null,
    @Title VarChar(100),
    @Theme VarChar(50),
    @Layout VarChar(50)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Tenant]
	(
        [Name],
        [NameLower],
        [Title],
        [Theme],
        [Layout]
    ) VALUES (
        @Name,
        @NameLower,
        @Title,
        @Theme,
        @Layout
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END