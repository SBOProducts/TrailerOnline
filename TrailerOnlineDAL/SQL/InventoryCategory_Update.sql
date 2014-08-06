-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/23/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[InventoryCategory_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[InventoryCategory_Update]
    END
GO

CREATE PROCEDURE [dbo].[InventoryCategory_Update]
    @TenantId Int,
    @CategoryId Int,
    @MenuName VarChar(60),
    @PageTitle VarChar(100),
    @DisplayToPublic Bit,
    @HtmlId UniqueIdentifier,
    @Sequence Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[InventoryCategory]
    SET
        [TenantId] = @TenantId,
        [MenuName] = @MenuName,
        [PageTitle] = @PageTitle,
        [DisplayToPublic] = @DisplayToPublic,
        [HtmlId] = @HtmlId,
        [Sequence] = @Sequence
    WHERE
        [TenantId] = @TenantId AND
        [CategoryId] = @CategoryId

    SELECT @@ROWCOUNT AS UPDATED; 
END