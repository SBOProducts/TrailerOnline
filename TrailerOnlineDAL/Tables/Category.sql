/****** Object:  Table [dbo].[Category]    Script Date: 7/25/2014 10:09:43 AM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Category](
	[TenantId] [int] NOT NULL,
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PageTitle] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayToPublic] [bit] NOT NULL,
	[HtmlId] [uniqueidentifier] NOT NULL,
	[Sequence] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Index [Category_CategoryId]    Script Date: 7/25/2014 10:09:43 AM ******/
CREATE NONCLUSTERED INDEX [Category_CategoryId] ON [dbo].[Category]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
/****** Object:  Index [Category_TenantId]    Script Date: 7/25/2014 10:09:43 AM ******/
CREATE NONCLUSTERED INDEX [Category_TenantId] ON [dbo].[Category]
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
