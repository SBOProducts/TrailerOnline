-- CREATED BY: Nathan Townsend - Small Business Online, LLC
-- CREATED DATE: 7/17/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Product_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Product_Update]
    END
GO

CREATE PROCEDURE [dbo].[Product_Update]
    @TenantId Int,
    @CategoryId Int,
    @ProductId Int,
    @Name VarChar(60),
    @Price Decimal(18, 2),
    @Description VarChar(MAX),
    @DisplayToPublic Bit,
    @CreateDate DateTime,
    @Sequence Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[Product]
    SET
        [CategoryId] = @CategoryId,
        [ProductId] = @ProductId,
        [Name] = @Name,
        [Price] = @Price,
        [Description] = @Description,
        [DisplayToPublic] = @DisplayToPublic,
        [CreateDate] = @CreateDate,
        [Sequence] = @Sequence
    WHERE
        [TenantId] = @TenantId AND
        [CategoryId] = @CategoryId AND
        [ProductId] = @ProductId

    SELECT @@ROWCOUNT AS UPDATED; 
END