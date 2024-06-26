USE [QLCH]
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 5/22/2024 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[MeetingID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Date] [date] NOT NULL,
	[TimeStart] [time](7) NULL,
	[TimeEnd] [time](7) NULL,
	[Link] [nvarchar](200) NULL,
	[MeetingStatus] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Meeting] PRIMARY KEY CLUSTERED 
(
	[MeetingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 5/22/2024 6:19:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Vaitro] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](20) NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Meeting] ADD  CONSTRAINT [DF_Meeting_Date]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_UserLogin] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserLogin] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_UserLogin]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD CHECK  (([Quantity]<=(30)))
GO
