/****** Object:  Table [dbo].[Tenant]    Script Date: 6/25/2014 11:25:25 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Tenant](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[Host] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Title] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Theme] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Layout] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Owner] [nvarchar](56) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Promotional] [bit] NOT NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

