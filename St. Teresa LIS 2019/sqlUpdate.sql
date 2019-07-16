ALTER TABLE PATIENT ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE PATIENT ADD CONSTRAINT [PK_PATIENT] primary key (ID)

GO


ALTER TABLE CLIENT ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE CLIENT ADD CONSTRAINT [PK_CLIENT] primary key (ID)

GO

ALTER TABLE DOCTOR ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE DOCTOR ADD CONSTRAINT [PK_DOCTOR] primary key (ID)

GO

ALTER TABLE result ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE result ADD CONSTRAINT [PK_result] primary key (ID)

GO

ALTER TABLE snopcode ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE snopcode ADD CONSTRAINT [PK_snopcode] primary key (ID)

GO

ALTER TABLE diagnosis ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE diagnosis ADD CONSTRAINT [PK_diagnosis] primary key (ID)

GO

ALTER TABLE cyreport ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE cyreport ADD CONSTRAINT [PK_cyreport] primary key (ID)

GO

ALTER TABLE ebv_specimen ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE ebv_specimen ADD CONSTRAINT [PK_ebv_specimen] primary key (ID)

GO

ALTER TABLE PATIENT ADD [master] [int] NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD CONSTRAINT [PK_bxcy_specimen] primary key (ID)

GO


DROP TABLE [dbo].[system_setting]
GO

CREATE TABLE [dbo].[system_setting](
	[picture_path] [nvarchar](550) NULL,
	[invoice_year] [int] NULL,
	[next_inv] [int] NULL,
	[next_receipt] [int] NULL,
	[activate_user_level_control] [bit] NULL,
	[auto_print_barcode] [bit] NULL,
	[auto_generate_PDF] [bit] NULL,
	[PRICE_BX] [float] NULL,
	[PRICE_BB] [float] NULL,
	[PRICE_CY] [float] NULL,
	[PRICE_CC] [float] NULL,
	[PRICE_CYG] [float] NULL,
	[PRICE_EBV] [float] NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_BY] [nvarchar](255) NULL
) ON [PRIMARY]

GO

ALTER TABLE system_setting ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE system_setting ADD CONSTRAINT [PK_system_setting] primary key (ID)

GO


ALTER TABLE [USER] ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE [USER] ADD CONSTRAINT [PK_USER] primary key (ID)

GO



ALTER TABLE BXCY_SPECIMEN ADD Clinical_History [nvarchar](255) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Class [nvarchar](50) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Doctor_ic2 [nvarchar](10) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Doctor_id2 [nvarchar](10) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Doctor_ic3 [nvarchar](10) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Doctor_id3 [nvarchar](10) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Histo [nvarchar](50) NULL

GO

ALTER TABLE BXCY_SPECIMEN ADD Cyto_Type [nvarchar](50) NULL

GO
