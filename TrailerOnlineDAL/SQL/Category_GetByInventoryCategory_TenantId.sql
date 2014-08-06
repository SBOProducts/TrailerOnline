-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/24/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Category_GetByInventoryCategory_TenantId]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Category_GetByInventoryCategory_TenantId]
    END
GO

CREATE PROCEDURE [dbo].[Category_GetByInventoryCategory_TenantId]
    @TenantId Int
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
        [HtmlId],
        [Sequence]
    FROM [dbo].[Category]
    WHERE 
        [TenantId] = @TenantId

END