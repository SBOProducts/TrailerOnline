-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 5/31/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Template_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Template_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[Template_GetByPK]
    @TemplateId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [TemplateId],
        [Type],
        [Category],
        [Name],
        [Content]
    FROM [dbo].[Template]
    WHERE 
        [TemplateId] = @TemplateId

END