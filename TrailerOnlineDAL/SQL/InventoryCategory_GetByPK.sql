-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/3/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[InventoryCategory_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[InventoryCategory_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[InventoryCategory_GetByPK]
    @TenantId Int,
    @CategoryId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [TenantId],
        [CategoryId],
        [MenuName],
        [PageTitle],
        [DisplayToPublic],
        [HtmlId]
    FROM [dbo].[InventoryCategory]
    WHERE 
        [TenantId] = @TenantId AND
        [CategoryId] = @CategoryId

END