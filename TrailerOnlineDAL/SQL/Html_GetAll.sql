-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 6/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Html_GetAll]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Html_GetAll]
    END
GO

CREATE PROCEDURE [dbo].[Html_GetAll]

AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [HtmlId],
        [TenantId],
        [Content]
    FROM [dbo].[Html]

END