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




IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='PATIENT')
BEGIN
ALTER TABLE PATIENT ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE PATIENT ADD CONSTRAINT [PK_PATIENT] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='CLIENT')
BEGIN
ALTER TABLE CLIENT ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE CLIENT ADD CONSTRAINT [PK_CLIENT] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DOCTOR')
BEGIN
ALTER TABLE DOCTOR ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE DOCTOR ADD CONSTRAINT [PK_DOCTOR] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='RESULT')
BEGIN
ALTER TABLE result ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE result ADD CONSTRAINT [PK_result] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='SNOPCODE')
BEGIN
ALTER TABLE snopcode ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE snopcode ADD CONSTRAINT [PK_snopcode] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAGNOSIS')
BEGIN
ALTER TABLE diagnosis ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE diagnosis ADD CONSTRAINT [PK_diagnosis] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='CYREPORT')
BEGIN
ALTER TABLE cyreport ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE cyreport ADD CONSTRAINT [PK_cyreport] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='EBV_SPECIMEN')
BEGIN
ALTER TABLE ebv_specimen ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE ebv_specimen ADD CONSTRAINT [PK_ebv_specimen] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'master' AND LTRIM(b.name)='PATIENT')
ALTER TABLE PATIENT ADD [master] [int] NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE BXCY_SPECIMEN ADD CONSTRAINT [PK_bxcy_specimen] primary key (ID);
END

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_setting]') AND type in (N'U'))
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

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='SYSTEM_SETTING')
BEGIN
ALTER TABLE system_setting ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE system_setting ADD CONSTRAINT [PK_system_setting] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='USER')
BEGIN
ALTER TABLE [USER] ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE [USER] ADD CONSTRAINT [PK_USER] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Clinical_History' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Clinical_History [nvarchar](255) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = '[Class]' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD [Class] [nvarchar](50) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Doctor_ic2' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Doctor_ic2 [nvarchar](10) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Doctor_id2' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Doctor_id2 [nvarchar](10) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Doctor_ic3' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Doctor_ic3 [nvarchar](10) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Doctor_id3' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Doctor_id3 [nvarchar](10) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Histo' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Histo [nvarchar](50) NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'Cyto_Type' AND LTRIM(b.name)='BXCY_SPECIMEN')
ALTER TABLE BXCY_SPECIMEN ADD Cyto_Type [nvarchar](50) NULL;


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_searchBXCYSpecimentRecord]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_searchBXCYSpecimentRecord]

CREATE PROCEDURE [dbo].[sp_searchBXCYSpecimentRecord]
	@caseDateFrom nvarchar(20)=NULL,
	@caseDateTo nvarchar(20)=NULL,
	@reportDateFrom nvarchar(20)=NULL,
	@reportDateTo nvarchar(20)=NULL,
	@caseNoFrom nvarchar(20)=NULL,
	@caseNoTo nvarchar(20)=NULL,
	@group nvarchar(20)=NULL,
	@tCode1 nvarchar(50)=NULL,
	@tCode2 nvarchar(50)=NULL,
	@tCode3 nvarchar(50)=NULL,
	@mCode1 nvarchar(50)=NULL,
	@mCode2 nvarchar(50)=NULL,
	@mCode3 nvarchar(50)=NULL,
	@cytoType nvarchar(50)=NULL,
	@histoType nvarchar(50)=NULL,
	@frozenSection nvarchar(10)=NULL,
	@keywordSite nvarchar(50)=NULL,
	@keywordOperation nvarchar(50)=NULL--,
	--@keywordDiagnosis text = NULL
