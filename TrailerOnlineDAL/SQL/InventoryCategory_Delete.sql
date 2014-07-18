-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[InventoryCategory_Delete]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[InventoryCategory_Delete]
    END
GO

CREATE PROCEDURE [dbo].[InventoryCategory_Delete]
    @TenantId Int,
        @CategoryId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE 
        [dbo].[InventoryCategory]
    WHERE
        [TenantId] = @TenantId AND
        [CategoryId] = @CategoryId

    SELECT @@ROWCOUNT AS DELETED; 
END