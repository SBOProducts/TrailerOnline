-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Product_Delete]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Product_Delete]
    END
GO

CREATE PROCEDURE [dbo].[Product_Delete]
    @TenantId Int,
        @CategoryId Int,
        @ProductId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE 
        [dbo].[Product]
    WHERE
        [TenantId] = @TenantId AND
        [CategoryId] = @CategoryId AND
        [ProductId] = @ProductId

    SELECT @@ROWCOUNT AS DELETED; 
END