AS
BEGIN
	SELECT * FROM BXCY_SPECIMEN
	WHERE (@caseDateFrom IS NULL OR @caseDateFrom = '' OR date >= convert(date,@caseDateFrom))
	AND (@caseDateTo IS NULL OR @caseDateTo ='' OR date <= convert(date,@caseDateTo))
	AND (@reportDateFrom IS NULL OR @reportDateFrom='' OR rpt_date >= convert(date,@reportDateFrom))
	AND (@reportDateTo IS NULL OR @reportDateTo='' OR rpt_date <= convert(date,@reportDateTo))
	AND (@caseNoFrom IS NULL OR @caseNoFrom='' OR case_no >= @caseNoFrom)
	AND (@caseNoTo IS NULL OR @caseNoTo='' OR case_no <= @caseNoTo)
	AND (@group IS NULL OR @group='' OR LOWER(LEFT(barcode,2)) = LOWER(@group))
	AND (@tCode1 IS NULL OR @tCode1='' OR LOWER(@tCode1) = LOWER(snopcode_t))
	AND (@tCode2 IS NULL OR @tCode2='' OR LOWER(@tCode2) = LOWER(snopcode_t2))
	AND (@tCode3 IS NULL OR @tCode3='' OR LOWER(@tCode3) = LOWER(snopcode_t3))
	AND (@mCode1 IS NULL OR @mCode1='' OR LOWER(@mCode1) = LOWER(snopcode_m))
	AND (@mCode2 IS NULL OR @mCode2='' OR LOWER(@mCode2) = LOWER(snopcode_m2))
	AND (@mCode3 IS NULL OR @mCode3='' OR LOWER(@mCode3) = LOWER(snopcode_m3))
	AND (@cytoType IS NULL OR @cytoType='' OR LOWER(Cyto_Type) = LOWER(@cytoType))
	AND (@histoType IS NULL OR @histoType='' OR LOWER(Histo) = LOWER(@histoType))
	AND (@frozenSection IS NULL OR @frozenSection ='' OR LOWER(fz_section) = LOWER(@frozenSection))
	AND (@keywordSite IS NULL OR @keywordSite = '' OR @keywordOperation IS NULL OR @keywordOperation = ''
	--OR @keywordDiagnosis IS NULL 
	OR case_no IN
	(SELECT case_no FROM BXCY_DIAG
	WHERE (@keywordSite IS NULL OR @keywordSite = '' OR LOWER(site) = LOWER(@keywordSite))
	AND (@keywordOperation IS NULL OR @keywordOperation = '' OR LOWER(operation) = LOWER(@keywordOperation))
	--AND (@keywordDiagnosis IS NULL OR diagnosis = @keywordDiagnosis)
	))
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='BXCY_DIAG')
BEGIN
ALTER TABLE BXCY_DIAG ADD [id] [int] IDENTITY(1,1) NOT NULL
ALTER TABLE BXCY_DIAG ADD CONSTRAINT [PK_bxcy_diag] primary key (ID)
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_searchEBVSpecimentRecord]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_searchEBVSpecimentRecord]

CREATE PROCEDURE [dbo].[sp_searchEBVSpecimentRecord]
	@caseDateFrom nvarchar(20)=NULL,
	@caseDateTo nvarchar(20)=NULL,
	@reportDateFrom nvarchar(20)=NULL,
	@reportDateTo nvarchar(20)=NULL,
	@caseNoFrom nvarchar(20)=NULL,
	@caseNoTo nvarchar(20)=NULL,
	@group nvarchar(20)=NULL,
	@keywordRemind nvarchar(50)=NULL,
	@keywordDiagnosis nvarchar(50) = NULL
AS
BEGIN
	SELECT * FROM EBV_SPECIMEN
	WHERE (@caseDateFrom IS NULL OR @caseDateFrom = '' OR date >= convert(date,@caseDateFrom))
	AND (@caseDateTo IS NULL OR @caseDateTo ='' OR date <= convert(date,@caseDateTo))
	AND (@reportDateFrom IS NULL OR @reportDateFrom='' OR rpt_date >= convert(date,@reportDateFrom))
	AND (@reportDateTo IS NULL OR @reportDateTo='' OR rpt_date <= convert(date,@reportDateTo))
	AND (@caseNoFrom IS NULL OR @caseNoFrom='' OR case_no >= @caseNoFrom)
	AND (@caseNoTo IS NULL OR @caseNoTo='' OR case_no <= @caseNoTo)
	AND (@group IS NULL OR @group='' OR LOWER(LEFT(barcode,2)) = LOWER(@group))
	AND (@keywordDiagnosis IS NULL OR @keywordDiagnosis = '' OR LOWER(diagnosis) = LOWER(@keywordDiagnosis))
	AND (@keywordRemind IS NULL OR @keywordRemind = '' OR LOWER(remind) = LOWER(@keywordRemind))
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getBXCYSpecimentByPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[getBXCYSpecimentByPage]

