-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Html_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Html_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[Html_GetByPK]
    @TenantId Int,
    @HtmlId UniqueIdentifier
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [TenantId],
        [HtmlId],
        [Content]
    FROM [dbo].[Html]
    WHERE 
        [TenantId] = @TenantId AND
        [HtmlId] = @HtmlId

END