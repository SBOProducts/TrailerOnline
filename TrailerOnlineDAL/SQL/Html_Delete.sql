-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Html_Delete]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Html_Delete]
    END
GO

CREATE PROCEDURE [dbo].[Html_Delete]
    @TenantId Int,
        @HtmlId UniqueIdentifier
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE 
        [dbo].[Html]
    WHERE
        [TenantId] = @TenantId AND
        [HtmlId] = @HtmlId

    SELECT @@ROWCOUNT AS DELETED; 
END