CREATE PROCEDURE getBXCYSpecimentByPage
	-- Add the parameters for the stored procedure here
	@pageCount int = 30,
	@pageNum int = 1,
	@whereStr nvarchar(100) = '',
	@whereVal nvarchar(100) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @pageSum INT
	DECLARE @sqlQuery NVARCHAR(max)=''
	DECLARE @sqlQueryCount NVARCHAR(max)=''

	IF @pageNum < 1
	BEGIN
		SET @pageNum = 1
	END

	IF @whereStr <> ''
	BEGIN
		SET @sqlQuery = 
		'SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,fz_section,snopcode_m,snopcode_t,cy_report,isnull(sign_dr,'''') + ''' + '/ ' + ''' + isnull(sign_dr2,'''') as sign_dr,er,em,id FROM BXCY_SPECIMEN
		WHERE id >
		(
		 SELECT ISNULL(MAX(id),0)
		 FROM 
		  (
		   SELECT TOP (@pageCount * (@pageNum - 1)) id FROM BXCY_SPECIMEN WHERE ' + @whereStr + ' LIKE ''%' + @whereVal + '%'' ORDER BY id
		  ) A
		)
		AND ' + @whereStr + ' LIKE ''%' + @whereVal + '%''
		ORDER BY case_no,id'
		SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM BXCY_SPECIMEN WHERE ' + @whereStr + ' LIKE ''%' + @whereVal + '%'''

		EXEC SP_EXECUTESQL @sqlQuery, N'@pageCount int,@pageNum int', @pageCount,@pageNum

		EXEC SP_EXECUTESQL @sqlQueryCount, N'@pageSum int out,@pageCount int', @pageSum out,@pageCount
	END
	ELSE
	BEGIN
		SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,fz_section,snopcode_m,snopcode_t,cy_report,isnull(sign_dr,'') + '/' + isnull(sign_dr2,'') as sign_dr,er,em,id FROM BXCY_SPECIMEN
		WHERE id >
		(
		 SELECT ISNULL(MAX(id),0)
		 FROM 
		  (
		   SELECT TOP (@pageCount * (@pageNum - 1)) id FROM BXCY_SPECIMEN ORDER BY case_no,id
		  ) A
		)
		ORDER BY case_no,id
		
		SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM BXCY_SPECIMEN
	END

	--SET @recordCount = @pageSum
	RETURN @pageSum
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getEBVSpecimentByPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[getEBVSpecimentByPage]

CREATE PROCEDURE getEBVSpecimentByPage
	-- Add the parameters for the stored procedure here
	@pageCount int = 30,
	@pageNum int = 1,
	@whereStr nvarchar(100) = '',
	@whereVal nvarchar(100) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @pageSum INT
	DECLARE @sqlQuery NVARCHAR(max)=''
	DECLARE @sqlQueryCount NVARCHAR(max)=''

	IF @pageNum < 1
	BEGIN
		SET @pageNum = 1
	END

	IF @whereStr <> ''
	BEGIN
		SET @sqlQuery = 
		'SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,id FROM EBV_SPECIMEN
		WHERE id >
		(
		 SELECT ISNULL(MAX(id),0)
		 FROM 
		  (
		   SELECT TOP (@pageCount * (@pageNum - 1)) id FROM EBV_SPECIMEN WHERE ' + @whereStr + ' LIKE ''%' + @whereVal + '%'' ORDER BY id
		  ) A
		)
		AND ' + @whereStr + ' LIKE ''%' + @whereVal + '%''
		ORDER BY case_no,id'
		SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM EBV_SPECIMEN WHERE ' + @whereStr + ' LIKE ''%' + @whereVal + '%'''

		EXEC SP_EXECUTESQL @sqlQuery, N'@pageCount int,@pageNum int', @pageCount,@pageNum

		EXEC SP_EXECUTESQL @sqlQueryCount, N'@pageSum int out,@pageCount int', @pageSum out,@pageCount
	END
	ELSE
	BEGIN
		SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_ID,id FROM EBV_SPECIMEN
		WHERE id >
		(
		 SELECT ISNULL(MAX(id),0)
		 FROM 
		  (
		   SELECT TOP (@pageCount * (@pageNum - 1)) id FROM EBV_SPECIMEN ORDER BY case_no,id
		  ) A
		)
		ORDER BY case_no,id
		
		SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM EBV_SPECIMEN
	END

	--SET @recordCount = @pageSum
	RETURN @pageSum
