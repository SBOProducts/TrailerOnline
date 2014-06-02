-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 6/1/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Template_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Template_Update]
    END
GO

CREATE PROCEDURE [dbo].[Template_Update]
    @TemplateId Int,
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

    UPDATE [dbo].[Template]
    SET
        [Type] = @Type,
        [Category] = @Category,
        [Name] = @Name,
        [Subject] = @Subject,
        [Content] = @Content
    WHERE
        [TemplateId] = @TemplateId

    SELECT @@ROWCOUNT AS UPDATED; 
END