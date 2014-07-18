/****** Object:  Table [dbo].[Product]    Script Date: 7/17/2014 9:14:46 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Product](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Name] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Description] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayToPublic] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Sequence] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC,
	[CategoryId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

