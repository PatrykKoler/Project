USE [Paliwo]
GO

/****** Object:  Table [dbo].[Expenses]    Script Date: 26.03.2018 12:44:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Expenses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](5, 2) NOT NULL,
	[Liters] [decimal](5, 2) NOT NULL,
	[Date_added] [date] NULL,
	[Date_modification] [datetimeoffset](7) NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Expenses] ADD  CONSTRAINT [DF_Expenses_status]  DEFAULT ((1)) FOR [status]
GO

