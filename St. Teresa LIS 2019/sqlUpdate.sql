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



alter table BXCY_SPECIMEN alter column case_no nvarchar(15);
alter table BXCY_SPECIMEN alter column barcode nvarchar(15);
alter table BXCY_SPECIMEN alter column ver nvarchar(1);
alter table BXCY_SPECIMEN alter column sign_dr nvarchar(30);
alter table BXCY_SPECIMEN alter column sign_dr2 nvarchar(30);
alter table BXCY_SPECIMEN alter column client nvarchar(45);
alter table BXCY_SPECIMEN alter column institute nvarchar(45);
alter table BXCY_SPECIMEN alter column doctor_id nvarchar(5);
alter table BXCY_SPECIMEN alter column doctor_ic nvarchar(40);
alter table BXCY_SPECIMEN alter column doctor_o nvarchar(45);
alter table BXCY_SPECIMEN alter column lab_ref nvarchar(30);
alter table BXCY_SPECIMEN alter column ethnic nvarchar(12);
alter table BXCY_SPECIMEN alter column patient nvarchar(35);
alter table BXCY_SPECIMEN alter column cname nvarchar(12);
alter table BXCY_SPECIMEN alter column pat_sex nvarchar(1);
alter table BXCY_SPECIMEN alter column pat_hkid nvarchar(20);
alter table BXCY_SPECIMEN alter column bed_room nvarchar(8);
alter table BXCY_SPECIMEN alter column bed_no nvarchar(8);
alter table BXCY_SPECIMEN alter column receipt nvarchar(15);
alter table BXCY_SPECIMEN alter column inv_no nvarchar(15);
alter table BXCY_SPECIMEN alter column fz_section nvarchar(1);
alter table BXCY_SPECIMEN alter column fz_detail nvarchar(50);
alter table BXCY_SPECIMEN alter column cy_type nvarchar(1);
alter table BXCY_SPECIMEN alter column cy_report nvarchar(8);
alter table BXCY_SPECIMEN alter column snopcode_t nvarchar(5);
alter table BXCY_SPECIMEN alter column desc_t nvarchar(30);
alter table BXCY_SPECIMEN alter column snopcode_m nvarchar(5);
alter table BXCY_SPECIMEN alter column desc_m nvarchar(30);
alter table BXCY_SPECIMEN alter column er nvarchar(1);
alter table BXCY_SPECIMEN alter column em nvarchar(1);
alter table BXCY_SPECIMEN alter column remind nvarchar(40);
alter table BXCY_SPECIMEN alter column initial nvarchar(10);
alter table BXCY_SPECIMEN alter column print_by nvarchar(10);
alter table BXCY_SPECIMEN alter column issue_by nvarchar(10);
alter table BXCY_SPECIMEN alter column update_by nvarchar(10);
alter table BXCY_SPECIMEN alter column updated nvarchar(1);
alter table BXCY_SPECIMEN alter column uploaded nvarchar(1);
alter table BXCY_SPECIMEN alter column snopcode_t2 nvarchar(5);
alter table BXCY_SPECIMEN alter column snopcode_t3 nvarchar(5);
alter table BXCY_SPECIMEN alter column snopcode_m2 nvarchar(5);
alter table BXCY_SPECIMEN alter column snopcode_m3 nvarchar(5);


update BXCY_SPECIMEN SET case_no = LTRIM(RTRIM(case_no));
update BXCY_SPECIMEN SET barcode = LTRIM(RTRIM(barcode));
update BXCY_SPECIMEN SET ver = LTRIM(RTRIM(ver));
update BXCY_SPECIMEN SET sign_dr = LTRIM(RTRIM(sign_dr));
update BXCY_SPECIMEN SET sign_dr2 = LTRIM(RTRIM(sign_dr2));
update BXCY_SPECIMEN SET client = LTRIM(RTRIM(client));
update BXCY_SPECIMEN SET institute = LTRIM(RTRIM(institute));
update BXCY_SPECIMEN SET doctor_id = LTRIM(RTRIM(doctor_id));
update BXCY_SPECIMEN SET doctor_ic = LTRIM(RTRIM(doctor_ic));
update BXCY_SPECIMEN SET doctor_o = LTRIM(RTRIM(doctor_o));
update BXCY_SPECIMEN SET lab_ref = LTRIM(RTRIM(lab_ref));
update BXCY_SPECIMEN SET ethnic = LTRIM(RTRIM(ethnic));
update BXCY_SPECIMEN SET patient = LTRIM(RTRIM(patient));
update BXCY_SPECIMEN SET cname = LTRIM(RTRIM(cname));
update BXCY_SPECIMEN SET pat_sex = LTRIM(RTRIM(pat_sex));
update BXCY_SPECIMEN SET pat_hkid = LTRIM(RTRIM(pat_hkid));
update BXCY_SPECIMEN SET bed_room = LTRIM(RTRIM(bed_room));
update BXCY_SPECIMEN SET bed_no = LTRIM(RTRIM(bed_no));
update BXCY_SPECIMEN SET receipt = LTRIM(RTRIM(receipt));
update BXCY_SPECIMEN SET inv_no = LTRIM(RTRIM(inv_no));
update BXCY_SPECIMEN SET fz_section = LTRIM(RTRIM(fz_section));
update BXCY_SPECIMEN SET fz_detail = LTRIM(RTRIM(fz_detail));
update BXCY_SPECIMEN SET cy_type = LTRIM(RTRIM(cy_type));
update BXCY_SPECIMEN SET cy_report = LTRIM(RTRIM(cy_report));
update BXCY_SPECIMEN SET snopcode_t = LTRIM(RTRIM(snopcode_t));
update BXCY_SPECIMEN SET desc_t = LTRIM(RTRIM(desc_t));
update BXCY_SPECIMEN SET snopcode_m = LTRIM(RTRIM(snopcode_m));
update BXCY_SPECIMEN SET desc_m = LTRIM(RTRIM(desc_m));
update BXCY_SPECIMEN SET er = LTRIM(RTRIM(er));
update BXCY_SPECIMEN SET em = LTRIM(RTRIM(em));
update BXCY_SPECIMEN SET remind = LTRIM(RTRIM(remind));
update BXCY_SPECIMEN SET initial = LTRIM(RTRIM(initial));
update BXCY_SPECIMEN SET print_by = LTRIM(RTRIM(print_by));
update BXCY_SPECIMEN SET issue_by = LTRIM(RTRIM(issue_by));
update BXCY_SPECIMEN SET update_by = LTRIM(RTRIM(update_by));
update BXCY_SPECIMEN SET updated = LTRIM(RTRIM(updated));
update BXCY_SPECIMEN SET uploaded = LTRIM(RTRIM(uploaded));
update BXCY_SPECIMEN SET snopcode_t2 = LTRIM(RTRIM(snopcode_t2));
update BXCY_SPECIMEN SET snopcode_t3 = LTRIM(RTRIM(snopcode_t3));
update BXCY_SPECIMEN SET snopcode_m2 = LTRIM(RTRIM(snopcode_m2));
update BXCY_SPECIMEN SET snopcode_m3 = LTRIM(RTRIM(snopcode_m3));