END
GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[description]') AND type in (N'U'))
CREATE TABLE [dbo].[description](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nchar](10) NULL,
 CONSTRAINT [PK_description] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO description(description) VALUES('Figure 1');
INSERT INTO description(description) VALUES('Figure 2');
INSERT INTO description(description) VALUES('Figure 3');
INSERT INTO description(description) VALUES('Figure 4');
INSERT INTO description(description) VALUES('Figure 5');
INSERT INTO description(description) VALUES('Figure 6');
INSERT INTO description(description) VALUES('Figure 7');
INSERT INTO description(description) VALUES('Figure 8');
INSERT INTO description(description) VALUES('Figure 9');
INSERT INTO description(description) VALUES('Figure 10');
INSERT INTO description(description) VALUES('Figure 11');
INSERT INTO description(description) VALUES('Figure 12');
INSERT INTO description(description) VALUES('Figure 13');
INSERT INTO description(description) VALUES('Figure 14');
GO


IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[marco_name]') AND type in (N'U'))
CREATE TABLE [dbo].[marco_name](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marco_name] [nvarchar](200) NULL,
 CONSTRAINT [PK_marco_name] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO marco_name(marco_name) VALUES('MACROSCOPIC EXAMINATION:');
INSERT INTO marco_name(marco_name) VALUES('FROZEN SECION REPORT:');
INSERT INTO marco_name(marco_name) VALUES('SUPPLEMENTARY REPORT:');
GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MACROSCOPIC_Report]') AND type in (N'U'))
CREATE TABLE [dbo].[MACROSCOPIC_Report](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MACROSCOPIC] [nvarchar](255) NULL,
	[Description] [nvarchar](3000) NULL,
	[UPDATE_BY] [nvarchar](255) NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_CTR] [nvarchar](255) NULL,
 CONSTRAINT [PK_MACROSCOPIC_Report] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MICROSCOPIC_Report]') AND type in (N'U'))
CREATE TABLE [dbo].[MICROSCOPIC_Report](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MICROSCOPIC] [nvarchar](255) NULL,
	[Description] [nvarchar](3000) NULL,
	[UPDATE_BY] [nvarchar](255) NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_CTR] [nvarchar](255) NULL,
 CONSTRAINT [PK_MICROSCOPIC_Report] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='macro_template')
BEGIN
ALTER TABLE macro_template ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE macro_template ADD CONSTRAINT [PK_macro_template] primary key (ID);
END


IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='micro_template')
BEGIN
ALTER TABLE micro_template ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE micro_template ADD CONSTRAINT [PK_micro_template] primary key (ID);
END

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[micro_name]') AND type in (N'U'))
CREATE TABLE [dbo].[micro_name](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[micro_name] [nvarchar](200) NULL,
 CONSTRAINT [PK_micro_name] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO micro_name(micro_name) VALUES('MICROSCOPIC EXAMINATION:');
INSERT INTO micro_name(micro_name) VALUES('CYTOLOGICAL EXAMINATION:');
INSERT INTO micro_name(micro_name) VALUES('IMMUNOFLUORESCENCE EXAMIN:');
GO

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='diag_desc')
BEGIN
ALTER TABLE diag_desc ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE diag_desc ADD CONSTRAINT [PK_diag_desc] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='picture_cap')
BEGIN
ALTER TABLE picture_cap ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE picture_cap ADD CONSTRAINT [PK_picture_cap] primary key (ID);
END

DELETE FROM picture_cap WHERE CAPTION IS NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='site')
BEGIN
ALTER TABLE site ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE site ADD CONSTRAINT [PK_site] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='operation')
BEGIN
ALTER TABLE operation ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE operation ADD CONSTRAINT [PK_operation] primary key (ID);
END
