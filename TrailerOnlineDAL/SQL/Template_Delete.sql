-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Template_Delete]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Template_Delete]
    END
GO

CREATE PROCEDURE [dbo].[Template_Delete]
    @TemplateId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE 
        [dbo].[Template]
    WHERE
        [TemplateId] = @TemplateId

    SELECT @@ROWCOUNT AS DELETED; 
END