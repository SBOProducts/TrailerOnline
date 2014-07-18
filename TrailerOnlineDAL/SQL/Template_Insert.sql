-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Template_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Template_Insert]
    END
GO

CREATE PROCEDURE [dbo].[Template_Insert]
    @Type VarChar(50),
    @Category VarChar(50),
    @Name VarChar(50),
    @Subject VarChar(100),
    @Content VarChar(MAX)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Template]
	(
        [Type],
        [Category],
        [Name],
        [Subject],
        [Content]
    ) VALUES (
        @Type,
        @Category,
        @Name,
        @Subject,
        @Content
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END