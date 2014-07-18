-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 7/17/2014
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
    @TenantId Int,
    @HtmlId UniqueIdentifier,
    @Content VarChar(MAX)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[Html]
    SET
        [TenantId] = @TenantId,
        [HtmlId] = @HtmlId,
        [Content] = @Content
    WHERE
        [TenantId] = @TenantId AND
        [HtmlId] = @HtmlId

    SELECT @@ROWCOUNT AS UPDATED; 
END