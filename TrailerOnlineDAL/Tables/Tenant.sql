/****** Object:  Table [dbo].[Tenant]    Script Date: 5/14/2014 11:05:47 PM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[Tenant](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Host] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Title] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Theme] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Layout] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Owner] [nvarchar](56) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Promotional] [bit] NOT NULL,
	[ReferrerTenantId] [int] NOT NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

