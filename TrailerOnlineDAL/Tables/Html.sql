/****** Object:  Table [dbo].[Html]    Script Date: 7/25/2014 10:09:43 AM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Html](
	[TenantId] [int] NOT NULL,
	[HtmlId] [uniqueidentifier] NOT NULL,
	[Content] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Html_1] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC,
	[HtmlId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

