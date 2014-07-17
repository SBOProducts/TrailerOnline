/****** Object:  Table [dbo].[InventoryCategory]    Script Date: 7/17/2014 4:10:15 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[InventoryCategory](
	[TenantId] [int] NOT NULL,
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PageTitle] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayToPublic] [bit] NOT NULL,
	[HtmlId] [uniqueidentifier] NOT NULL,
	[Sequence] [int] NOT NULL,
 CONSTRAINT [PK_InventoryCategory] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Index [InventoryCategory_TenantId]    Script Date: 7/17/2014 4:10:15 PM ******/
CREATE NONCLUSTERED INDEX [InventoryCategory_TenantId] ON [dbo].[InventoryCategory]
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
