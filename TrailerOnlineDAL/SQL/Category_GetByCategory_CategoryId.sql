-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Category_GetByCategory_CategoryId]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Category_GetByCategory_CategoryId]
    END
GO

CREATE PROCEDURE [dbo].[Category_GetByCategory_CategoryId]
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
        [HtmlId],
        [Sequence]
    FROM [dbo].[Category]
    WHERE 
        [CategoryId] = @CategoryId

END