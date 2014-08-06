-- CREATED BY: Nathan Townsend
-- CREATED DATE: 7/25/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [TrailerOnline]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Product_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Product_Insert]
    END
GO

CREATE PROCEDURE [dbo].[Product_Insert]
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

    INSERT INTO [dbo].[Product]
	(
        [CategoryId],
        [ProductId],
        [Name],
        [Price],
        [Description],
        [DisplayToPublic],
        [CreateDate],
        [Sequence]
    ) VALUES (
        @CategoryId,
        @ProductId,
        @Name,
        @Price,
        @Description,
        @DisplayToPublic,
        @CreateDate,
        @Sequence
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END