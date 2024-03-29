USE [db_1625187_agency]
GO
/****** Object:  Table [dbo].[ResetLink]    Script Date: 17/12/2019 11:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResetLink](
	[Id] [uniqueidentifier] NOT NULL,
	[User_Id] [int] NOT NULL,
	[ResetDate] [datetime] NULL,
 CONSTRAINT [PK_ResetLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Tbl]    Script Date: 17/12/2019 11:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Tbl](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[User_Email] [nvarchar](max) NOT NULL,
	[IsValid] [nvarchar](50) NULL,
	[ValidLink] [nvarchar](50) NULL,
 CONSTRAINT [PK_User_Tbl] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ResetLink]  WITH CHECK ADD  CONSTRAINT [FK_ResetLink_ResetLink] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User_Tbl] ([User_Id])
GO
ALTER TABLE [dbo].[ResetLink] CHECK CONSTRAINT [FK_ResetLink_ResetLink]
GO
