-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Html_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Html_Insert]
    END
GO

CREATE PROCEDURE [dbo].[Html_Insert]
    @TenantId Int,
    @HtmlId UniqueIdentifier,
    @Content VarChar(MAX)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Html]
	(
        [TenantId],
        [HtmlId],
        [Content]
    ) VALUES (
        @TenantId,
        @HtmlId,
        @Content
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END