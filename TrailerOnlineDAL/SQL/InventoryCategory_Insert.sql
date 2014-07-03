-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[InventoryCategory_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[InventoryCategory_Insert]
    END
GO

CREATE PROCEDURE [dbo].[InventoryCategory_Insert]
    @TenantId Int,
    @MenuName VarChar(60),
    @PageTitle VarChar(100),
    @DisplayToPublic Bit,
    @HtmlId UniqueIdentifier
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[InventoryCategory]
	(
        [TenantId],
        [MenuName],
        [PageTitle],
        [DisplayToPublic],
        [HtmlId]
    ) VALUES (
        @TenantId,
        @MenuName,
        @PageTitle,
        @DisplayToPublic,
        @HtmlId
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END