USE [TestMCF]
GO

/****** Object:  Table [dbo].[tr_bpkb]    Script Date: 17/01/2024 21:56:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tr_bpkb](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[agreement_number] [nvarchar](100) NOT NULL,
	[bpkb_no] [nvarchar](100) NOT NULL,
	[branch_id] [nvarchar](10) NOT NULL,
	[bpkb_date] [datetime2](7) NOT NULL,
	[faktur_no] [nvarchar](100) NOT NULL,
	[faktur_date] [datetime2](7) NOT NULL,
	[location_id] [nvarchar](10) NOT NULL,
	[police_no] [nvarchar](20) NOT NULL,
	[bpkb_date_in] [datetime2](7) NOT NULL,
	[created_by] [nvarchar](20) NOT NULL,
	[created_on] [datetime2](7) NOT NULL,
	[last_updated_by] [nvarchar](20) NOT NULL,
	[last_updated_on] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tr_bpkb] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tr_bpkb]  WITH CHECK ADD  CONSTRAINT [FK_tr_bpkb] FOREIGN KEY([location_id])
REFERENCES [dbo].[ms_storage_location] ([location_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tr_bpkb] CHECK CONSTRAINT [FK_tr_bpkb]
GO


