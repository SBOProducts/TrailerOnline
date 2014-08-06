-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Category_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Category_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[Category_GetByPK]
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
        [HtmlId],
        [Sequence]
    FROM [dbo].[Category]
    WHERE 
        [TenantId] = @TenantId AND
        [CategoryId] = @CategoryId

END