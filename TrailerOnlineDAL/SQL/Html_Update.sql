-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 6/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Html_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Html_Update]
    END
GO

CREATE PROCEDURE [dbo].[Html_Update]
    @HtmlId Int,
    @TenantId Int,
    @Content VarChar(MAX)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[Html]
    SET
        [HtmlId] = @HtmlId,
        [TenantId] = @TenantId,
        [Content] = @Content
    WHERE
        [HtmlId] = @HtmlId AND
        [TenantId] = @TenantId

    SELECT @@ROWCOUNT AS UPDATED; 
END