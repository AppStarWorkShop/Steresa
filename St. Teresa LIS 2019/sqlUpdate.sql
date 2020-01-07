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
GO


CREATE PROCEDURE [dbo].[getBXCYSpecimentByPage]
	-- Add the parameters for the stored procedure here
	@pageCount int = 30,
	@pageNum int = 1,
	@whereStr nvarchar(100) = '',
	@whereVal nvarchar(100) = '',
	@snopCode nvarchar(100) ='',
	@dateMode int = 1,
	@dateFrom nvarchar(10)='',
	@dateTo nvarchar(10)=''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @pageSum INT=0
	DECLARE @sqlQuery NVARCHAR(max)=''
	DECLARE @sqlQueryCount NVARCHAR(max)=''
	DECLARE @dateQuery NVARCHAR(max)=''
	DECLARE @orderBy NVARCHAR(100)=''

	IF @pageCount IS NULL
	BEGIN
		SET @pageCount = 30
	END

	IF @pageNum IS NULL OR @pageNum < 1
	BEGIN
		SET @pageNum = 1
	END

	IF @whereStr IS NULL
	BEGIN
		SET @whereStr=''
	END

	IF @whereVal IS NULL
	BEGIN
		SET @whereVal=''
	END

	IF @snopCode IS NULL
	BEGIN
		SET @snopCode=''
	END

	IF @dateMode IS NULL OR @dateMode < 1 OR @dateMode > 5
	BEGIN
		SET @dateMode = 1
	END

	IF @dateMode = 1
	BEGIN
		SET @dateQuery=''
		--SET @dateQuery=' AND date >= CAST(DATEADD(dd,-2,getDate()) AS date) AND date <= CAST(DATEADD(dd,1,getDate()) AS date)'
	END
	ELSE
	BEGIN
		IF @dateMode = 2
		BEGIN
			SET @dateQuery=' AND date >= CAST(DATEADD(dd,-7,getDate()) AS date) '
		END
		ELSE
		BEGIN
			IF @dateMode = 3
			BEGIN
				SET @dateQuery=' AND date >= CAST(DATEADD(dd,-14,getDate()) AS date) '
			END
			ELSE
			BEGIN
				IF @dateMode = 4
				BEGIN
					SET @dateQuery=' AND date >= CAST(DATEADD(dd,-28,getDate()) AS date) '
				END
				ELSE
				BEGIN
					SET @dateQuery=' AND date >= CAST(@dateFrom AS date) AND date <= CAST(@dateTo AS date) '
				END
			END
		END
	END

	IF @dateFrom IS NULL
	BEGIN
		SET @dateFrom=''
	END

	IF @dateTo IS NULL
	BEGIN
		SET @dateTo=''
	END	

	IF @whereStr <> '' AND @whereVal <> ''
	BEGIN
		set @orderBy = ' case_no'
		if @whereStr <> ''
		BEGIN
			if 'PATIENT' = UPPER(@whereStr) 
				BEGIN
					set @orderBy = ' patient, case_no'
				END
		END
		
		if 'DOCTOR_ID' = UPPER(@whereStr)
		begin
			SET @sqlQuery = 
			'SELECT TOP @pageCount) CASE_NO,RPT_DATE,PATIENT,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_IC,fz_section,snopcode_m,snopcode_t,cy_report,isnull(sign_dr,'''') + ''' + '/ ' + ''' + isnull(sign_dr2,'''') as sign_dr,er,em,id,pat_seq,LAB_REF,DOCTOR_ID 
			FROM 
			(
			SELECT row_number()over(order by ' + @orderBy + ' )rownumber,* FROM BXCY_SPECIMEN WHERE (doctor_ic like ''' + @whereVal + '%'' or doctor_ic2 like ''' + @whereVal + '%'' or doctor_ic3 like''' + @whereVal + '%'' ) ' + @dateQuery + '
			) A
			WHERE rownumber >' + CAST(@pageCount*(@pageNum-1) AS NVARCHAR(100))
			SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM BXCY_SPECIMEN WHERE (doctor_ic LIKE ''' + @whereVal + '%'' or doctor_ic2 like ''' + @whereVal + '%'' or doctor_ic3 like''' + @whereVal + '%'') ' + @dateQuery
		end
		ELSE
		begin 
			SET @sqlQuery = 
			'SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_IC,fz_section,snopcode_m,snopcode_t,cy_report,isnull(sign_dr,'''') + ''' + '/ ' + ''' + isnull(sign_dr2,'''') as sign_dr,er,em,id,pat_seq,LAB_REF,DOCTOR_ID 
			FROM 
			(
			SELECT row_number()over(order by ' + @orderBy + ' )rownumber,* FROM BXCY_SPECIMEN WHERE ' + @whereStr + ' LIKE ''' + @whereVal + '%''' + @dateQuery + '
			) A
			WHERE rownumber >' + CAST(@pageCount*(@pageNum-1) AS NVARCHAR(100))
			SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM BXCY_SPECIMEN WHERE ' + @whereStr + ' LIKE ''' + @whereVal + '%''' + @dateQuery
		END
		

	END
	ELSE
	BEGIN
		SET @sqlQuery = 
		'SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_IC,fz_section,snopcode_m,snopcode_t,cy_report,isnull(sign_dr,'''') + ''' + '/ ' + ''' + isnull(sign_dr2,'''') as sign_dr,er,em,id,pat_seq,LAB_REF,DOCTOR_ID \
		FROM 
		(
		SELECT row_number()over(order by case_no )rownumber,* FROM BXCY_SPECIMEN WHERE (@snopCode IS NULL OR @snopCode = '''' OR SNOPCODE_T LIKE ''' + @snopCode + '%'' OR SNOPCODE_T2 LIKE ''' + @snopCode + '%'' OR SNOPCODE_T3 LIKE ''' + @snopCode + '%'')' + @dateQuery + '
		) A
		WHERE rownumber >' + CAST(@pageCount*(@pageNum-1) AS NVARCHAR(100))
		SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM BXCY_SPECIMEN WHERE (@snopCode IS NULL OR @snopCode = '''' OR SNOPCODE_T LIKE ''' + @snopCode + '%'' OR SNOPCODE_T2 LIKE ''' + @snopCode + '%'' OR SNOPCODE_T3 LIKE ''' + @snopCode + '%'')' + @dateQuery
	END

	PRINT @sqlQuery
	PRINT @sqlQueryCount
	EXEC SP_EXECUTESQL @sqlQuery, N'@pageCount int,@pageNum int,@snopCode nvarchar(100),@dateFrom nvarchar(10),@dateTo nvarchar(10)', @pageCount,@pageNum,@snopCode,@dateFrom,@dateTo
	EXEC SP_EXECUTESQL @sqlQueryCount, N'@pageSum int out,@pageCount int,@snopCode nvarchar(100),@dateFrom nvarchar(10),@dateTo nvarchar(10)', @pageSum out,@pageCount,@snopCode,@dateFrom,@dateTo

	--SET @recordCount = @pageSum
	RETURN @pageSum
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getEBVSpecimentByPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[getEBVSpecimentByPage]
GO

CREATE PROCEDURE getEBVSpecimentByPage
	-- Add the parameters for the stored procedure here
	@pageCount int = 30,
	@pageNum int = 1,
	@whereStr nvarchar(100) = '',
	@whereVal nvarchar(100) = '',
	@dateMode int = 1,
	@dateFrom nvarchar(10)='',
	@dateTo nvarchar(10)=''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @pageSum INT=0
	DECLARE @sqlQuery NVARCHAR(max)=''
	DECLARE @sqlQueryCount NVARCHAR(max)=''
	DECLARE @dateQuery NVARCHAR(max)=''

	IF @pageCount IS NULL
	BEGIN
		SET @pageCount = 30
	END

	IF @pageNum IS NULL OR @pageNum < 1
	BEGIN
		SET @pageNum = 1
	END

	IF @whereStr IS NULL
	BEGIN
		SET @whereStr=''
	END

	IF @whereVal IS NULL
	BEGIN
		SET @whereVal=''
	END

	IF @dateMode IS NULL OR @dateMode < 1 OR @dateMode > 5
	BEGIN
		SET @dateMode = 1
	END

	IF @dateMode = 1
	BEGIN
		--SET @dateQuery=''
		SET @dateQuery=' AND date >= CAST(DATEADD(dd,-2,getDate()) AS date) AND date <= CAST(DATEADD(dd,1,getDate()) AS date)'
	END
	ELSE
	BEGIN
		IF @dateMode = 2
		BEGIN
			SET @dateQuery=' AND date >= CAST(DATEADD(dd,-7,getDate()) AS date) '
		END
		ELSE
		BEGIN
			IF @dateMode = 3
			BEGIN
				SET @dateQuery=' AND date >= CAST(DATEADD(dd,-14,getDate()) AS date) '
			END
			ELSE
			BEGIN
				IF @dateMode = 4
				BEGIN
					SET @dateQuery=' AND date >= CAST(DATEADD(dd,-28,getDate()) AS date) '
				END
				ELSE
				BEGIN
					SET @dateQuery=' AND date >= CAST(@dateFrom AS date) AND date <= CAST(@dateTo AS date) '
				END
			END
		END
	END

	IF @dateFrom IS NULL
	BEGIN
		SET @dateFrom=''
	END

	IF @dateTo IS NULL
	BEGIN
		SET @dateTo=''
	END	

	IF @whereStr <> '' AND @whereVal <> ''
	BEGIN
		SET @sqlQuery = 
		'SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_IC,id,pat_seq,result,diagnosis,date,LAB_REF,DOCTOR_ID 
		FROM 
		(
		SELECT row_number()over(order by id)rownumber,* FROM EBV_SPECIMEN WHERE ' + @whereStr + ' LIKE ''' + @whereVal + '%''' + @dateQuery + '
		) A
		WHERE rownumber >' + CAST(@pageCount*(@pageNum-1) AS NVARCHAR(100)) 
		SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM EBV_SPECIMEN WHERE ' + @whereStr + ' LIKE ''' + @whereVal + '%''' + @dateQuery
	END
	ELSE
	BEGIN
		SET @sqlQuery = 
		'SELECT TOP (@pageCount) CASE_NO,RPT_DATE,PATIENT,VER,PAT_AGE,PAT_SEX,PAT_HKID,CLIENT,DOCTOR_IC,id,pat_seq,result,diagnosis,date,LAB_REF,DOCTOR_ID 
		FROM
		(
		SELECT row_number()over(order by id)rownumber,* FROM EBV_SPECIMEN WHERE id=id ' + @dateQuery + '
		) A
		WHERE rownumber >' + CAST(@pageCount*(@pageNum-1) AS NVARCHAR(100))
		SET @sqlQueryCount = 'SELECT @pageSum = CEILING(CAST(COUNT(*) as numeric(18,2))/@pageCount) FROM EBV_SPECIMEN WHERE id=id ' + @dateQuery
	END

	PRINT @sqlQuery
	PRINT @sqlQueryCount

	EXEC SP_EXECUTESQL @sqlQuery, N'@pageCount int,@pageNum int,@dateFrom nvarchar(10),@dateTo nvarchar(10)', @pageCount,@pageNum,@dateFrom,@dateTo
	EXEC SP_EXECUTESQL @sqlQueryCount, N'@pageSum int out,@pageCount int,@dateFrom nvarchar(10),@dateTo nvarchar(10)', @pageSum out,@pageCount,@dateFrom,@dateTo

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

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurgicalProcedure]') AND type in (N'U'))
CREATE TABLE [dbo].SurgicalProcedure(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SurgicalProcedureVal] [nvarchar](255) NULL,
	[Description] [nvarchar](3000) NULL,
	[UPDATE_BY] [nvarchar](255) NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_CTR] [nvarchar](255) NULL,
 CONSTRAINT [PK_SurgicalProcedure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NatureOfSpecimen]') AND type in (N'U'))
CREATE TABLE [dbo].NatureOfSpecimen(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SurgicalProcedureVal] [nvarchar](255) NULL,
	[Description] [nvarchar](3000) NULL,
	[UPDATE_BY] [nvarchar](255) NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_CTR] [nvarchar](255) NULL,
 CONSTRAINT [PK_NatureOfSpecimen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='cy_result')
BEGIN
ALTER TABLE cy_result ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE cy_result ADD CONSTRAINT [PK_cy_result] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='sign_doctor')
BEGIN
ALTER TABLE sign_doctor ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE sign_doctor ADD CONSTRAINT [PK_sign_doctor] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'STH_CY' AND LTRIM(b.name)='SYSTEM_SETTING')
BEGIN
ALTER TABLE system_setting ADD [STH_CY] [float] NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'STH_CYG' AND LTRIM(b.name)='SYSTEM_SETTING')
BEGIN
ALTER TABLE system_setting ADD [STH_CYG] [float] NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'STH_EBV' AND LTRIM(b.name)='SYSTEM_SETTING')
BEGIN
ALTER TABLE system_setting ADD [STH_EBV] [float] NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='frozen_section')
BEGIN
ALTER TABLE frozen_section ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE frozen_section ADD CONSTRAINT [PK_frozen_section] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'sish' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD sish nvarchar(1) NULL;
END

UPDATE BXCY_SPECIMEN SET fz_section='1' where fz_section='Y'
UPDATE BXCY_SPECIMEN SET fz_section='0' where fz_section<>'1'
ALTER table BXCY_SPECIMEN alter column fz_section bit
UPDATE BXCY_SPECIMEN SET fz_section=0 where fz_section IS NULL
ALTER table BXCY_SPECIMEN alter column Pat_hist nvarchar(max)

IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clinical_History_Edit_Log]') AND type in (N'U'))
CREATE TABLE [dbo].Clinical_History_Edit_Log(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[case_no] [nvarchar](15) NULL,
	[Update_Content] [nvarchar](max) NULL,
	[UPDATE_BY] [nvarchar](255) NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_TIME] [datetime] NULL,
 CONSTRAINT [PK_Clinical_History_Edit_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



DROP TRIGGER [dbo].[BXCY_SPECIMEN_INSERTORUPDATE]
GO

CREATE TRIGGER [dbo].[BXCY_SPECIMEN_INSERTORUPDATE]
   ON  [dbo].[BXCY_SPECIMEN] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	DECLARE @case_no nvarchar(15)
	DECLARE @maxId int


	DECLARE @Pat_hist nvarchar(max)
	DECLARE @Last_Pat_hist nvarchar(max)

	SELECT @case_no = case_no, @Pat_hist = Pat_hist FROM INSERTED
	SET @Last_Pat_hist = ''
	SELECT TOP 1 @Last_Pat_hist = update_content FROM Clinical_History_Edit_Log WHERE case_no = @case_no ORDER BY ID DESC

	IF @Last_Pat_hist = ''
	BEGIN
		INSERT INTO Clinical_History_Edit_Log(case_no, update_content, update_by, update_at)
			SELECT case_no, Pat_hist, update_by, update_at FROM INSERTED
	END
	ELSE
	BEGIN
		IF @Last_Pat_hist <> @Pat_hist
		BEGIN
			INSERT INTO Clinical_History_Edit_Log(case_no, update_content, update_by, update_at)
				SELECT case_no, Pat_hist, update_by, update_at FROM INSERTED
		END
	END

END
GO



DROP TRIGGER [dbo].[BXCY_SPECIMEN_DELETE]
GO

CREATE TRIGGER [dbo].[BXCY_SPECIMEN_DELETE]
   ON  [dbo].[BXCY_SPECIMEN] 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	DECLARE @case_no nvarchar(15)

	SELECT @case_no = case_no FROM DELETED

	IF EXISTS(SELECT * FROM Clinical_History_Edit_Log WHERE case_no = @case_no)
	BEGIN
		DELETE FROM Clinical_History_Edit_Log WHERE case_no = @case_no
	END
END
GO

UPDATE BXCY_SPECIMEN SET uploaded='1' where uploaded='Y';
UPDATE BXCY_SPECIMEN SET uploaded='0' where uploaded<>'1';
ALTER table BXCY_SPECIMEN alter column uploaded bit;
UPDATE BXCY_SPECIMEN SET uploaded=0 where uploaded IS NULL;

ALTER table BXCY_SPECIMEN alter column supp bit;
UPDATE BXCY_SPECIMEN SET supp=0 where supp IS NULL;


UPDATE ebv_specimen SET uploaded='1' where uploaded='Y';
UPDATE ebv_specimen SET uploaded='0' where uploaded<>'1';
ALTER table ebv_specimen alter column uploaded bit;
UPDATE ebv_specimen SET uploaded=0 where uploaded IS NULL;

UPDATE ebv_specimen SET TUMOUR='1' where TUMOUR='Y';
UPDATE ebv_specimen SET TUMOUR='0' where TUMOUR<>'1';
ALTER table ebv_specimen alter column TUMOUR bit;
UPDATE ebv_specimen SET TUMOUR=0 where TUMOUR IS NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='cy_diag_hdr')
BEGIN
ALTER TABLE cy_diag_hdr ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE cy_diag_hdr ADD CONSTRAINT [PK_cy_diag_hdr] primary key (ID);
END

UPDATE cy_diag_hdr SET IUCD='1' where IUCD='Y';
UPDATE cy_diag_hdr SET IUCD='0' where IUCD<>'1';
alter table cy_diag_hdr alter column IUCD bit null;
UPDATE cy_diag_hdr SET IUCD=0 where IUCD IS NULL;

UPDATE cy_diag_hdr SET HORMONAL='1' where HORMONAL='Y';
UPDATE cy_diag_hdr SET HORMONAL='0' where HORMONAL<>'1';
alter table cy_diag_hdr alter column HORMONAL bit null;
UPDATE cy_diag_hdr SET HORMONAL=0 where HORMONAL IS NULL;

alter table BXCY_SPECIMEN alter column Doctor_ic2 nvarchar(40) null;
alter table BXCY_SPECIMEN alter column Doctor_ic3 nvarchar(40) null;

alter table BXCY_SPECIMEN alter column doctor_o nvarchar(500) null;

-- 2019-12-03
create view [dbo].[v_reportHeader] (case_no, patient, cname, pat_hkid, org_case_no, record_status, pat_age_str, hkas, report_number, lastUpdateInitial) as
select dbo.reportCaseNo(s.case_no), Rtrim(s.patient) as patient, Rtrim(s.cname) as cname, Rtrim(s.pat_hkid) as pat_hkid, s.case_no as org_case_no
, dbo.fn_recordStatus(s.case_no) as record_status, dbo.reportAge(s.pat_age) as pat_age_str, '1' as hkas, '1' as report_number 
, u.INITIAL
from BXCY_SPECIMEN s left join [user] u on (s.update_by = u.[USER_ID])

-------------------------------------------------------------
-- 2019-12-05
-------------------------------------------------------------
DROP FUNCTION [dbo].[fn_recordStatus]

create function [dbo].[fn_recordStatus](@case_no nvarchar(15))
returns nvarchar(10)
as begin
	DECLARE @bCount int;
	declare @cCount int;
	declare @gCount int;
	declare @rStatus nvarchar(10);
	
	select @bCount = COUNT(1) from
	BXCY_SPECIMEN 
	where pat_hkid in (
		select s.pat_hkid
		from BXCY_SPECIMEN s where s.case_no = @case_no
	)
	and case_no <> @case_no
	AND case_no like 'BX%'
	;
	
	select @cCount = COUNT(1) from
	BXCY_SPECIMEN 
	where pat_hkid in (
		select s.pat_hkid
		from BXCY_SPECIMEN s where s.case_no = @case_no
	)
	and case_no <> @case_no
	AND case_no like 'CY%' AND case_no not like '%G'
	
	select @gCount= COUNT(1) from
	BXCY_SPECIMEN 
	where pat_hkid in (
		select s.pat_hkid
		from BXCY_SPECIMEN s where s.case_no = @case_no
	)
	and case_no <> @case_no
	AND case_no like 'CY%G'
	
	IF @bCount > 0 
	begin 
		SET @rStatus = 'B '
	End
	
	IF @cCount > 0
	begin
		SET @rStatus = @rStatus + 'C '
	end
	
	IF @gCount > 0
	begin
		SET @rStatus = @rStatus + 'G '
	end 
	
	return Rtrim(@rStatus);
end
;

GO

DROP FUNCTION [dbo].[reportAge]
GO

create function [dbo].[reportAge](
	@age decimal(5, 2)
)
returns varchar(10)
AS
BEGIN
	return cast( cast((@age) as integer)  as varchar) + 'Yr' + cast( cast((@age % 1) * 12 as integer)  as varchar) + 'M'
END;
GO

DROP FUNCTION [dbo].[reportCaseNo]
GO


create function [dbo].[reportCaseNo](
	@caseNo nvarchar(15)
)
returns nvarchar(15)
AS
Begin
	return replace(replace(@caseNo, 'BX', 'B'), 'CY', '');
	
END;
GO


CREATE INDEX idx_bxcy_diag_caseNo ON [BXCY_DIAG] ([case_no])
CREATE INDEX idx_bxcy_specimen_case_no ON [BXCY_SPECIMEN] ([case_no])
CREATE INDEX idx_bxcy_specimen_patient ON [BXCY_SPECIMEN] ([patient])
CREATE INDEX idx_bxcy_specimen_date ON [BXCY_SPECIMEN] ([date])
CREATE INDEX idx_bxcy_specimen_doctor ON [BXCY_SPECIMEN] ([doctor_ic])
CREATE INDEX idx_bxcy_specimen_hkid ON [BXCY_SPECIMEN] ([pat_hkid])
CREATE INDEX idx_bxcy_specimen_client ON [BXCY_SPECIMEN] ([client])
CREATE INDEX idx_bxcy_specimen_snop_t1 ON [BXCY_SPECIMEN] ([snopcode_t])
CREATE INDEX idx_bxcy_specimen_snop_t2 ON [BXCY_SPECIMEN] ([snopcode_t2])
CREATE INDEX idx_bxcy_specimen_snop_t3 ON [BXCY_SPECIMEN] ([snopcode_t3])
CREATE INDEX idx_bxcy_specimen_caseno_id ON [BXCY_SPECIMEN] ([case_no], [id])
CREATE INDEX idx_bxcy_specimen_id ON [BXCY_SPECIMEN] ([id])
CREATE INDEX idx_bxcy_specimen_lab_ref ON [BXCY_SPECIMEN] ([lab_ref])
CREATE INDEX idx_bxcy_specimen_doctor_2 ON [BXCY_SPECIMEN] ([Doctor_ic2])
CREATE INDEX idx_bxcy_specimen_doctor_3 ON [BXCY_SPECIMEN] ([Doctor_ic3])

create view [dbo].[v_hisReportContent] (case_no, pathNo, visitNo, versionNo
,reportDateTime, orderDoctorCode,orderDoctorName
, copy1DoctorCode, copy1DoctorName
, copy2DoctorCode, copy2DoctorName
, copy3DoctorCode, copy3DoctorName
, copy4DoctorCode, copy4DoctorName
, copy5DoctorCode, copy5DoctorName
, approvedDoctorName, clinicalHistory
, [site], [operation]
, diagnosis
, siteChi, operationChi
, diagnosisChi )
as 
select s.case_no, dbo.reportCaseNo(s.case_no) as pathNo, s.lab_ref as visitNo, d.[group] as versionNo
, s.[date] as reportDateTime
, s.doctor_id as orderDoctorCode, s.doctor_ic as orderDoctorName
, s.Doctor_id2 as copy1DoctorCode, s.Doctor_ic2 as copy1DoctorName
, s.Doctor_id3 as copy2DoctorCode, s.Doctor_ic3 as copy2DoctorName
, '' as copy3DoctorCode, '' as copy3DoctorName
, '' as copy4DoctorCode, '' as copy4DoctorName
, '' as copy5DoctorCode, '' as copy5DoctorName
, s.sign_dr as approvedDoctorName
, s.pat_hist as clinicalHistory
, d.[site] as [site], d.operation as [operation]
, d.diagnosis
, d.[site2] as 'siteChi', d.operation2 as 'operationChi'
, d.diag_desc1 as 'diagnosisChi'
from BXCY_SPECIMEN s inner join BXCY_DIAG d on (s.case_no = d.case_no)
GO
/****** Object:  View [dbo].[View_bxcy_spe_diag]    Script Date: 12/05/2019 09:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_bxcy_spe_diag]
AS
SELECT        dbo.BXCY_DIAG.case_no AS Expr1, dbo.BXCY_DIAG.barcode, dbo.BXCY_SPECIMEN.ver, dbo.BXCY_SPECIMEN.date, dbo.BXCY_SPECIMEN.client, 
                         dbo.BXCY_SPECIMEN.sign_dr2, dbo.BXCY_SPECIMEN.sign_dr, dbo.BXCY_SPECIMEN.rpt_date, dbo.BXCY_SPECIMEN.patient, dbo.BXCY_SPECIMEN.cname, 
                         dbo.BXCY_DIAG.site2, dbo.BXCY_DIAG.site, dbo.BXCY_DIAG.ver AS Expr2, dbo.BXCY_DIAG.[group], dbo.BXCY_DIAG.seq, dbo.BXCY_DIAG.operation, 
                         dbo.BXCY_DIAG.operation2, dbo.BXCY_DIAG.diag_desc1, dbo.BXCY_DIAG.diag_desc2, dbo.BXCY_DIAG.macro_name, dbo.BXCY_DIAG.macro_pic1, 
                         dbo.BXCY_DIAG.macro_cap1, dbo.BXCY_DIAG.macro_pic2, dbo.BXCY_DIAG.macro_cap2
FROM            dbo.BXCY_DIAG INNER JOIN
                         dbo.BXCY_SPECIMEN ON dbo.BXCY_DIAG.case_no = dbo.BXCY_SPECIMEN.case_no
WHERE        (dbo.BXCY_SPECIMEN.rpt_date > CONVERT(DATETIME, '2018-10-01 00:00:00', 102))
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BXCY_DIAG"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 263
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "BXCY_SPECIMEN"
            Begin Extent = 
               Top = 5
               Left = 277
               Bottom = 271
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1200
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_bxcy_spe_diag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_bxcy_spe_diag'
GO
/****** Object:  View [dbo].[v_reportHeader]    Script Date: 12/05/2019 09:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_reportHeader] (case_no, patient, cname, pat_hkid, org_case_no, record_status, pat_age_str, hkas, report_number, lastUpdateInitial) as
select dbo.reportCaseNo(s.case_no), Rtrim(s.patient) as patient, Rtrim(s.cname) as cname, Rtrim(s.pat_hkid) as pat_hkid, s.case_no as org_case_no
, dbo.fn_recordStatus(s.case_no) as record_status, dbo.reportAge(s.pat_age) as pat_age_str, '1' as hkas, '1' as report_number 
, u.INITIAL
from BXCY_SPECIMEN s left join [user] u on (s.update_by = u.[USER_ID])
GO


CREATE TABLE cy_result_temp (
   CODE nvarchar(5), 
   OPERATION nvarchar(60), 
   DIAGNOSIS nvarchar(4000), 
   DIAG_DESC1 nvarchar(40), 
   SNOP_M nvarchar(30), 
   MICRO_DESC nvarchar(4000), 
   UPDATE_BY nvarchar(10), 
   UPDATE_AT DATETIME, 
   UPDATE_CTR INTEGER, 
   UPDATED nvarchar(1));

alter table cy_result alter column diag_desc1 nvarchar(4000);
alter table cy_result alter column micro_desc nvarchar(4000);

INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('AS1', 'Peritoneal fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The ascitic fluid contains a small number of inflammatory cells including mostly polymorphs intermixed with scanty mesothelial cells. There is no malignant cell present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('AS2', 'Peritoneal fluid', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The ascitic fluid contains a moderate number of reactive mesothelial cells intermixed with inflammatory cells. Some atypical cells are present. They have slightly enlarged and hyperchromatic nuclei. No definite malignant cell is seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('AS4AD', 'Peritoneal fluid', 'Adenocarcinoma.', '腺癌', 'Carcinoma adeno', 'The ascitic fluid contains a moderate number of mesothelial cells and abnormal cells in clusters and in isolation. These cells have large vacuoles, enlarged irregular nuclei and nucleoli. The features are those of adenocarcinoma cells.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA0', 'Bronchial specimen', 'Low cellularity with no malignant cells present.', '無發現惡性細胞. 參看上文.', 'Inadequate specimen', 'The submitted bronchial specimen is hypocellular.  There are small numbers of inflammatory cells and epithelial cells present. No eosinophil is seen. Malignant cells are not detected.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA1', 'Bronchial specimen', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The submitted bronchial specimen shows the presence of macrophages, small number of bronchial epithelial cells, red blood cells and a small number of inflammatory cells. There is no malignant cell present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA1FU', 'Bronchial specimen', 'Negative for malignancy. Fungal organism present.', '無發現惡性細胞. 發現真菌.', 'No malignancy', 'The submitted bronchial specimen contains moderate number of inflammatory cells including polymorphs and lymphocytes. Scanty eosinophils are seen. Macrophages and bronchial epithelial cells are noted. Many fungal organisms consistent with Candida species are also observed. It is uncertain whether the latter is an oral contaminant. Please correlates with clinical findings. Malignant cells are not seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA1TB', 'Bronchial specimen', 'Negative for malignancy. See description.', '無發現惡性細胞. 參看上文.', 'No malignancy', 'The submitted bronchial specimen is blood stained.  There are moderate numbers of macrophages, some polymorphs, lymphocytes and unremarkable bronchial epithelial cells. No eosinophils are seen. Many mutinucleated cells are present. Tuberculosis cannot be excluded. There is no malignant cell present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA2', 'Bronchial specimen', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The submitted bronchial specimen contains some bronchial epithelial cells of normal morphology. A few clusters of epithelial cells show cellular atypia with nuclear enlargement and hyperchromatism. Malignancy cannot be excluded. Some inflammatory cells are also present. Please investigate further if indicated.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA3', 'Bronchial specimen', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The submitted bronchial specimen contains moderate number of bronchial epithelial cells of normal morphology.  A few clusters show cellular atypia with nuclear enlargement. Scanty macrophages and inflammatory cells are also present. The features are suspicious of malignancy.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA4AD', 'Bronchial specimen', 'Adenocarcinoma.', '腺癌', 'Carcinoma adeno', 'The submitted bronchial specimen contains many clusters of large epithelial cells with enlarged vesicular nuclei and prominent nucleoli. The features are compatible with adenocarcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA4NS', 'Bronchial specimen', 'Non-small cell carcinoma.', '非小細胞癌', 'Carcinoma, NOS', 'The submitted bronchial specimen contains large number of bronchial epithelial cells of normal morphology. Some inflammatory cells are also present. In addition, there are many clusters of cells with enlarged nuclei and nucleoli.  Some have vacuolated cytoplasm. The features are those of a non-small cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA4SC', 'Bronchial specimen', 'Small cell carcinoma.', '小細胞癌', 'Carcinoma small cell', 'The submitted bronchial specimen contains bronchial epithelial cells of normal morphology. Scanty macrophages and inflammatory cells are also present. In addition, there are a few clusters of small and medium-sized dysplastic cells with dark hyperchromatic nuclei and nuclear moulding. The features are in keeping with small cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BA4SQ', 'Bronchial specimen', 'Squamous cell carcinoma.', '鱗狀細胞癌', 'Carcinoma Squamous cell', 'The submitted bronchial specimen contains numerous bronchial epithelial cells of normal morphology. Scanty macrophages and inflammatory cells are also present. In addition, there are occasional clusters of keratinized cells with enlarged hyperchromatic nuclei and nucleoli. The features are those of a squamous cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BI1', 'Biliary brushing/ bile', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The specimen contains scanty inflammatory cells, red cells and some ductal epithelial cells.  There is no cellular atypia to suggest dysplasia. Malignant cells are not seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('BI2', 'Biliary brushing/ bile', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The specimen contains small number of inflammatory cells, red cells and some atypical ductal epithelium with slightly enlarged nuclei.  No overt malignant cell is seen.  Please investigate further if indicated.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('CS1', 'Cerebrospinal fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'Cytospin preparations of the CSF show no significant pathology. Only occasional lymphocytes are present. There are no malignant cells seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('CS1BL', 'Cerebrospinal fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'Cytospin preparation of the CSF shows some red blood cells and scanty white blood cells consistent with blood contamination. There is no evidence of infection. Malignant cells are not present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('CS4ML', 'Cerebrospinal fluid', 'Consistent with lymphoma / leukemia involvement.', '惡性淋巴瘤', 'Lymphoma malignant, NOS', 'Cytospin preparation of the CSF shows small number of mononuclear cells with medium sized nuclei and scanty cytoplasm.  The features are those of abnormal lymphoid cells consistent with lymphoma / leukemia involvement.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('JS1', 'Joint aspirate', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The joint fluid contains scanty inflammatory cells. Many red blood cells are seen. Crystals are not present. Specific pathogen is not identified. There is no malignant cell present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('JS1AI', 'Joint aspirate', 'Acute arthritis.', '急性關節炎', 'Inflammation, NOS', 'The joint fluid contains large number of inflammatory cells including mostly polymorphs. Scanty synovial cells with inflammatory changes are present. Crystals are not seen. Specific pathogen is not found. There is no malignant cell present. The features are those of acute arthritis. ', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('JS1GA', 'Joint aspirate', 'Gouty arthritis.', '痛風性關節炎', 'Inflammation, NOS', 'The joint fluid contains small number of inflammatory cells including mostly lymphocytes and scanty synovial cells. Red cells are present. Abundant needle-shaped crystals are present. They show negative birefringence under polarized light. Specific pathogen is not identified. There is no malignant cell present. The features are those of gouty arthritis. ', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('JS1IN', 'Joint aspirate', 'Inflammation.', '炎症', 'No malignancy', 'The joint fluid contains moderate number of inflammatory cells including polymorphs and lymphocytes. Many red blood cells are seen. Crystals are not present. Specific pathogen is not identified. There is no malignant cell present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI0', 'Nipple discharge', 'Negative for malignancy.', '無發現惡性細胞', 'Inadequate specimen', 'The smear of the nipple discharge shows that it is an acellular specimen. Epithelial or malignant cells are not seen. There is also no inflammatory cell included.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI1', 'Nipple discharge', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The smear of the nipple discharge shows that it is a hypocellular specimen. Some squames and scanty macrophages are present. No malignant cells are seen. There is also no inflammatory cell included.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI1AI', 'Nipple discharge', 'Suppurative inflammation.', '化膿性炎症', 'Inflammation,suppurative', 'The smear of the nipple discharge shows many polymorphs and some foam cells. There is no malignant cell seen. The features are those of suppurative inflammation.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI1DP', 'Nipple discharge', 'Benign ductal proliferation.', '良性乳房病變', 'No malignancy', 'The nipple discharge shows mainly blood. Some benign epithelial cells in papillary clusters are present. There is also no inflammatory cell included. The features are in keeping with benign ductal proliferation, such as intraduct papilloma. There is no evidence of malignancy.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI2', 'Nipple discharge', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The nipple specimen shows large number of inflammatory cells predominantly polymorphs. Clusters of atypical degenerated epithelial cells with enlarged hyperchromatic nuclei are found. Please investigate further.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI2PA', 'Nipple discharge', 'Papillary lesion.', '乳頭狀病變', 'Papilloma NOS', 'The specimen contains some clusters of epithelial cells arranged in papillary fragments. The epithelial cells show mild nuclear atypia. The features are suggestive of ductal papillary lesion. Please investigate further.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('NI3', 'Nipple discharge', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The nipple specimen shows some clusters of epithelial cells in an inflamed background. These cells show enlarged vesicular nuclei with small nucleoli. The features are suspicious of carcinoma. Further investigation is advisable.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PC1', 'Pericardial fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The pericardial fluid contains moderate number of inflammatory cells including mostly lymphocytes and some macrophages. Some mesothelial cells are also noted. Malignant cells are not seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PC2', 'Pericardial fluid', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The pericardial fluid contains a moderate number of cells including mesothelial cells, inflammatory cells and some clusters of degenerated cells with enlarged nuclei. The features are atypical. Please investigate further.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PC3', 'Pericardial fluid', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The pericardial fluid contains a moderate number of cells including mesothelial cells, inflammatory cells and clusters of cells with enlarged nuclei, open chromatin and occasional nucleoli. The features are suspicious of adenocarcinoma. Please investigate further.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PC4AD', 'Pericardial fluid', 'Metastatic adenocarcinoma.', '轉移癌', 'Carcinomatosis / Metastatic Ca', 'The pericardial fluid contains a large number of cells including mesothelial cells, inflammatory cells and clusters of cells with enlarged nuclei, hyperchromasia and occasional nucleoli. The cytoplasm is focally vacuolated. The features are those of pericardial involvement by metastatic adenocarcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL1', 'Pleural fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The pleural fluid contains a moderate number of inflammatory cells including polymorphs, lymphocytes and  macrophages. Some mesothelial cells are also present. There is no malignant cell or multinucleated giant cell seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL1BL', 'Pleural fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The pleural fluid specimen is heavily blood stained. It contains a moderate number of inflammatory cells including polymorphs, lymphocytes and some macrophages. Reactive mesothelial cells are also present. There is no malignant cell seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL1TB', 'Pleural fluid', 'Negative for malignancy. See description.', '無發現惡性細胞. 參看上文.', 'No malignancy', 'The pleural fluid contains abundant inflammatory cells including mostly lymphocytes and some macrophages. An abundance of lymphocytes is common in tuberculosis. Please investigate further if indicated. Malignant cells are not seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL2', 'Pleural fluid', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The pleural fluid contains large number of inflammatory cells, mesothelial cells and a small number of large cells with slightly irregular nuclei. The features are atypical but not diagnostic of malignancy. Please proceed to further investigations if indicated.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL3', 'Pleural fluid', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The pleural fluid contains a moderate number of cells including mesothelial cells, inflammatory cells and clusters of cells with enlarged irregular or eccentric nuclei, slightly coarse chromatin, nucleoli and vacuolated cytoplasm. The features are suspicious of adenocarcinoma. ', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL4AD', 'Pleural fluid', 'Metastatic adenocarcinoma.', '轉移腺癌', 'Carcinomatosis / Metastatic Ca', 'The pleural fluid is blood stained and contains a large number of cells including mesothelial cells,  inflammatory cells and many clusters of large cells with enlarged irregular or eccentric nuclei, coarse chromatin and occasional nucleoli. The features are those of adenocarcinoma. ', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL4NS', 'Pleural fluid', 'Metastatic non small cell carcinoma.', '轉移非小細胞癌', 'Carcinomatosis / Metastatic Ca', 'The pleural fluid contains a moderate number of cells including mesothelial cells, inflammatory cells and many clusters of cells with enlarged irregular nuclei and prominent nucleoli. The features are those of non-small cell carcinoma cells.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PL4SQ', 'Pleural fluid', 'Metastatic squamous cell carcinoma.', '轉移鱗狀細胞癌', 'Carcinomatosis / Metastatic Ca', 'The pleural fluid contains a moderate number of cells including inflammatory cells and moderate number of large cells with enlarged irregular nuclei and prominent nucleoli. Some are spindle and show cytoplasmic keratinisation. The features are those of non-small malignant cells in favour of squamous cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PT1', 'Peritoneal fluid', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The peritoneal fluid contains some inflammatory cells and a moderate number of reactive mesothelial cells. There is no malignant cell seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PT2', 'Peritoneal fluid', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The peritoneal fluid contains moderate number of inflammatory cells and mesothelial cells. Some clusters of cells have large hyperchromatic nuclei. The features are atypical. Please investigate further if indicated.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PT3', 'Peritoneal fluid', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The peritoneal fluid contains many inflammatory cells and a small number of isolated large cells with large nuclei and nucleoli. The features are suspicious of carcinoma cells, but too scanty for definitive diagnosis. Please proceed to further investigations.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('PT4AD', 'Peritoneal fluid', 'Adenocarcinoma.', '腺癌', 'Carcinoma adeno', 'The peritoneal fluid contains a moderate number of cells including mesothelial cells, inflammatory cells and small clusters of cells with enlarged irregular or eccentric nuclei, coarse chromatin and occasional nucleoli. The features are those of adenocarcinoma. ', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP1', 'Sputum', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The sputum specimen contains moderate numbers of inflammatory cells including polymorphs and lymphocytes. No eosinophils are seen. Some macrophages, buccal squamous cells and bronchial epithelial cells are also present. There is no malignant cell or multinucleated giant cell found.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP1BL', 'Sputum', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The sputum specimen contains small numbers of red blood cells, inflammatory cells, macrophages, buccal squamous cells and scanty bronchial epithelial cells. No haemosiderin laden macrophages are found. There is no malignant cell present.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP2', 'Sputum', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The sputum specimen show the presence of inflammatory cells, bronchial cells and squamous cells. Scanty atypical bronchial cells with enlarged nuclei are present. Please investigate further if indicated.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP3', 'Sputum', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The sputum specimen shows the presence of inflammatory cells, some bronchial cells and squamous cells. Small number of atypical epithelial cells with enlarged nuclei and increased nuclear to cytoplasmic ratio are present. The features are suspicious of malignancy.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP3NS', 'Sputum', 'Suspicious of non small cell carcinoma.', '懷疑非小細胞癌', 'Suspicious of malignant cells', 'The sputum specimen shows the presence of inflammatory cells, some bronchial cells and squamous cells. Many atypical epithelial cells with enlarged hyperchromatic nuclei and increased nuclear to cytoplasmic ratio are present. The features are suspicious of non-small cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP3SC', 'Sputum', 'Suspicious of small cell carcinoma.', '懷疑小細胞癌', 'Suspicious of malignant cells', 'The sputum specimen show the presence of inflammatory cells, some bronchial cells and epithelial cells. There are a few clusters of atypical small to intermediate size epithelial cells with enlarged nuclei and increased nuclear to cytoplasmic ratio. The features are suspicious of small cell carcinoma. Please investigate further. ', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP4AD', 'Sputum', 'Adenocarcinoma.', '腺癌', 'Carcinoma adeno', 'The sputum specimen shows the presence of inflammatory cells, some bronchial cells and clusters of abnormal cells with scanty cytoplasm, large vesicular nuclei and prominent nucleoli. There is no nuclear moulding. The features are those of adenocarcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP4NS', 'Sputum', 'Non-small cell carcinoma.', '非小細胞癌', 'Carcinoma, NOS', 'The sputum specimen contains small number of large malignant cells. Most of these show poor differentiation. Some of these cells have abundant eosinophilic cytoplasm, increased nuclear to cytoplasmic ratio, hyperchromatic enlarged nuclei and occasional nucleoli. The features are those of non-small cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP4SC', 'Sputum', 'Small cell carcinoma.', '小細胞癌', 'Carcinoma small cell', 'The sputum specimen contains inflammatory cells including some macrophages. In addition, there are a few clusters of small and medium-sized dysplastic cells with dark hyperchromatic nuclei and nuclear moulding. The features are in keeping with small cell carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('SP4SQ', 'Sputum', 'Squamous cell carcinoma.', '鱗狀細胞癌', 'Carcinoma Squamous cell', 'The sputum specimen contains inflammatory cells and small number of malignant cells. Some of these cells have abundant eosinophilic cytoplasm and some cells are spindle in shape. The features are those of squamous carcinoma.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('UR0', 'Urine', 'Negative for malignancy.', '無發現惡性細胞', 'Inadequate specimen', 'The urine specimen is almost completely acellular. Only a few epithelial cells are present. Malignant cells are not found. There are scanty inflammatory cells.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('UR1', 'Urine', 'Negative for malignancy.', '無發現惡性細胞', 'No malignancy', 'The urine specimen contains moderate numbers of red blood cells and some inflammatory cells. Moderate numbers of epithelial cells are also included. There is no malignant cell seen.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('UR2', 'Urine', 'Atypical cells present.', '非典型細胞存在', 'Atypia', 'The urine contains scanty atypical epithelial cells with enlarged hyperchromatic nuclei. The cells are degenerated epithelial cells with moderate amount of cytoplasm.  Dysplasia or malignancy cannot be excluded. Please investigate further if indicated.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('UR3', 'Urine', 'Suspicious of malignancy.', '懷疑惡性', 'Suspicious of malignant cells', 'The urine contains small number of cells including some atypical epithelial cells with enlarged hyerchromatic nuclei. The features are suspicious of malignancy. Please investigate further.', null, null, 0, null);
INSERT INTO cy_result_temp
  (CODE, OPERATION, DIAGNOSIS, DIAG_DESC1, SNOP_M, MICRO_DESC, UPDATE_BY, UPDATE_AT, UPDATE_CTR, UPDATED)
VALUES
  ('UR4', 'Urine', 'Carcinoma.', '癌', 'Carcinoma, NOS', 'The urine specimen contains many papillary clusters of pleomorphic cells with enlarged nuclei, coarse chromatin and nucleoli. The overall features are those of carcinoma cells, in keeping with transitional carcinoma cells.', null, null, 0, null);

merge cy_result r using cy_result_temp t
on (r.code = t.code)
when matched
	then update set
		r.diagnosis = t.diagnosis,
		r.diag_desc1 = t.diag_desc1,
		r.micro_desc = t.micro_desc
;

-- Eric Leung 2019-Dec-10

drop function fn_reportName

create function fn_reportName(
	@groupNo varchar(1)
)
returns nvarchar(50)
AS
Begin
	IF (@groupNo is null or @groupNo = '')
		BEGIN
		return null
		END
	ELSE
		BEGIN
			IF @groupNo = '1'
				BEGIN
					return null
				END
			ELSE
				BEGIN
					IF @groupNo = '2'
						BEGIN
							return 'Second report'
						END
					ELSE
						BEGIN
							IF @groupNo = '3'
								BEGIN
									return 'Third report'
								END
							ELSE
								BEGIN
									IF @groupNo = '4'
										BEGIN
											return 'Fourth report'
										END
									ELSE
										BEGIN
											IF @groupNo = '5'
												BEGIN
													return 'Fifth report'
												END
											ELSE
												BEGIN
													IF @groupNo = '6'
														BEGIN
															return 'Sixth report'
														END
													ELSE
														BEGIN
															IF @groupNo = '7'
																BEGIN
																	return 'Seventh report'
																END
															ELSE
																BEGIN
																	IF @groupNo = '8'
																		BEGIN
																			return 'Eighth report'
																		END
																	ELSE
																		BEGIN
																			IF @groupNo = '9'
																				BEGIN
																					return 'Ninth report'
																				END
																			ELSE
																				BEGIN
																					return @groupNo + 'th report'
																				END
																		END
																END
														END
												END
										END
								END
						END
				END
		END
	return null
END;
GO
alter table bxcy_specimen alter column fz_detail nvarchar(2000)

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_reportName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_reportName]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_reportName]    Script Date: 12/12/2019 16:54:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create function [dbo].[fn_reportName](
	@groupNo varchar(1)
)
returns nvarchar(50)
AS
Begin
	IF (@groupNo is null or @groupNo = '')
		BEGIN
		return null
		END
	ELSE
		BEGIN
			IF @groupNo = '1'
				BEGIN
					return null
				END
			ELSE
				BEGIN
					IF @groupNo = '2'
						BEGIN
							return '2nd report'
						END
					ELSE
						BEGIN
							IF @groupNo = '3'
								BEGIN
									return '3rd report'
								END
							ELSE
								BEGIN
									IF @groupNo = '4'
										BEGIN
											return '4th report'
										END
									ELSE
										BEGIN
											IF @groupNo = '5'
												BEGIN
													return '5th report'
												END
											ELSE
												BEGIN
													IF @groupNo = '6'
														BEGIN
															return '6th report'
														END
													ELSE
														BEGIN
															IF @groupNo = '7'
																BEGIN
																	return '7th report'
																END
															ELSE
																BEGIN
																	IF @groupNo = '8'
																		BEGIN
																			return '8th report'
																		END
																	ELSE
																		BEGIN
																			IF @groupNo = '9'
																				BEGIN
																					return '9th report'
																				END
																			ELSE
																				BEGIN
																					return @groupNo + 'th report'
																				END
																		END
																END
														END
												END
										END
								END
						END
				END
		END
	return null
END;


IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'diagnosisId' AND LTRIM(b.name)='BXCY_DIAG')
BEGIN
ALTER TABLE BXCY_DIAG ADD [diagnosisId] [int] NULL;
END


update BXCY_DIAG 
set diagnosisId = s.rank
from BXCY_DIAG d inner join 
(
 select id 
 , RANK() over (PARTITION BY case_no, [group] ORDER BY id) AS Rank 
 from bxcy_diag
) s
on (d.id = s.id)


ALTER TABLE BXCY_DIAG ALTER column micro_desc NVARCHAR(MAX) NULL;
ALTER TABLE BXCY_DIAG ALTER column macro_desc NVARCHAR(MAX) NULL;

-- 2019-12-21
alter table bxcy_diag add report_status nvarchar(100)

--2019-12-24
alter table snopcode alter column snoptype nvarchar(5);

--2019-12-27 Eric leung
create table sth_pay_code (
	code_id int identity(1, 1) primary key,
	code nvarchar(10) not null unique,
	eng_desc nvarchar(1000) ,
	active bit default 1,
	create_at datetime2 default SYSDATETIME(),
	create_by nvarchar(100),
	update_at datetime2,
	update_by nvarchar(100)
	
)

create table sth_charge_classes
(
	class_id int identity(1, 1) primary key,
	class_code nvarchar(10) not null unique,
	class_name nvarchar(1000),
	active bit default 1,
	create_at datetime2 default SYSDATETIME(),
	create_by nvarchar(100),
	update_at datetime2,
	update_by nvarchar(100)
)


create table sth_charging_table
(
	charging_id int identity(1, 1) primary key,
	class_id int foreign key references sth_charge_classes(class_id),
	code_id int foreign key references sth_pay_code(code_id),
	charge float not null,
	create_at datetime2 default SYSDATETIME(),
	create_by nvarchar(100),
	update_at datetime2,
	update_by nvarchar(100)
)


--sth_pay_code table
insert into sth_pay_code (code, eng_desc, create_by) values ('H064', ' Routine Examination  (GI Endoscopy DC Case only, 1-3 specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H065 ', ' Routine Examination  (GI Endoscopy DC Case only, 1-4 specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H066 ', ' Routine Examination  (GI Endoscopy DC Case only, 1-5 specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H067 ', ' Routine Examination  (GI Endoscopy DC Case only, 1-6 specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H068', ' Routine Examination  (GI Endoscopy DC Case only, 1-7 specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H063 ', ' Routine Examination  (Small, incisional/endoscopic 1-3 specimens)**', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H041 ', ' Routine Examination  (Small, incisional/endoscopic 1-4 specimens)**', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H042', ' Routine Examination  (Small, incisional/endoscopic 1-5 specimens)**', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H043 ', ' Routine Examination  (Small, incisional/endoscopic 1-6 specimens)**', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H062 ', ' Routine Examination  (Small, incisional/endoscopic 1-7 or more specimens)**', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H044 ', ' Routine Examination  (Core Biopsy)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H023 ', ' Routine Examination  (Small, excisional)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H011', ' Routine Examination  (Small, excisional)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H060', ' Routine Examination  (Small, excisional, 2 specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H061', ' Routine Examination  (Small, excisional, 3 or more specimens)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H010', ' Routine Examination  (Large specimen, standard operations)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H045', ' Routine Examination  (Large, including 1-4 additional small biopsies)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H046 ', ' Routine Examination  (Large, including 5-9 additional small biopsies)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H047', ' Routine Examination  (Large, including 10 or more additional small biopsies)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H048 ', ' Routine Examination  (Prostatic biopsies > 12 sites)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H006', ' Frozen Section Professional Charge (1 F/S), before 6pm', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H049', ' Frozen Section Professional Charge (2 F/S), before 6pm', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H050', ' Frozen Section Professional Charge (3 F/S), before 6pm', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H051', ' Frozen Section Professional Charge (4 F/S), before 6pm', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H025 ', ' Frozen Section Surcharge, 6-9pm', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H026', ' Frozen Section Surcharge, after 9pm*', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H052', ' Special Breast F/S Package + 3 SLNs', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H053 ', ' Special Breast F/S Package + 4 SLNs', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H054', ' Special Breast F/S Package + 5 SLNs', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H055', ' Special Breast F/S Package + 6 SLNs or more SLNs', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H056', ' Special SLN F/S Package (SLNs x 3)° ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H057', ' Special SLN F/S Package (SLNs x 4)° ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H058', ' Special SLN F/S Package (SLNs x 5)° ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H059', ' Special SLN F/S Package (SLNs x 6 or more SLNs)° ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H007', ' Breast Cancer Markers: ER, PR, Ki-67 & Oncogene', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H005', ' Blood for EBV', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H001', ' Bone Marrow', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H027', ' Bone Marrow & Trephine Biopsy  ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H008', ' Immunofluorescence (Renal / Skin)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H009 ', ' Electron Microscopy (EM) ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H020', ' Foetal Examination', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H022', ' FNA Urgent Reporting', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H012', ' FNA Cytology ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H004', ' FNA By Pathologist', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H014', ' Thinprep PAP Test (Cytology)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H017', ' PreservCyt Solution for HPV', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H018', ' PreservCyt Solution for Cytology & HPV', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H003', ' Non-gynae Cytology (body fluid, etc)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H028', ' CISH/SISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H029', ' Immunohistochemical staining', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H097 ', ' PCR - TB (QEH)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H137', ' PD-L1 IHC (22C3) In-house Test', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H138', ' 40 or Over 40 Unstained Slides Preparation Fee', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H139', ' Hamematolymphoid immunoprofile', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H140', ' HPV Surcharge (QMH) ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H145 ', ' Muscle Biopsy (QMH) Revised frm 1/10/18', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H086', 'Brain Cancer Panel (MGMT Methylation PCR and 1p/19q FISH)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H085', '1p/19q Deletion by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H099', 'IDH1 & IDH2 Hotspot Mutation Detection', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H083', 'MGMT Promoter Methylation PCR', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H076', 'Colorectal Cancer Panel I (KRAS, BRAF, MSI)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H092', 'Colorectal Cancer Panel II (KRAS, NRAS, BRAF, MSI)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H080', 'KRAS and NRAS Gene Hotspot Mutation Detection (Exons 2, 3 and 4)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H070', 'BRAF Gene V600 Mutation Detection', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H073', 'Microsatellite Instability Test', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H122', 'Microsatellite Instability and MMR IHC', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H069', 'ALK Gene Rearrangement Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H104', 'ALK Immunohistochemistry / ALK-IHC (In-house)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H141', 'Cancer Hotspot Mutations Lung NGS Panel (30 plus genes incl ALK,ROS1, RET)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H109', 'EGFR Gene Amplificatioin Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H071', 'EGFR Gene Hotspot Mutation Detection (Exons 18, 19, 20 and 21), FFPE', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H110', 'EGFR Gene Hotspot Mutation Detection (Exons 18, 19, 20 and 21), BLOOD', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H074', 'EGFR and KRAS Gene Hotspot Mutations', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H075', 'Lung Cancer Panel I (EGFR, KRAS and ALK FISH)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H089', 'Lung Cancer Panel II (ROS1 FISH, RET, HER2 Mutation)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H116', 'Lung Cancer Panel III (EGFR, KRAS, ALK IHC)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H142', 'Lung Cancer Panel IV (EGFR, ALK & ROS1 FISH)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H143', 'Lung Cancer Panel VI (BRAF V600,HER2 Exon 20 & MET Exon 14 Skipping Mutation)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H144', 'Lung Cancer Panel  V (EGFR+ ALK-IHC + ROS1 FISH)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H093', 'MET (C-MET) Amplification Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H079', 'ROS1 Gene Rearrangement Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H112', 'FoundationOne Heme  out of HK', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H113', 'FoundationOne Solid  out of HK', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H135', 'FoundationOne ACT (Blood)  out of HK', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H091', 'ERBB2 (HER2) Exon 20 Mutation ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H100', 'ERBB2 (HER2) Gene Amplification Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H081', 'KIT and PDGFRA Hotspot Mutations', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H077', 'KIT Gene Hotspot Mutation Detection (Exons 9, 11, 13, 14 and 17)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H115', 'HRAS Gene Hotspot Mutation Detection (Exons 2, 3 and 4)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H072', 'KRAS Gene Hotspot Mutation Detection (Exons 2, 3 and 4)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H088', 'NRAS Gene Hotspot Mutation Detection (Exons 2, 3 and 4)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H118', 'MMR Gene Deletion/ Duplication by MLPA', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H119', 'MMR Genes Promoter Methylation Detection by MLPA', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H117', 'MLH1 Gene Comprehensive Screening for Hereditary Non-polyposis Colorectal Cancer', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H120', 'MSH2 Gene Comprehensive Screening for Hereditary Non-polyposis Colorectal Cancer', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H121', 'MSH6 Gene Comprehensive Screening for Hereditary Non-polyposis Colorectal Cancer', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H098', 'RET Gene Hotspot Mutation Detection (Exons 5,8,10,11, 13-16)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H090', 'RET Gene Rearrangement Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H095', 'AKT1 E17K Hotspot Mutation ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H105', 'APC Gene Comprehensive Screening for Familial Adenomatous Polyposis', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H106', 'BRCA1 and BRCA2 Genes Comprehensive Screening for Breast and Ovarian Cancer', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H107', 'CDH1 Gene Sequencing Analysis for Gastric Cancer', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H108', 'Comprehensive Hereditary Cancers Screening', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H111', 'EPCAM Gene Deletion by MLPA', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H114', 'Hereditary Cancer Syndromes (79 Genes Panel)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H123', 'MUTYH Gene Sequencing Analysis for MUTYH Associated Polyposis', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H124', 'N-MYC Gene Amplication by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H125', 'PDGFRA Gene Hotspot Mutation Detection (Exons 12 and 18)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H094', 'PIK3CA Gene Hotspot Mutation Dectection (Exons 9 and 20)    ', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H126', 'PMS2 Gene Comprehensive Screening for Hereditary Non-polypois Colorectal Cancer', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H127', 'PTEN Gene Comprehensive Screening for PTEN Related Disorders', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H128', 'Specific Gene Known Mutation Screening (Point Mutation, Small Deletion and Insertion)', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H129', 'STK11 Gene Mutation Screening', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H130', 'TERT Promoter Mutation', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H131', 'TOP2A Gene Amplification Detection by FISH', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H132', 'TP53 Gene Comprehensive Screening for Li-Fraumeni Syndrome', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H133', 'UGT1A1 Genotyping for Irinotecan Toxicity', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H134', 'VHL Gene Comprehensive Screening for Von Hippel-Lindau Syndrome', 'sys');
insert into sth_pay_code (code, eng_desc, create_by) values ('H136', 'PD-L1 Immunohistochemistry (UPS, CHUHK) INACTIVE', 'sys');

update sth_pay_code set update_at = getdate(), update_by = getdate();

--sth_charge_classes talbe
insert into sth_charge_classes (class_code, class_name, create_by) values ('OPD/SW', 'OPD/SW',  'sys');
insert into sth_charge_classes (class_code, class_name, create_by) values ('H', 'H',  'sys');
insert into sth_charge_classes (class_code, class_name, create_by) values ('SP', 'SP',  'sys');
insert into sth_charge_classes (class_code, class_name, create_by) values ('PR', 'PR',  'sys');
insert into sth_charge_classes (class_code, class_name, create_by) values ('PP', 'PP',  'sys');

update sth_charge_classes set update_at = getdate(), update_by = getdate();

--sth_charging_table table
insert into sth_charging_table (class_id, code_id, charge) values (1, 37, 1420);	insert into sth_charging_table (class_id, code_id, charge) values (2, 37, 995);	insert into sth_charging_table (class_id, code_id, charge) values (3, 37, 1990);	insert into sth_charging_table (class_id, code_id, charge) values (4, 37, 2200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 37, 2420);
insert into sth_charging_table (class_id, code_id, charge) values (1, 48, 310);	insert into sth_charging_table (class_id, code_id, charge) values (2, 48, 220);	insert into sth_charging_table (class_id, code_id, charge) values (3, 48, 440);	insert into sth_charging_table (class_id, code_id, charge) values (4, 48, 480);	insert into sth_charging_table (class_id, code_id, charge) values (5, 48, 530);
insert into sth_charging_table (class_id, code_id, charge) values (1, 44, 1420);	insert into sth_charging_table (class_id, code_id, charge) values (2, 44, 995);	insert into sth_charging_table (class_id, code_id, charge) values (3, 44, 1990);	insert into sth_charging_table (class_id, code_id, charge) values (4, 44, 2200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 44, 2420);
insert into sth_charging_table (class_id, code_id, charge) values (1, 36, 440);	insert into sth_charging_table (class_id, code_id, charge) values (2, 36, 310);	insert into sth_charging_table (class_id, code_id, charge) values (3, 36, 620);	insert into sth_charging_table (class_id, code_id, charge) values (4, 36, 690);	insert into sth_charging_table (class_id, code_id, charge) values (5, 36, 750);
insert into sth_charging_table (class_id, code_id, charge) values (1, 21, 1000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 21, 700);	insert into sth_charging_table (class_id, code_id, charge) values (3, 21, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (4, 21, 1550);	insert into sth_charging_table (class_id, code_id, charge) values (5, 21, 1700);
insert into sth_charging_table (class_id, code_id, charge) values (1, 35, 2230);	insert into sth_charging_table (class_id, code_id, charge) values (2, 35, 1565);	insert into sth_charging_table (class_id, code_id, charge) values (3, 35, 3130);	insert into sth_charging_table (class_id, code_id, charge) values (4, 35, 3460);	insert into sth_charging_table (class_id, code_id, charge) values (5, 35, 3790);
insert into sth_charging_table (class_id, code_id, charge) values (1, 39, 4260);	insert into sth_charging_table (class_id, code_id, charge) values (2, 39, 2980);	insert into sth_charging_table (class_id, code_id, charge) values (3, 39, 5960);	insert into sth_charging_table (class_id, code_id, charge) values (4, 39, 6600);	insert into sth_charging_table (class_id, code_id, charge) values (5, 39, 7240);
insert into sth_charging_table (class_id, code_id, charge) values (1, 40, 4720);	insert into sth_charging_table (class_id, code_id, charge) values (2, 40, 4419);	insert into sth_charging_table (class_id, code_id, charge) values (3, 40, 6610);	insert into sth_charging_table (class_id, code_id, charge) values (4, 40, 7320);	insert into sth_charging_table (class_id, code_id, charge) values (5, 40, 8020);
insert into sth_charging_table (class_id, code_id, charge) values (1, 16, 3200);	insert into sth_charging_table (class_id, code_id, charge) values (2, 16, 2240);	insert into sth_charging_table (class_id, code_id, charge) values (3, 16, 4480);	insert into sth_charging_table (class_id, code_id, charge) values (4, 16, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 16, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 13, 1600);	insert into sth_charging_table (class_id, code_id, charge) values (2, 13, 1120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 13, 2240);	insert into sth_charging_table (class_id, code_id, charge) values (4, 13, 2480);	insert into sth_charging_table (class_id, code_id, charge) values (5, 13, 2720);
insert into sth_charging_table (class_id, code_id, charge) values (1, 43, 440);	insert into sth_charging_table (class_id, code_id, charge) values (2, 43, 310);	insert into sth_charging_table (class_id, code_id, charge) values (3, 43, 620);	insert into sth_charging_table (class_id, code_id, charge) values (4, 43, 690);	insert into sth_charging_table (class_id, code_id, charge) values (5, 43, 750);
insert into sth_charging_table (class_id, code_id, charge) values (1, 45, 360);	insert into sth_charging_table (class_id, code_id, charge) values (2, 45, 255);	insert into sth_charging_table (class_id, code_id, charge) values (3, 45, 510);	insert into sth_charging_table (class_id, code_id, charge) values (4, 45, 560);	insert into sth_charging_table (class_id, code_id, charge) values (5, 45, 620);
insert into sth_charging_table (class_id, code_id, charge) values (1, 46, 440);	insert into sth_charging_table (class_id, code_id, charge) values (2, 46, 310);	insert into sth_charging_table (class_id, code_id, charge) values (3, 46, 620);	insert into sth_charging_table (class_id, code_id, charge) values (4, 46, 690);	insert into sth_charging_table (class_id, code_id, charge) values (5, 46, 750);
insert into sth_charging_table (class_id, code_id, charge) values (1, 47, 760);	insert into sth_charging_table (class_id, code_id, charge) values (2, 47, 535);	insert into sth_charging_table (class_id, code_id, charge) values (3, 47, 1070);	insert into sth_charging_table (class_id, code_id, charge) values (4, 47, 1190);	insert into sth_charging_table (class_id, code_id, charge) values (5, 47, 1300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 41, 8480);	insert into sth_charging_table (class_id, code_id, charge) values (2, 41, 5940);	insert into sth_charging_table (class_id, code_id, charge) values (3, 41, 11880);	insert into sth_charging_table (class_id, code_id, charge) values (4, 41, 13150);	insert into sth_charging_table (class_id, code_id, charge) values (5, 41, 14420);
insert into sth_charging_table (class_id, code_id, charge) values (1, 42, 2340);	insert into sth_charging_table (class_id, code_id, charge) values (2, 42, 1640);	insert into sth_charging_table (class_id, code_id, charge) values (3, 42, 3280);	insert into sth_charging_table (class_id, code_id, charge) values (4, 42, 3630);	insert into sth_charging_table (class_id, code_id, charge) values (5, 42, 3980);
insert into sth_charging_table (class_id, code_id, charge) values (1, 12, 1600);	insert into sth_charging_table (class_id, code_id, charge) values (2, 12, 1120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 12, 2240);	insert into sth_charging_table (class_id, code_id, charge) values (4, 12, 2480);	insert into sth_charging_table (class_id, code_id, charge) values (5, 12, 2720);
insert into sth_charging_table (class_id, code_id, charge) values (1, 25, 500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 25, 350);	insert into sth_charging_table (class_id, code_id, charge) values (3, 25, 700);	insert into sth_charging_table (class_id, code_id, charge) values (4, 25, 780);	insert into sth_charging_table (class_id, code_id, charge) values (5, 25, 850);
insert into sth_charging_table (class_id, code_id, charge) values (1, 26, 1000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 26, 700);	insert into sth_charging_table (class_id, code_id, charge) values (3, 26, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (4, 26, 1550);	insert into sth_charging_table (class_id, code_id, charge) values (5, 26, 1700);
insert into sth_charging_table (class_id, code_id, charge) values (1, 38, 2840);	insert into sth_charging_table (class_id, code_id, charge) values (2, 38, 1990);	insert into sth_charging_table (class_id, code_id, charge) values (3, 38, 3980);	insert into sth_charging_table (class_id, code_id, charge) values (4, 38, 4400);	insert into sth_charging_table (class_id, code_id, charge) values (5, 38, 4840);
insert into sth_charging_table (class_id, code_id, charge) values (1, 49, 2840);	insert into sth_charging_table (class_id, code_id, charge) values (2, 49, 1990);	insert into sth_charging_table (class_id, code_id, charge) values (3, 49, 3980);	insert into sth_charging_table (class_id, code_id, charge) values (4, 49, 4400);	insert into sth_charging_table (class_id, code_id, charge) values (5, 49, 4840);
insert into sth_charging_table (class_id, code_id, charge) values (1, 50, 1420);	insert into sth_charging_table (class_id, code_id, charge) values (2, 50, 995);	insert into sth_charging_table (class_id, code_id, charge) values (3, 50, 1990);	insert into sth_charging_table (class_id, code_id, charge) values (4, 50, 2200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 50, 2420);
insert into sth_charging_table (class_id, code_id, charge) values (1, 7, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (2, 7, 1470);	insert into sth_charging_table (class_id, code_id, charge) values (3, 7, 2940);	insert into sth_charging_table (class_id, code_id, charge) values (4, 7, 3260);	insert into sth_charging_table (class_id, code_id, charge) values (5, 7, 3570);
insert into sth_charging_table (class_id, code_id, charge) values (1, 8, 2600);	insert into sth_charging_table (class_id, code_id, charge) values (2, 8, 1820);	insert into sth_charging_table (class_id, code_id, charge) values (3, 8, 3640);	insert into sth_charging_table (class_id, code_id, charge) values (4, 8, 4030);	insert into sth_charging_table (class_id, code_id, charge) values (5, 8, 4420);
insert into sth_charging_table (class_id, code_id, charge) values (1, 9, 3100);	insert into sth_charging_table (class_id, code_id, charge) values (2, 9, 2170);	insert into sth_charging_table (class_id, code_id, charge) values (3, 9, 4340);	insert into sth_charging_table (class_id, code_id, charge) values (4, 9, 4810);	insert into sth_charging_table (class_id, code_id, charge) values (5, 9, 5270);
insert into sth_charging_table (class_id, code_id, charge) values (1, 11, 2400);	insert into sth_charging_table (class_id, code_id, charge) values (2, 11, 1680);	insert into sth_charging_table (class_id, code_id, charge) values (3, 11, 3360);	insert into sth_charging_table (class_id, code_id, charge) values (4, 11, 3720);	insert into sth_charging_table (class_id, code_id, charge) values (5, 11, 4080);
insert into sth_charging_table (class_id, code_id, charge) values (1, 17, 4200);	insert into sth_charging_table (class_id, code_id, charge) values (2, 17, 2940);	insert into sth_charging_table (class_id, code_id, charge) values (3, 17, 5880);	insert into sth_charging_table (class_id, code_id, charge) values (4, 17, 6510);	insert into sth_charging_table (class_id, code_id, charge) values (5, 17, 7140);
insert into sth_charging_table (class_id, code_id, charge) values (1, 18, 5200);	insert into sth_charging_table (class_id, code_id, charge) values (2, 18, 3640);	insert into sth_charging_table (class_id, code_id, charge) values (3, 18, 7280);	insert into sth_charging_table (class_id, code_id, charge) values (4, 18, 8060);	insert into sth_charging_table (class_id, code_id, charge) values (5, 18, 8840);
insert into sth_charging_table (class_id, code_id, charge) values (1, 19, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (2, 19, 4340);	insert into sth_charging_table (class_id, code_id, charge) values (3, 19, 8680);	insert into sth_charging_table (class_id, code_id, charge) values (4, 19, 9610);	insert into sth_charging_table (class_id, code_id, charge) values (5, 19, 10540);
insert into sth_charging_table (class_id, code_id, charge) values (1, 20, 4500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 20, 3150);	insert into sth_charging_table (class_id, code_id, charge) values (3, 20, 6300);	insert into sth_charging_table (class_id, code_id, charge) values (4, 20, 6980);	insert into sth_charging_table (class_id, code_id, charge) values (5, 20, 7650);
insert into sth_charging_table (class_id, code_id, charge) values (1, 22, 1500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 22, 1050);	insert into sth_charging_table (class_id, code_id, charge) values (3, 22, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (4, 22, 2330);	insert into sth_charging_table (class_id, code_id, charge) values (5, 22, 2550);
insert into sth_charging_table (class_id, code_id, charge) values (1, 23, 2000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 23, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (3, 23, 2800);	insert into sth_charging_table (class_id, code_id, charge) values (4, 23, 3100);	insert into sth_charging_table (class_id, code_id, charge) values (5, 23, 3400);
insert into sth_charging_table (class_id, code_id, charge) values (1, 24, 2500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 24, 1750);	insert into sth_charging_table (class_id, code_id, charge) values (3, 24, 3500);	insert into sth_charging_table (class_id, code_id, charge) values (4, 24, 3880);	insert into sth_charging_table (class_id, code_id, charge) values (5, 24, 4250);
insert into sth_charging_table (class_id, code_id, charge) values (1, 27, 9950);	insert into sth_charging_table (class_id, code_id, charge) values (2, 27, 6965);	insert into sth_charging_table (class_id, code_id, charge) values (3, 27, 13930);	insert into sth_charging_table (class_id, code_id, charge) values (4, 27, 15420);	insert into sth_charging_table (class_id, code_id, charge) values (5, 27, 16920);
insert into sth_charging_table (class_id, code_id, charge) values (1, 28, 10750);	insert into sth_charging_table (class_id, code_id, charge) values (2, 28, 7525);	insert into sth_charging_table (class_id, code_id, charge) values (3, 28, 15050);	insert into sth_charging_table (class_id, code_id, charge) values (4, 28, 16660);	insert into sth_charging_table (class_id, code_id, charge) values (5, 28, 18280);
insert into sth_charging_table (class_id, code_id, charge) values (1, 29, 11550);	insert into sth_charging_table (class_id, code_id, charge) values (2, 29, 8085);	insert into sth_charging_table (class_id, code_id, charge) values (3, 29, 16170);	insert into sth_charging_table (class_id, code_id, charge) values (4, 29, 17900);	insert into sth_charging_table (class_id, code_id, charge) values (5, 29, 19640);
insert into sth_charging_table (class_id, code_id, charge) values (1, 30, 12350);	insert into sth_charging_table (class_id, code_id, charge) values (2, 30, 8645);	insert into sth_charging_table (class_id, code_id, charge) values (3, 30, 17290);	insert into sth_charging_table (class_id, code_id, charge) values (4, 30, 19140);	insert into sth_charging_table (class_id, code_id, charge) values (5, 30, 21000);
insert into sth_charging_table (class_id, code_id, charge) values (1, 31, 1000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 31, 700);	insert into sth_charging_table (class_id, code_id, charge) values (3, 31, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (4, 31, 1550);	insert into sth_charging_table (class_id, code_id, charge) values (5, 31, 1700);
insert into sth_charging_table (class_id, code_id, charge) values (1, 32, 1500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 32, 1050);	insert into sth_charging_table (class_id, code_id, charge) values (3, 32, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (4, 32, 2330);	insert into sth_charging_table (class_id, code_id, charge) values (5, 32, 2550);
insert into sth_charging_table (class_id, code_id, charge) values (1, 33, 2000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 33, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (3, 33, 2800);	insert into sth_charging_table (class_id, code_id, charge) values (4, 33, 3100);	insert into sth_charging_table (class_id, code_id, charge) values (5, 33, 3400);
insert into sth_charging_table (class_id, code_id, charge) values (1, 34, 2500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 34, 1750);	insert into sth_charging_table (class_id, code_id, charge) values (3, 34, 3500);	insert into sth_charging_table (class_id, code_id, charge) values (4, 34, 3880);	insert into sth_charging_table (class_id, code_id, charge) values (5, 34, 4250);
insert into sth_charging_table (class_id, code_id, charge) values (1, 14, 2400);	insert into sth_charging_table (class_id, code_id, charge) values (2, 14, 1680);	insert into sth_charging_table (class_id, code_id, charge) values (3, 14, 3360);	insert into sth_charging_table (class_id, code_id, charge) values (4, 14, 3720);	insert into sth_charging_table (class_id, code_id, charge) values (5, 14, 4080);
insert into sth_charging_table (class_id, code_id, charge) values (1, 15, 3200);	insert into sth_charging_table (class_id, code_id, charge) values (2, 15, 2240);	insert into sth_charging_table (class_id, code_id, charge) values (3, 15, 4480);	insert into sth_charging_table (class_id, code_id, charge) values (4, 15, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 15, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 10, 3600);	insert into sth_charging_table (class_id, code_id, charge) values (2, 10, 2520);	insert into sth_charging_table (class_id, code_id, charge) values (3, 10, 5040);	insert into sth_charging_table (class_id, code_id, charge) values (4, 10, 5580);	insert into sth_charging_table (class_id, code_id, charge) values (5, 10, 6120);
insert into sth_charging_table (class_id, code_id, charge) values (1, 6, 1600);	insert into sth_charging_table (class_id, code_id, charge) values (2, 6, 1120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 6, 2240);	insert into sth_charging_table (class_id, code_id, charge) values (4, 6, 2480);	insert into sth_charging_table (class_id, code_id, charge) values (5, 6, 2720);
insert into sth_charging_table (class_id, code_id, charge) values (1, 1, 1500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 1, 1050);	insert into sth_charging_table (class_id, code_id, charge) values (3, 1, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (4, 1, 2330);	insert into sth_charging_table (class_id, code_id, charge) values (5, 1, 2550);
insert into sth_charging_table (class_id, code_id, charge) values (1, 2, 2000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 2, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (3, 2, 2800);	insert into sth_charging_table (class_id, code_id, charge) values (4, 2, 3100);	insert into sth_charging_table (class_id, code_id, charge) values (5, 2, 3400);
insert into sth_charging_table (class_id, code_id, charge) values (1, 3, 2500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 3, 1750);	insert into sth_charging_table (class_id, code_id, charge) values (3, 3, 3500);	insert into sth_charging_table (class_id, code_id, charge) values (4, 3, 3880);	insert into sth_charging_table (class_id, code_id, charge) values (5, 3, 4250);
insert into sth_charging_table (class_id, code_id, charge) values (1, 4, 3000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 4, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (3, 4, 4200);	insert into sth_charging_table (class_id, code_id, charge) values (4, 4, 4650);	insert into sth_charging_table (class_id, code_id, charge) values (5, 4, 5100);
insert into sth_charging_table (class_id, code_id, charge) values (1, 5, 3500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 5, 2450);	insert into sth_charging_table (class_id, code_id, charge) values (3, 5, 4900);	insert into sth_charging_table (class_id, code_id, charge) values (4, 5, 5430);	insert into sth_charging_table (class_id, code_id, charge) values (5, 5, 5950);
insert into sth_charging_table (class_id, code_id, charge) values (1, 67, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 67, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 67, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 67, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 67, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 64, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (2, 64, 2801.6);	insert into sth_charging_table (class_id, code_id, charge) values (3, 64, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (4, 64, 4220);	insert into sth_charging_table (class_id, code_id, charge) values (5, 64, 4630);
insert into sth_charging_table (class_id, code_id, charge) values (1, 71, 3660);	insert into sth_charging_table (class_id, code_id, charge) values (2, 71, 3605);	insert into sth_charging_table (class_id, code_id, charge) values (3, 71, 3660);	insert into sth_charging_table (class_id, code_id, charge) values (4, 71, 5430);	insert into sth_charging_table (class_id, code_id, charge) values (5, 71, 5950);
insert into sth_charging_table (class_id, code_id, charge) values (1, 90, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (2, 90, 3296);	insert into sth_charging_table (class_id, code_id, charge) values (3, 90, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (4, 90, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 90, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 65, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (2, 65, 3296);	insert into sth_charging_table (class_id, code_id, charge) values (3, 65, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (4, 65, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 65, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 73, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 73, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 73, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 73, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 73, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 74, 8160);	insert into sth_charging_table (class_id, code_id, charge) values (2, 74, 8034);	insert into sth_charging_table (class_id, code_id, charge) values (3, 74, 8160);	insert into sth_charging_table (class_id, code_id, charge) values (4, 74, 12090);	insert into sth_charging_table (class_id, code_id, charge) values (5, 74, 13260);
insert into sth_charging_table (class_id, code_id, charge) values (1, 61, 7840);	insert into sth_charging_table (class_id, code_id, charge) values (2, 61, 7725);	insert into sth_charging_table (class_id, code_id, charge) values (3, 61, 7840);	insert into sth_charging_table (class_id, code_id, charge) values (4, 61, 11630);	insert into sth_charging_table (class_id, code_id, charge) values (5, 61, 12750);
insert into sth_charging_table (class_id, code_id, charge) values (1, 88, 3660);	insert into sth_charging_table (class_id, code_id, charge) values (2, 88, 3605);	insert into sth_charging_table (class_id, code_id, charge) values (3, 88, 3660);	insert into sth_charging_table (class_id, code_id, charge) values (4, 88, 5430);	insert into sth_charging_table (class_id, code_id, charge) values (5, 88, 5950);
insert into sth_charging_table (class_id, code_id, charge) values (1, 81, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 81, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 81, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 81, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 81, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 63, 4600);	insert into sth_charging_table (class_id, code_id, charge) values (2, 63, 4532);	insert into sth_charging_table (class_id, code_id, charge) values (3, 63, 4600);	insert into sth_charging_table (class_id, code_id, charge) values (4, 63, 6820);	insert into sth_charging_table (class_id, code_id, charge) values (5, 63, 7480);
insert into sth_charging_table (class_id, code_id, charge) values (1, 87, 4500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 87, 4429);	insert into sth_charging_table (class_id, code_id, charge) values (3, 87, 4500);	insert into sth_charging_table (class_id, code_id, charge) values (4, 87, 6670);	insert into sth_charging_table (class_id, code_id, charge) values (5, 87, 7310);
insert into sth_charging_table (class_id, code_id, charge) values (1, 60, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (2, 60, 2060);	insert into sth_charging_table (class_id, code_id, charge) values (3, 60, 2100);	insert into sth_charging_table (class_id, code_id, charge) values (4, 60, 3240);	insert into sth_charging_table (class_id, code_id, charge) values (5, 60, 3560);
insert into sth_charging_table (class_id, code_id, charge) values (1, 58, 5230);	insert into sth_charging_table (class_id, code_id, charge) values (2, 58, 5150);	insert into sth_charging_table (class_id, code_id, charge) values (3, 58, 5230);	insert into sth_charging_table (class_id, code_id, charge) values (4, 58, 7750);	insert into sth_charging_table (class_id, code_id, charge) values (5, 58, 8500);
insert into sth_charging_table (class_id, code_id, charge) values (1, 57, 7220);	insert into sth_charging_table (class_id, code_id, charge) values (2, 57, 7107);	insert into sth_charging_table (class_id, code_id, charge) values (3, 57, 7220);	insert into sth_charging_table (class_id, code_id, charge) values (4, 57, 10700);	insert into sth_charging_table (class_id, code_id, charge) values (5, 57, 11730);
insert into sth_charging_table (class_id, code_id, charge) values (1, 91, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (2, 91, 3296);	insert into sth_charging_table (class_id, code_id, charge) values (3, 91, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (4, 91, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 91, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 75, 8160);	insert into sth_charging_table (class_id, code_id, charge) values (2, 75, 8034);	insert into sth_charging_table (class_id, code_id, charge) values (3, 75, 8160);	insert into sth_charging_table (class_id, code_id, charge) values (4, 75, 12090);	insert into sth_charging_table (class_id, code_id, charge) values (5, 75, 13260);
insert into sth_charging_table (class_id, code_id, charge) values (1, 98, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 98, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 98, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 98, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 98, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 85, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (2, 85, 2801.6);	insert into sth_charging_table (class_id, code_id, charge) values (3, 85, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (4, 85, 4220);	insert into sth_charging_table (class_id, code_id, charge) values (5, 85, 4630);
insert into sth_charging_table (class_id, code_id, charge) values (1, 62, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (2, 62, 9270);	insert into sth_charging_table (class_id, code_id, charge) values (3, 62, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (4, 62, 13950);	insert into sth_charging_table (class_id, code_id, charge) values (5, 62, 15300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 80, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 80, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 80, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 80, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 80, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 109, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (2, 109, 3296);	insert into sth_charging_table (class_id, code_id, charge) values (3, 109, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (4, 109, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 109, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 99, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (2, 99, 2801.6);	insert into sth_charging_table (class_id, code_id, charge) values (3, 99, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (4, 99, 4220);	insert into sth_charging_table (class_id, code_id, charge) values (5, 99, 4630);
insert into sth_charging_table (class_id, code_id, charge) values (1, 51, 1650);	insert into sth_charging_table (class_id, code_id, charge) values (2, 51, 1545);	insert into sth_charging_table (class_id, code_id, charge) values (3, 51, 2310);	insert into sth_charging_table (class_id, code_id, charge) values (4, 51, 2560);	insert into sth_charging_table (class_id, code_id, charge) values (5, 51, 2805);
insert into sth_charging_table (class_id, code_id, charge) values (1, 97, 5440);	insert into sth_charging_table (class_id, code_id, charge) values (2, 97, 5356);	insert into sth_charging_table (class_id, code_id, charge) values (3, 97, 5440);	insert into sth_charging_table (class_id, code_id, charge) values (4, 97, 8060);	insert into sth_charging_table (class_id, code_id, charge) values (5, 97, 8840);
insert into sth_charging_table (class_id, code_id, charge) values (1, 59, 3140);	insert into sth_charging_table (class_id, code_id, charge) values (2, 59, 3090);	insert into sth_charging_table (class_id, code_id, charge) values (3, 59, 3140);	insert into sth_charging_table (class_id, code_id, charge) values (4, 59, 4650);	insert into sth_charging_table (class_id, code_id, charge) values (5, 59, 5100);
insert into sth_charging_table (class_id, code_id, charge) values (1, 86, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 86, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 86, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 86, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 86, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 68, 1260);	insert into sth_charging_table (class_id, code_id, charge) values (2, 68, 1236);	insert into sth_charging_table (class_id, code_id, charge) values (3, 68, 1260);	insert into sth_charging_table (class_id, code_id, charge) values (4, 68, 1860);	insert into sth_charging_table (class_id, code_id, charge) values (5, 68, 2040);
insert into sth_charging_table (class_id, code_id, charge) values (1, 100, 19860);	insert into sth_charging_table (class_id, code_id, charge) values (2, 100, 19570);	insert into sth_charging_table (class_id, code_id, charge) values (3, 100, 19860);	insert into sth_charging_table (class_id, code_id, charge) values (4, 100, 29450);	insert into sth_charging_table (class_id, code_id, charge) values (5, 100, 32300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 101, 18400);	insert into sth_charging_table (class_id, code_id, charge) values (2, 101, 18128);	insert into sth_charging_table (class_id, code_id, charge) values (3, 101, 18400);	insert into sth_charging_table (class_id, code_id, charge) values (4, 101, 27280);	insert into sth_charging_table (class_id, code_id, charge) values (5, 101, 29920);
insert into sth_charging_table (class_id, code_id, charge) values (1, 102, 5860);	insert into sth_charging_table (class_id, code_id, charge) values (2, 102, 5768);	insert into sth_charging_table (class_id, code_id, charge) values (3, 102, 5860);	insert into sth_charging_table (class_id, code_id, charge) values (4, 102, 8680);	insert into sth_charging_table (class_id, code_id, charge) values (5, 102, 9520);
insert into sth_charging_table (class_id, code_id, charge) values (1, 103, 20900);	insert into sth_charging_table (class_id, code_id, charge) values (2, 103, 20600);	insert into sth_charging_table (class_id, code_id, charge) values (3, 103, 20900);	insert into sth_charging_table (class_id, code_id, charge) values (4, 103, 31000);	insert into sth_charging_table (class_id, code_id, charge) values (5, 103, 34000);
insert into sth_charging_table (class_id, code_id, charge) values (1, 70, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 70, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 70, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 70, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 70, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 72, 5750);	insert into sth_charging_table (class_id, code_id, charge) values (2, 72, 5665);	insert into sth_charging_table (class_id, code_id, charge) values (3, 72, 5750);	insert into sth_charging_table (class_id, code_id, charge) values (4, 72, 8530);	insert into sth_charging_table (class_id, code_id, charge) values (5, 72, 9350);
insert into sth_charging_table (class_id, code_id, charge) values (1, 104, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 104, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 104, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 104, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 104, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 82, 52850);	insert into sth_charging_table (class_id, code_id, charge) values (2, 82, 44805);	insert into sth_charging_table (class_id, code_id, charge) values (3, 82, 52850);	insert into sth_charging_table (class_id, code_id, charge) values (4, 82, 72425);	insert into sth_charging_table (class_id, code_id, charge) values (5, 82, 78950);
insert into sth_charging_table (class_id, code_id, charge) values (1, 83, 44380);	insert into sth_charging_table (class_id, code_id, charge) values (2, 83, 36874);	insert into sth_charging_table (class_id, code_id, charge) values (3, 83, 44380);	insert into sth_charging_table (class_id, code_id, charge) values (4, 83, 60490);	insert into sth_charging_table (class_id, code_id, charge) values (5, 83, 65860);
insert into sth_charging_table (class_id, code_id, charge) values (1, 105, 18290);	insert into sth_charging_table (class_id, code_id, charge) values (2, 105, 18025);	insert into sth_charging_table (class_id, code_id, charge) values (3, 105, 18290);	insert into sth_charging_table (class_id, code_id, charge) values (4, 105, 27130);	insert into sth_charging_table (class_id, code_id, charge) values (5, 105, 29750);
insert into sth_charging_table (class_id, code_id, charge) values (1, 89, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (2, 89, 3296);	insert into sth_charging_table (class_id, code_id, charge) values (3, 89, 3350);	insert into sth_charging_table (class_id, code_id, charge) values (4, 89, 4960);	insert into sth_charging_table (class_id, code_id, charge) values (5, 89, 5440);
insert into sth_charging_table (class_id, code_id, charge) values (1, 76, 7110);	insert into sth_charging_table (class_id, code_id, charge) values (2, 76, 7004);	insert into sth_charging_table (class_id, code_id, charge) values (3, 76, 7110);	insert into sth_charging_table (class_id, code_id, charge) values (4, 76, 10540);	insert into sth_charging_table (class_id, code_id, charge) values (5, 76, 11560);
insert into sth_charging_table (class_id, code_id, charge) values (1, 94, 9930);	insert into sth_charging_table (class_id, code_id, charge) values (2, 94, 9785);	insert into sth_charging_table (class_id, code_id, charge) values (3, 94, 9930);	insert into sth_charging_table (class_id, code_id, charge) values (4, 94, 14730);	insert into sth_charging_table (class_id, code_id, charge) values (5, 94, 16150);
insert into sth_charging_table (class_id, code_id, charge) values (1, 92, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 92, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 92, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 92, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 92, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 93, 3140);	insert into sth_charging_table (class_id, code_id, charge) values (2, 93, 3090);	insert into sth_charging_table (class_id, code_id, charge) values (3, 93, 3140);	insert into sth_charging_table (class_id, code_id, charge) values (4, 93, 4650);	insert into sth_charging_table (class_id, code_id, charge) values (5, 93, 5100);
insert into sth_charging_table (class_id, code_id, charge) values (1, 95, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (2, 95, 9270);	insert into sth_charging_table (class_id, code_id, charge) values (3, 95, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (4, 95, 13950);	insert into sth_charging_table (class_id, code_id, charge) values (5, 95, 15300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 96, 6270);	insert into sth_charging_table (class_id, code_id, charge) values (2, 96, 6180);	insert into sth_charging_table (class_id, code_id, charge) values (3, 96, 6270);	insert into sth_charging_table (class_id, code_id, charge) values (4, 96, 9300);	insert into sth_charging_table (class_id, code_id, charge) values (5, 96, 10200);
insert into sth_charging_table (class_id, code_id, charge) values (1, 66, 5750);	insert into sth_charging_table (class_id, code_id, charge) values (2, 66, 5665);	insert into sth_charging_table (class_id, code_id, charge) values (3, 66, 5750);	insert into sth_charging_table (class_id, code_id, charge) values (4, 66, 8530);	insert into sth_charging_table (class_id, code_id, charge) values (5, 66, 9350);
insert into sth_charging_table (class_id, code_id, charge) values (1, 106, 10040);	insert into sth_charging_table (class_id, code_id, charge) values (2, 106, 9888);	insert into sth_charging_table (class_id, code_id, charge) values (3, 106, 10040);	insert into sth_charging_table (class_id, code_id, charge) values (4, 106, 14880);	insert into sth_charging_table (class_id, code_id, charge) values (5, 106, 16320);
insert into sth_charging_table (class_id, code_id, charge) values (1, 107, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 107, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 107, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 107, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 107, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 108, 2410);	insert into sth_charging_table (class_id, code_id, charge) values (2, 108, 2369);	insert into sth_charging_table (class_id, code_id, charge) values (3, 108, 2410);	insert into sth_charging_table (class_id, code_id, charge) values (4, 108, 3570);	insert into sth_charging_table (class_id, code_id, charge) values (5, 108, 3910);
insert into sth_charging_table (class_id, code_id, charge) values (1, 110, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (2, 110, 9270);	insert into sth_charging_table (class_id, code_id, charge) values (3, 110, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (4, 110, 13950);	insert into sth_charging_table (class_id, code_id, charge) values (5, 110, 15300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 111, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (2, 111, 9270);	insert into sth_charging_table (class_id, code_id, charge) values (3, 111, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (4, 111, 13950);	insert into sth_charging_table (class_id, code_id, charge) values (5, 111, 15300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 112, 1470);	insert into sth_charging_table (class_id, code_id, charge) values (2, 112, 1442);	insert into sth_charging_table (class_id, code_id, charge) values (3, 112, 1470);	insert into sth_charging_table (class_id, code_id, charge) values (4, 112, 2170);	insert into sth_charging_table (class_id, code_id, charge) values (5, 112, 2380);
insert into sth_charging_table (class_id, code_id, charge) values (1, 113, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (2, 113, 9270);	insert into sth_charging_table (class_id, code_id, charge) values (3, 113, 9410);	insert into sth_charging_table (class_id, code_id, charge) values (4, 113, 13950);	insert into sth_charging_table (class_id, code_id, charge) values (5, 113, 15300);
insert into sth_charging_table (class_id, code_id, charge) values (1, 114, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (2, 114, 2801.6);	insert into sth_charging_table (class_id, code_id, charge) values (3, 114, 2850);	insert into sth_charging_table (class_id, code_id, charge) values (4, 114, 4220);	insert into sth_charging_table (class_id, code_id, charge) values (5, 114, 4630);
insert into sth_charging_table (class_id, code_id, charge) values (1, 115, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (2, 115, 4120);	insert into sth_charging_table (class_id, code_id, charge) values (3, 115, 4180);	insert into sth_charging_table (class_id, code_id, charge) values (4, 115, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 115, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 116, 10450);	insert into sth_charging_table (class_id, code_id, charge) values (2, 116, 10300);	insert into sth_charging_table (class_id, code_id, charge) values (3, 116, 10450);	insert into sth_charging_table (class_id, code_id, charge) values (4, 116, 15500);	insert into sth_charging_table (class_id, code_id, charge) values (5, 116, 17000);
insert into sth_charging_table (class_id, code_id, charge) values (1, 117, 2620);	insert into sth_charging_table (class_id, code_id, charge) values (2, 117, 2575);	insert into sth_charging_table (class_id, code_id, charge) values (3, 117, 2620);	insert into sth_charging_table (class_id, code_id, charge) values (4, 117, 3880);	insert into sth_charging_table (class_id, code_id, charge) values (5, 117, 4250);
insert into sth_charging_table (class_id, code_id, charge) values (1, 118, 7320);	insert into sth_charging_table (class_id, code_id, charge) values (2, 118, 7210);	insert into sth_charging_table (class_id, code_id, charge) values (3, 118, 7320);	insert into sth_charging_table (class_id, code_id, charge) values (4, 118, 10850);	insert into sth_charging_table (class_id, code_id, charge) values (5, 118, 11900);
insert into sth_charging_table (class_id, code_id, charge) values (1, 84, 45700);	insert into sth_charging_table (class_id, code_id, charge) values (2, 84, 38110);	insert into sth_charging_table (class_id, code_id, charge) values (3, 84, 45700);	insert into sth_charging_table (class_id, code_id, charge) values (4, 84, 62350);	insert into sth_charging_table (class_id, code_id, charge) values (5, 84, 67900);
insert into sth_charging_table (class_id, code_id, charge) values (1, 119, 1830);	insert into sth_charging_table (class_id, code_id, charge) values (2, 119, 1539);	insert into sth_charging_table (class_id, code_id, charge) values (3, 119, 1830);	insert into sth_charging_table (class_id, code_id, charge) values (4, 119, 2415);	insert into sth_charging_table (class_id, code_id, charge) values (5, 119, 2610);
insert into sth_charging_table (class_id, code_id, charge) values (1, 52, 2000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 52, 1400);	insert into sth_charging_table (class_id, code_id, charge) values (3, 52, 2800);	insert into sth_charging_table (class_id, code_id, charge) values (4, 52, 3100);	insert into sth_charging_table (class_id, code_id, charge) values (5, 52, 3400);
insert into sth_charging_table (class_id, code_id, charge) values (1, 53, 4000);	insert into sth_charging_table (class_id, code_id, charge) values (2, 53, 2800);	insert into sth_charging_table (class_id, code_id, charge) values (3, 53, 5600);	insert into sth_charging_table (class_id, code_id, charge) values (4, 53, 6200);	insert into sth_charging_table (class_id, code_id, charge) values (5, 53, 6800);
insert into sth_charging_table (class_id, code_id, charge) values (1, 54, 2840);	insert into sth_charging_table (class_id, code_id, charge) values (2, 54, 1990);	insert into sth_charging_table (class_id, code_id, charge) values (3, 54, 3980);	insert into sth_charging_table (class_id, code_id, charge) values (4, 54, 4400);	insert into sth_charging_table (class_id, code_id, charge) values (5, 54, 4840);
insert into sth_charging_table (class_id, code_id, charge) values (1, 55, 440);	insert into sth_charging_table (class_id, code_id, charge) values (2, 55, 412);	insert into sth_charging_table (class_id, code_id, charge) values (3, 55, 620);	insert into sth_charging_table (class_id, code_id, charge) values (4, 55, 680);	insert into sth_charging_table (class_id, code_id, charge) values (5, 55, 750);
insert into sth_charging_table (class_id, code_id, charge) values (1, 69, 16500);	insert into sth_charging_table (class_id, code_id, charge) values (2, 69, 15450);	insert into sth_charging_table (class_id, code_id, charge) values (3, 69, 23100);	insert into sth_charging_table (class_id, code_id, charge) values (4, 69, 25580);	insert into sth_charging_table (class_id, code_id, charge) values (5, 69, 28050);
insert into sth_charging_table (class_id, code_id, charge) values (1, 77, 11880);	insert into sth_charging_table (class_id, code_id, charge) values (2, 77, 11124);	insert into sth_charging_table (class_id, code_id, charge) values (3, 77, 16640);	insert into sth_charging_table (class_id, code_id, charge) values (4, 77, 18420);	insert into sth_charging_table (class_id, code_id, charge) values (5, 77, 20200);
insert into sth_charging_table (class_id, code_id, charge) values (1, 78, 8890);	insert into sth_charging_table (class_id, code_id, charge) values (2, 78, 8317);	insert into sth_charging_table (class_id, code_id, charge) values (3, 78, 12450);	insert into sth_charging_table (class_id, code_id, charge) values (4, 78, 13780);	insert into sth_charging_table (class_id, code_id, charge) values (5, 78, 15120);
insert into sth_charging_table (class_id, code_id, charge) values (1, 79, 8890);	insert into sth_charging_table (class_id, code_id, charge) values (2, 79, 8317);	insert into sth_charging_table (class_id, code_id, charge) values (3, 79, 12450);	insert into sth_charging_table (class_id, code_id, charge) values (4, 79, 13780);	insert into sth_charging_table (class_id, code_id, charge) values (5, 79, 15120);
insert into sth_charging_table (class_id, code_id, charge) values (1, 56, 9020);	insert into sth_charging_table (class_id, code_id, charge) values (2, 56, 8446);	insert into sth_charging_table (class_id, code_id, charge) values (3, 56, 12630);	insert into sth_charging_table (class_id, code_id, charge) values (4, 56, 13980);	insert into sth_charging_table (class_id, code_id, charge) values (5, 56, 15330);

update sth_charging_table set update_at = getdate(), update_by = getdate(), create_by = 'sys';

--BXCY_SPECIMEN table
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'classId' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD classId int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId1' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId1 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge1' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge1 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId2' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId2 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge2' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge2 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId3' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId3 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge3' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge3 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId4' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId4 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge4' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge4 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId5' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId5 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge5' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge5 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId6' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId6 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge6' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge6 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId7' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId7 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge7' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge7 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId8' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId8 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge8' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge8 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId9' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId9 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge9' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge9 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'codeId10' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD codeId10 int NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'charge10' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD charge10 numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'chargeOther' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD chargeOther numeric(18,2) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'chargeTotal' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
ALTER TABLE BXCY_SPECIMEN ADD chargeTotal numeric(18,2) NULL;
END

--client table
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CORE_BX' AND LTRIM(b.name)='client')
BEGIN
ALTER TABLE client ADD PRICE_CORE_BX float NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_NONGYNAE' AND LTRIM(b.name)='client')
BEGIN
ALTER TABLE client ADD PRICE_CY_NONGYNAE float NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_FNA' AND LTRIM(b.name)='client')
BEGIN
ALTER TABLE client ADD PRICE_CY_FNA float NULL;
END

--BXCY_SPECIMEN table
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_BX' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_BX] [float] NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CORE_BX' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CORE_BX] [float] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CY] [float] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_NONGYNAE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CY_NONGYNAE] [float] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_FNA' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CY_FNA] [float] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_EBV' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_EBV] [float] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CYG' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CYG] [float] NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_BX_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_BX_GRADE] [int] NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CORE_BX_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CORE_BX_GRADE] [int] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CY_GRADE] [int] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_NONGYNAE_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CY_NONGYNAE_GRADE] [int] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CY_FNA_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CY_FNA_GRADE] [int] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_EBV_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_EBV_GRADE] [int] NULL;
END
	
IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'PRICE_CYG_GRADE' AND LTRIM(b.name)='BXCY_SPECIMEN')
BEGIN
	ALTER TABLE BXCY_SPECIMEN ADD [PRICE_CYG_GRADE] [int] NULL;
END


--cy_diag1 table
UPDATE cy_diag1 SET SITE1='1' where SITE1='Y';
UPDATE cy_diag1 SET SITE1='0' where SITE1<>'1';
alter table cy_diag1 alter column SITE1 bit null;
UPDATE cy_diag1 SET SITE1=0 where SITE1 IS NULL;

UPDATE cy_diag1 SET SITE2='1' where SITE2='Y';
UPDATE cy_diag1 SET SITE2='0' where SITE2<>'1';
alter table cy_diag1 alter column SITE2 bit null;
UPDATE cy_diag1 SET SITE2=0 where SITE2 IS NULL;

UPDATE cy_diag1 SET SPECIMENA1='1' where SPECIMENA1='Y';
UPDATE cy_diag1 SET SPECIMENA1='0' where SPECIMENA1<>'1';
alter table cy_diag1 alter column SPECIMENA1 bit null;
UPDATE cy_diag1 SET SPECIMENA1=0 where SPECIMENA1 IS NULL;

UPDATE cy_diag1 SET SPECIMENA2='1' where SPECIMENA2='Y';
UPDATE cy_diag1 SET SPECIMENA2='0' where SPECIMENA2<>'1';
alter table cy_diag1 alter column SPECIMENA2 bit null;
UPDATE cy_diag1 SET SPECIMENA2=0 where SPECIMENA2 IS NULL;

UPDATE cy_diag1 SET SPECIMENA3='1' where SPECIMENA3='Y';
UPDATE cy_diag1 SET SPECIMENA3='0' where SPECIMENA3<>'1';
alter table cy_diag1 alter column SPECIMENA3 bit null;
UPDATE cy_diag1 SET SPECIMENA3=0 where SPECIMENA3 IS NULL;

UPDATE cy_diag1 SET CELLULARC1='1' where CELLULARC1='Y';
UPDATE cy_diag1 SET CELLULARC1='0' where CELLULARC1<>'1';
alter table cy_diag1 alter column CELLULARC1 bit null;
UPDATE cy_diag1 SET CELLULARC1=0 where CELLULARC1 IS NULL;

UPDATE cy_diag1 SET CELLULARC2='1' where CELLULARC2='Y';
UPDATE cy_diag1 SET CELLULARC2='0' where CELLULARC2<>'1';
alter table cy_diag1 alter column CELLULARC2 bit null;
UPDATE cy_diag1 SET CELLULARC2=0 where CELLULARC2 IS NULL;

UPDATE cy_diag1 SET CELLULARC3='1' where CELLULARC3='Y';
UPDATE cy_diag1 SET CELLULARC3='0' where CELLULARC3<>'1';
alter table cy_diag1 alter column CELLULARC3 bit null;
UPDATE cy_diag1 SET CELLULARC3=0 where CELLULARC3 IS NULL;

UPDATE cy_diag1 SET CELLULARC4='1' where CELLULARC4='Y';
UPDATE cy_diag1 SET CELLULARC4='0' where CELLULARC4<>'1';
alter table cy_diag1 alter column CELLULARC4 bit null;
UPDATE cy_diag1 SET CELLULARC4=0 where CELLULARC4 IS NULL;

UPDATE cy_diag1 SET CELLULARC5='1' where CELLULARC5='Y';
UPDATE cy_diag1 SET CELLULARC5='0' where CELLULARC5<>'1';
alter table cy_diag1 alter column CELLULARC5 bit null;
UPDATE cy_diag1 SET CELLULARC5=0 where CELLULARC5 IS NULL;

UPDATE cy_diag1 SET PREPAIR1='1' where PREPAIR1='Y';
UPDATE cy_diag1 SET PREPAIR1='0' where PREPAIR1<>'1';
alter table cy_diag1 alter column PREPAIR1 bit null;
UPDATE cy_diag1 SET PREPAIR1=0 where PREPAIR1 IS NULL;

UPDATE cy_diag1 SET PREPAIR2='1' where PREPAIR2='Y';
UPDATE cy_diag1 SET PREPAIR2='0' where PREPAIR2<>'1';
alter table cy_diag1 alter column PREPAIR2 bit null;
UPDATE cy_diag1 SET PREPAIR2=0 where PREPAIR2 IS NULL;

UPDATE cy_diag1 SET PREPAIR3='1' where PREPAIR3='Y';
UPDATE cy_diag1 SET PREPAIR3='0' where PREPAIR3<>'1';
alter table cy_diag1 alter column PREPAIR3 bit null;
UPDATE cy_diag1 SET PREPAIR3=0 where PREPAIR3 IS NULL;

UPDATE cy_diag1 SET PREPAIR4='1' where PREPAIR4='Y';
UPDATE cy_diag1 SET PREPAIR4='0' where PREPAIR4<>'1';
alter table cy_diag1 alter column PREPAIR4 bit null;
UPDATE cy_diag1 SET PREPAIR4=0 where PREPAIR4 IS NULL;

UPDATE cy_diag1 SET SPECIMENQ1='1' where SPECIMENQ1='Y';
UPDATE cy_diag1 SET SPECIMENQ1='0' where SPECIMENQ1<>'1';
alter table cy_diag1 alter column SPECIMENQ1 bit null;
UPDATE cy_diag1 SET SPECIMENQ1=0 where SPECIMENQ1 IS NULL;

UPDATE cy_diag1 SET SPECIMENQ2='1' where SPECIMENQ2='Y';
UPDATE cy_diag1 SET SPECIMENQ2='0' where SPECIMENQ2<>'1';
alter table cy_diag1 alter column SPECIMENQ2 bit null;
UPDATE cy_diag1 SET SPECIMENQ2=0 where SPECIMENQ2 IS NULL;

UPDATE cy_diag1 SET SPECIMENQ3='1' where SPECIMENQ3='Y';
UPDATE cy_diag1 SET SPECIMENQ3='0' where SPECIMENQ3<>'1';
alter table cy_diag1 alter column SPECIMENQ3 bit null;
UPDATE cy_diag1 SET SPECIMENQ3=0 where SPECIMENQ3 IS NULL;

UPDATE cy_diag1 SET SPECIMENQ4='1' where SPECIMENQ4='Y';
UPDATE cy_diag1 SET SPECIMENQ4='0' where SPECIMENQ4<>'1';
alter table cy_diag1 alter column SPECIMENQ4 bit null;
UPDATE cy_diag1 SET SPECIMENQ4=0 where SPECIMENQ4 IS NULL;

UPDATE cy_diag1 SET SPECIMENQ5='1' where SPECIMENQ5='Y';
UPDATE cy_diag1 SET SPECIMENQ5='0' where SPECIMENQ5<>'1';
alter table cy_diag1 alter column SPECIMENQ5 bit null;
UPDATE cy_diag1 SET SPECIMENQ5=0 where SPECIMENQ5 IS NULL;

UPDATE cy_diag1 SET INTERNEG='1' where INTERNEG='Y';
UPDATE cy_diag1 SET INTERNEG='0' where INTERNEG<>'1';
alter table cy_diag1 alter column INTERNEG bit null;
UPDATE cy_diag1 SET INTERNEG=0 where INTERNEG IS NULL;

UPDATE cy_diag1 SET INTERNEG1='1' where INTERNEG1='Y';
UPDATE cy_diag1 SET INTERNEG1='0' where INTERNEG1<>'1';
alter table cy_diag1 alter column INTERNEG1 bit null;
UPDATE cy_diag1 SET INTERNEG1=0 where INTERNEG1 IS NULL;

UPDATE cy_diag1 SET INTERNEG2='1' where INTERNEG2='Y';
UPDATE cy_diag1 SET INTERNEG2='0' where INTERNEG2<>'1';
alter table cy_diag1 alter column INTERNEG2 bit null;
UPDATE cy_diag1 SET INTERNEG2=0 where INTERNEG2 IS NULL;

UPDATE cy_diag1 SET INTERNEG3='1' where INTERNEG3='Y';
UPDATE cy_diag1 SET INTERNEG3='0' where INTERNEG3<>'1';
alter table cy_diag1 alter column INTERNEG3 bit null;
UPDATE cy_diag1 SET INTERNEG3=0 where INTERNEG3 IS NULL;

UPDATE cy_diag1 SET INTERNEG4='1' where INTERNEG4='Y';
UPDATE cy_diag1 SET INTERNEG4='0' where INTERNEG4<>'1';
alter table cy_diag1 alter column INTERNEG4 bit null;
UPDATE cy_diag1 SET INTERNEG4=0 where INTERNEG4 IS NULL;

UPDATE cy_diag1 SET INTERNEG5='1' where INTERNEG5='Y';
UPDATE cy_diag1 SET INTERNEG5='0' where INTERNEG5<>'1';
alter table cy_diag1 alter column INTERNEG5 bit null;
UPDATE cy_diag1 SET INTERNEG5=0 where INTERNEG5 IS NULL;

UPDATE cy_diag1 SET INTERNEG6='1' where INTERNEG6='Y';
UPDATE cy_diag1 SET INTERNEG6='0' where INTERNEG6<>'1';
alter table cy_diag1 alter column INTERNEG6 bit null;
UPDATE cy_diag1 SET INTERNEG6=0 where INTERNEG6 IS NULL;

UPDATE cy_diag1 SET INTERNEG7='1' where INTERNEG7='Y';
UPDATE cy_diag1 SET INTERNEG7='0' where INTERNEG7<>'1';
alter table cy_diag1 alter column INTERNEG7 bit null;
UPDATE cy_diag1 SET INTERNEG7=0 where INTERNEG7 IS NULL;

UPDATE cy_diag1 SET INTERNEG8='1' where INTERNEG8='Y';
UPDATE cy_diag1 SET INTERNEG8='0' where INTERNEG8<>'1';
alter table cy_diag1 alter column INTERNEG8 bit null;
UPDATE cy_diag1 SET INTERNEG8=0 where INTERNEG8 IS NULL;

UPDATE cy_diag1 SET INTERNEG9='1' where INTERNEG9='Y';
UPDATE cy_diag1 SET INTERNEG9='0' where INTERNEG9<>'1';
alter table cy_diag1 alter column INTERNEG9 bit null;
UPDATE cy_diag1 SET INTERNEG9=0 where INTERNEG9 IS NULL;

UPDATE cy_diag1 SET INTEREPI='1' where INTEREPI='Y';
UPDATE cy_diag1 SET INTEREPI='0' where INTEREPI<>'1';
alter table cy_diag1 alter column INTEREPI bit null;
UPDATE cy_diag1 SET INTEREPI=0 where INTEREPI IS NULL;

UPDATE cy_diag1 SET INTEREPI1='1' where INTEREPI1='Y';
UPDATE cy_diag1 SET INTEREPI1='0' where INTEREPI1<>'1';
alter table cy_diag1 alter column INTEREPI1 bit null;
UPDATE cy_diag1 SET INTEREPI1=0 where INTEREPI1 IS NULL;

UPDATE cy_diag1 SET INTEREPI1A='1' where INTEREPI1A='Y';
UPDATE cy_diag1 SET INTEREPI1A='0' where INTEREPI1A<>'1';
alter table cy_diag1 alter column INTEREPI1A bit null;
UPDATE cy_diag1 SET INTEREPI1A=0 where INTEREPI1A IS NULL;

UPDATE cy_diag1 SET INTEREPI1B='1' where INTEREPI1B='Y';
UPDATE cy_diag1 SET INTEREPI1B='0' where INTEREPI1B<>'1';
alter table cy_diag1 alter column INTEREPI1B bit null;
UPDATE cy_diag1 SET INTEREPI1B=0 where INTEREPI1B IS NULL;

UPDATE cy_diag1 SET INTEREPI2='1' where INTEREPI2='Y';
UPDATE cy_diag1 SET INTEREPI2='0' where INTEREPI2<>'1';
alter table cy_diag1 alter column INTEREPI2 bit null;
UPDATE cy_diag1 SET INTEREPI2=0 where INTEREPI2 IS NULL;

UPDATE cy_diag1 SET INTEREPI2A='1' where INTEREPI2A='Y';
UPDATE cy_diag1 SET INTEREPI2A='0' where INTEREPI2A<>'1';
alter table cy_diag1 alter column INTEREPI2A bit null;
UPDATE cy_diag1 SET INTEREPI2A=0 where INTEREPI2A IS NULL;

UPDATE cy_diag1 SET INTEREPI2B='1' where INTEREPI2B='Y';
UPDATE cy_diag1 SET INTEREPI2B='0' where INTEREPI2B<>'1';
alter table cy_diag1 alter column INTEREPI2B bit null;
UPDATE cy_diag1 SET INTEREPI2B=0 where INTEREPI2B IS NULL;

UPDATE cy_diag1 SET INTEREPI2C='1' where INTEREPI2C='Y';
UPDATE cy_diag1 SET INTEREPI2C='0' where INTEREPI2C<>'1';
alter table cy_diag1 alter column INTEREPI2C bit null;
UPDATE cy_diag1 SET INTEREPI2C=0 where INTEREPI2C IS NULL;

UPDATE cy_diag1 SET INTEREPI3='1' where INTEREPI3='Y';
UPDATE cy_diag1 SET INTEREPI3='0' where INTEREPI3<>'1';
alter table cy_diag1 alter column INTEREPI3 bit null;
UPDATE cy_diag1 SET INTEREPI3=0 where INTEREPI3 IS NULL;

UPDATE cy_diag1 SET INTEREPI4='1' where INTEREPI4='Y';
UPDATE cy_diag1 SET INTEREPI4='0' where INTEREPI4<>'1';
alter table cy_diag1 alter column INTEREPI4 bit null;
UPDATE cy_diag1 SET INTEREPI4=0 where INTEREPI4 IS NULL;

UPDATE cy_diag1 SET INTEREPI4A='1' where INTEREPI4A='Y';
UPDATE cy_diag1 SET INTEREPI4A='0' where INTEREPI4A<>'1';
alter table cy_diag1 alter column INTEREPI4A bit null;
UPDATE cy_diag1 SET INTEREPI4A=0 where INTEREPI4A IS NULL;

UPDATE cy_diag1 SET INTEREPI4B='1' where INTEREPI4B='Y';
UPDATE cy_diag1 SET INTEREPI4B='0' where INTEREPI4B<>'1';
alter table cy_diag1 alter column INTEREPI4B bit null;
UPDATE cy_diag1 SET INTEREPI4B=0 where INTEREPI4B IS NULL;

UPDATE cy_diag1 SET INTEREPI4C='1' where INTEREPI4C='Y';
UPDATE cy_diag1 SET INTEREPI4C='0' where INTEREPI4C<>'1';
alter table cy_diag1 alter column INTEREPI4C bit null;
UPDATE cy_diag1 SET INTEREPI4C=0 where INTEREPI4C IS NULL;

UPDATE cy_diag1 SET INTEREPI5='1' where INTEREPI5='Y';
UPDATE cy_diag1 SET INTEREPI5='0' where INTEREPI5<>'1';
alter table cy_diag1 alter column INTEREPI5 bit null;
UPDATE cy_diag1 SET INTEREPI5=0 where INTEREPI5 IS NULL;

UPDATE cy_diag1 SET INTEREPI5A='1' where INTEREPI5A='Y';
UPDATE cy_diag1 SET INTEREPI5A='0' where INTEREPI5A<>'1';
alter table cy_diag1 alter column INTEREPI5A bit null;
UPDATE cy_diag1 SET INTEREPI5A=0 where INTEREPI5A IS NULL;

UPDATE cy_diag1 SET INTEREPI5B='1' where INTEREPI5B='Y';
UPDATE cy_diag1 SET INTEREPI5B='0' where INTEREPI5B<>'1';
alter table cy_diag1 alter column INTEREPI5B bit null;
UPDATE cy_diag1 SET INTEREPI5B=0 where INTEREPI5B IS NULL;

UPDATE cy_diag1 SET INTEREPI5C='1' where INTEREPI5C='Y';
UPDATE cy_diag1 SET INTEREPI5C='0' where INTEREPI5C<>'1';
alter table cy_diag1 alter column INTEREPI5C bit null;
UPDATE cy_diag1 SET INTEREPI5C=0 where INTEREPI5C IS NULL;

UPDATE cy_diag1 SET INTEREPI5D='1' where INTEREPI5D='Y';
UPDATE cy_diag1 SET INTEREPI5D='0' where INTEREPI5D<>'1';
alter table cy_diag1 alter column INTEREPI5D bit null;
UPDATE cy_diag1 SET INTEREPI5D=0 where INTEREPI5D IS NULL;

UPDATE cy_diag1 SET INTEREPI6='1' where INTEREPI6='Y';
UPDATE cy_diag1 SET INTEREPI6='0' where INTEREPI6<>'1';
alter table cy_diag1 alter column INTEREPI6 bit null;
UPDATE cy_diag1 SET INTEREPI6=0 where INTEREPI6 IS NULL;

UPDATE cy_diag1 SET HPV_DNA='1' where HPV_DNA='Y';
UPDATE cy_diag1 SET HPV_DNA='0' where HPV_DNA<>'1';
alter table cy_diag1 alter column HPV_DNA bit null;
UPDATE cy_diag1 SET HPV_DNA=0 where HPV_DNA IS NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='cy_diag1')
BEGIN
ALTER TABLE cy_diag1 ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE cy_diag1 ADD CONSTRAINT [PK_cy_diag1] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAG3')
BEGIN
ALTER TABLE cy_diag1 ADD [DIAG3] [nvarchar](255) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAG3_DESC')
BEGIN
ALTER TABLE cy_diag1 ADD [DIAG3_DESC] [nvarchar](255) NULL;
END


--cy_diag2 table
UPDATE cy_diag2 SET SITE1='1' where SITE1='Y';
UPDATE cy_diag2 SET SITE1='0' where SITE1<>'1';
alter table cy_diag2 alter column SITE1 bit null;
UPDATE cy_diag2 SET SITE1=0 where SITE1 IS NULL;

UPDATE cy_diag2 SET SITE2='1' where SITE2='Y';
UPDATE cy_diag2 SET SITE2='0' where SITE2<>'1';
alter table cy_diag2 alter column SITE2 bit null;
UPDATE cy_diag2 SET SITE2=0 where SITE2 IS NULL;

UPDATE cy_diag2 SET SPECIMENA1='1' where SPECIMENA1='Y';
UPDATE cy_diag2 SET SPECIMENA1='0' where SPECIMENA1<>'1';
alter table cy_diag2 alter column SPECIMENA1 bit null;
UPDATE cy_diag2 SET SPECIMENA1=0 where SPECIMENA1 IS NULL;

UPDATE cy_diag2 SET SPECIMENA2='1' where SPECIMENA2='Y';
UPDATE cy_diag2 SET SPECIMENA2='0' where SPECIMENA2<>'1';
alter table cy_diag2 alter column SPECIMENA2 bit null;
UPDATE cy_diag2 SET SPECIMENA2=0 where SPECIMENA2 IS NULL;

UPDATE cy_diag2 SET SPECIMENA3='1' where SPECIMENA3='Y';
UPDATE cy_diag2 SET SPECIMENA3='0' where SPECIMENA3<>'1';
alter table cy_diag2 alter column SPECIMENA3 bit null;
UPDATE cy_diag2 SET SPECIMENA3=0 where SPECIMENA3 IS NULL;

UPDATE cy_diag2 SET CELLULARC1='1' where CELLULARC1='Y';
UPDATE cy_diag2 SET CELLULARC1='0' where CELLULARC1<>'1';
alter table cy_diag2 alter column CELLULARC1 bit null;
UPDATE cy_diag2 SET CELLULARC1=0 where CELLULARC1 IS NULL;

UPDATE cy_diag2 SET CELLULARC2='1' where CELLULARC2='Y';
UPDATE cy_diag2 SET CELLULARC2='0' where CELLULARC2<>'1';
alter table cy_diag2 alter column CELLULARC2 bit null;
UPDATE cy_diag2 SET CELLULARC2=0 where CELLULARC2 IS NULL;

UPDATE cy_diag2 SET CELLULARC3='1' where CELLULARC3='Y';
UPDATE cy_diag2 SET CELLULARC3='0' where CELLULARC3<>'1';
alter table cy_diag2 alter column CELLULARC3 bit null;
UPDATE cy_diag2 SET CELLULARC3=0 where CELLULARC3 IS NULL;

UPDATE cy_diag2 SET CELLULARC4='1' where CELLULARC4='Y';
UPDATE cy_diag2 SET CELLULARC4='0' where CELLULARC4<>'1';
alter table cy_diag2 alter column CELLULARC4 bit null;
UPDATE cy_diag2 SET CELLULARC4=0 where CELLULARC4 IS NULL;

UPDATE cy_diag2 SET CELLULARC5='1' where CELLULARC5='Y';
UPDATE cy_diag2 SET CELLULARC5='0' where CELLULARC5<>'1';
alter table cy_diag2 alter column CELLULARC5 bit null;
UPDATE cy_diag2 SET CELLULARC5=0 where CELLULARC5 IS NULL;

UPDATE cy_diag2 SET PREPAIR1='1' where PREPAIR1='Y';
UPDATE cy_diag2 SET PREPAIR1='0' where PREPAIR1<>'1';
alter table cy_diag2 alter column PREPAIR1 bit null;
UPDATE cy_diag2 SET PREPAIR1=0 where PREPAIR1 IS NULL;

UPDATE cy_diag2 SET PREPAIR2='1' where PREPAIR2='Y';
UPDATE cy_diag2 SET PREPAIR2='0' where PREPAIR2<>'1';
alter table cy_diag2 alter column PREPAIR2 bit null;
UPDATE cy_diag2 SET PREPAIR2=0 where PREPAIR2 IS NULL;

UPDATE cy_diag2 SET PREPAIR3='1' where PREPAIR3='Y';
UPDATE cy_diag2 SET PREPAIR3='0' where PREPAIR3<>'1';
alter table cy_diag2 alter column PREPAIR3 bit null;
UPDATE cy_diag2 SET PREPAIR3=0 where PREPAIR3 IS NULL;

UPDATE cy_diag2 SET PREPAIR4='1' where PREPAIR4='Y';
UPDATE cy_diag2 SET PREPAIR4='0' where PREPAIR4<>'1';
alter table cy_diag2 alter column PREPAIR4 bit null;
UPDATE cy_diag2 SET PREPAIR4=0 where PREPAIR4 IS NULL;

UPDATE cy_diag2 SET SPECIMENQ1='1' where SPECIMENQ1='Y';
UPDATE cy_diag2 SET SPECIMENQ1='0' where SPECIMENQ1<>'1';
alter table cy_diag2 alter column SPECIMENQ1 bit null;
UPDATE cy_diag2 SET SPECIMENQ1=0 where SPECIMENQ1 IS NULL;

UPDATE cy_diag2 SET SPECIMENQ2='1' where SPECIMENQ2='Y';
UPDATE cy_diag2 SET SPECIMENQ2='0' where SPECIMENQ2<>'1';
alter table cy_diag2 alter column SPECIMENQ2 bit null;
UPDATE cy_diag2 SET SPECIMENQ2=0 where SPECIMENQ2 IS NULL;

UPDATE cy_diag2 SET SPECIMENQ3='1' where SPECIMENQ3='Y';
UPDATE cy_diag2 SET SPECIMENQ3='0' where SPECIMENQ3<>'1';
alter table cy_diag2 alter column SPECIMENQ3 bit null;
UPDATE cy_diag2 SET SPECIMENQ3=0 where SPECIMENQ3 IS NULL;

UPDATE cy_diag2 SET SPECIMENQ4='1' where SPECIMENQ4='Y';
UPDATE cy_diag2 SET SPECIMENQ4='0' where SPECIMENQ4<>'1';
alter table cy_diag2 alter column SPECIMENQ4 bit null;
UPDATE cy_diag2 SET SPECIMENQ4=0 where SPECIMENQ4 IS NULL;

UPDATE cy_diag2 SET SPECIMENQ5='1' where SPECIMENQ5='Y';
UPDATE cy_diag2 SET SPECIMENQ5='0' where SPECIMENQ5<>'1';
alter table cy_diag2 alter column SPECIMENQ5 bit null;
UPDATE cy_diag2 SET SPECIMENQ5=0 where SPECIMENQ5 IS NULL;

UPDATE cy_diag2 SET INTERNEG='1' where INTERNEG='Y';
UPDATE cy_diag2 SET INTERNEG='0' where INTERNEG<>'1';
alter table cy_diag2 alter column INTERNEG bit null;
UPDATE cy_diag2 SET INTERNEG=0 where INTERNEG IS NULL;

UPDATE cy_diag2 SET INTERNEG1='1' where INTERNEG1='Y';
UPDATE cy_diag2 SET INTERNEG1='0' where INTERNEG1<>'1';
alter table cy_diag2 alter column INTERNEG1 bit null;
UPDATE cy_diag2 SET INTERNEG1=0 where INTERNEG1 IS NULL;

UPDATE cy_diag2 SET INTERNEG2='1' where INTERNEG2='Y';
UPDATE cy_diag2 SET INTERNEG2='0' where INTERNEG2<>'1';
alter table cy_diag2 alter column INTERNEG2 bit null;
UPDATE cy_diag2 SET INTERNEG2=0 where INTERNEG2 IS NULL;

UPDATE cy_diag2 SET INTERNEG3='1' where INTERNEG3='Y';
UPDATE cy_diag2 SET INTERNEG3='0' where INTERNEG3<>'1';
alter table cy_diag2 alter column INTERNEG3 bit null;
UPDATE cy_diag2 SET INTERNEG3=0 where INTERNEG3 IS NULL;

UPDATE cy_diag2 SET INTERNEG4='1' where INTERNEG4='Y';
UPDATE cy_diag2 SET INTERNEG4='0' where INTERNEG4<>'1';
alter table cy_diag2 alter column INTERNEG4 bit null;
UPDATE cy_diag2 SET INTERNEG4=0 where INTERNEG4 IS NULL;

UPDATE cy_diag2 SET INTERNEG5='1' where INTERNEG5='Y';
UPDATE cy_diag2 SET INTERNEG5='0' where INTERNEG5<>'1';
alter table cy_diag2 alter column INTERNEG5 bit null;
UPDATE cy_diag2 SET INTERNEG5=0 where INTERNEG5 IS NULL;

UPDATE cy_diag2 SET INTERNEG6='1' where INTERNEG6='Y';
UPDATE cy_diag2 SET INTERNEG6='0' where INTERNEG6<>'1';
alter table cy_diag2 alter column INTERNEG6 bit null;
UPDATE cy_diag2 SET INTERNEG6=0 where INTERNEG6 IS NULL;

UPDATE cy_diag2 SET INTERNEG7='1' where INTERNEG7='Y';
UPDATE cy_diag2 SET INTERNEG7='0' where INTERNEG7<>'1';
alter table cy_diag2 alter column INTERNEG7 bit null;
UPDATE cy_diag2 SET INTERNEG7=0 where INTERNEG7 IS NULL;

UPDATE cy_diag2 SET INTERNEG8='1' where INTERNEG8='Y';
UPDATE cy_diag2 SET INTERNEG8='0' where INTERNEG8<>'1';
alter table cy_diag2 alter column INTERNEG8 bit null;
UPDATE cy_diag2 SET INTERNEG8=0 where INTERNEG8 IS NULL;

UPDATE cy_diag2 SET INTERNEG9='1' where INTERNEG9='Y';
UPDATE cy_diag2 SET INTERNEG9='0' where INTERNEG9<>'1';
alter table cy_diag2 alter column INTERNEG9 bit null;
UPDATE cy_diag2 SET INTERNEG9=0 where INTERNEG9 IS NULL;

UPDATE cy_diag2 SET INTEREPI='1' where INTEREPI='Y';
UPDATE cy_diag2 SET INTEREPI='0' where INTEREPI<>'1';
alter table cy_diag2 alter column INTEREPI bit null;
UPDATE cy_diag2 SET INTEREPI=0 where INTEREPI IS NULL;

UPDATE cy_diag2 SET INTEREPI1='1' where INTEREPI1='Y';
UPDATE cy_diag2 SET INTEREPI1='0' where INTEREPI1<>'1';
alter table cy_diag2 alter column INTEREPI1 bit null;
UPDATE cy_diag2 SET INTEREPI1=0 where INTEREPI1 IS NULL;

UPDATE cy_diag2 SET INTEREPI1A='1' where INTEREPI1A='Y';
UPDATE cy_diag2 SET INTEREPI1A='0' where INTEREPI1A<>'1';
alter table cy_diag2 alter column INTEREPI1A bit null;
UPDATE cy_diag2 SET INTEREPI1A=0 where INTEREPI1A IS NULL;

UPDATE cy_diag2 SET INTEREPI1B='1' where INTEREPI1B='Y';
UPDATE cy_diag2 SET INTEREPI1B='0' where INTEREPI1B<>'1';
alter table cy_diag2 alter column INTEREPI1B bit null;
UPDATE cy_diag2 SET INTEREPI1B=0 where INTEREPI1B IS NULL;

UPDATE cy_diag2 SET INTEREPI2='1' where INTEREPI2='Y';
UPDATE cy_diag2 SET INTEREPI2='0' where INTEREPI2<>'1';
alter table cy_diag2 alter column INTEREPI2 bit null;
UPDATE cy_diag2 SET INTEREPI2=0 where INTEREPI2 IS NULL;

UPDATE cy_diag2 SET INTEREPI2A='1' where INTEREPI2A='Y';
UPDATE cy_diag2 SET INTEREPI2A='0' where INTEREPI2A<>'1';
alter table cy_diag2 alter column INTEREPI2A bit null;
UPDATE cy_diag2 SET INTEREPI2A=0 where INTEREPI2A IS NULL;

UPDATE cy_diag2 SET INTEREPI2B='1' where INTEREPI2B='Y';
UPDATE cy_diag2 SET INTEREPI2B='0' where INTEREPI2B<>'1';
alter table cy_diag2 alter column INTEREPI2B bit null;
UPDATE cy_diag2 SET INTEREPI2B=0 where INTEREPI2B IS NULL;

UPDATE cy_diag2 SET INTEREPI2C='1' where INTEREPI2C='Y';
UPDATE cy_diag2 SET INTEREPI2C='0' where INTEREPI2C<>'1';
alter table cy_diag2 alter column INTEREPI2C bit null;
UPDATE cy_diag2 SET INTEREPI2C=0 where INTEREPI2C IS NULL;

UPDATE cy_diag2 SET INTEREPI3='1' where INTEREPI3='Y';
UPDATE cy_diag2 SET INTEREPI3='0' where INTEREPI3<>'1';
alter table cy_diag2 alter column INTEREPI3 bit null;
UPDATE cy_diag2 SET INTEREPI3=0 where INTEREPI3 IS NULL;

UPDATE cy_diag2 SET INTEREPI4='1' where INTEREPI4='Y';
UPDATE cy_diag2 SET INTEREPI4='0' where INTEREPI4<>'1';
alter table cy_diag2 alter column INTEREPI4 bit null;
UPDATE cy_diag2 SET INTEREPI4=0 where INTEREPI4 IS NULL;

UPDATE cy_diag2 SET INTEREPI4A='1' where INTEREPI4A='Y';
UPDATE cy_diag2 SET INTEREPI4A='0' where INTEREPI4A<>'1';
alter table cy_diag2 alter column INTEREPI4A bit null;
UPDATE cy_diag2 SET INTEREPI4A=0 where INTEREPI4A IS NULL;

UPDATE cy_diag2 SET INTEREPI4B='1' where INTEREPI4B='Y';
UPDATE cy_diag2 SET INTEREPI4B='0' where INTEREPI4B<>'1';
alter table cy_diag2 alter column INTEREPI4B bit null;
UPDATE cy_diag2 SET INTEREPI4B=0 where INTEREPI4B IS NULL;

UPDATE cy_diag2 SET INTEREPI4C='1' where INTEREPI4C='Y';
UPDATE cy_diag2 SET INTEREPI4C='0' where INTEREPI4C<>'1';
alter table cy_diag2 alter column INTEREPI4C bit null;
UPDATE cy_diag2 SET INTEREPI4C=0 where INTEREPI4C IS NULL;

UPDATE cy_diag2 SET INTEREPI5='1' where INTEREPI5='Y';
UPDATE cy_diag2 SET INTEREPI5='0' where INTEREPI5<>'1';
alter table cy_diag2 alter column INTEREPI5 bit null;
UPDATE cy_diag2 SET INTEREPI5=0 where INTEREPI5 IS NULL;

UPDATE cy_diag2 SET INTEREPI5A='1' where INTEREPI5A='Y';
UPDATE cy_diag2 SET INTEREPI5A='0' where INTEREPI5A<>'1';
alter table cy_diag2 alter column INTEREPI5A bit null;
UPDATE cy_diag2 SET INTEREPI5A=0 where INTEREPI5A IS NULL;

UPDATE cy_diag2 SET INTEREPI5B='1' where INTEREPI5B='Y';
UPDATE cy_diag2 SET INTEREPI5B='0' where INTEREPI5B<>'1';
alter table cy_diag2 alter column INTEREPI5B bit null;
UPDATE cy_diag2 SET INTEREPI5B=0 where INTEREPI5B IS NULL;

UPDATE cy_diag2 SET INTEREPI5C='1' where INTEREPI5C='Y';
UPDATE cy_diag2 SET INTEREPI5C='0' where INTEREPI5C<>'1';
alter table cy_diag2 alter column INTEREPI5C bit null;
UPDATE cy_diag2 SET INTEREPI5C=0 where INTEREPI5C IS NULL;

UPDATE cy_diag2 SET INTEREPI5D='1' where INTEREPI5D='Y';
UPDATE cy_diag2 SET INTEREPI5D='0' where INTEREPI5D<>'1';
alter table cy_diag2 alter column INTEREPI5D bit null;
UPDATE cy_diag2 SET INTEREPI5D=0 where INTEREPI5D IS NULL;

UPDATE cy_diag2 SET INTEREPI6='1' where INTEREPI6='Y';
UPDATE cy_diag2 SET INTEREPI6='0' where INTEREPI6<>'1';
alter table cy_diag2 alter column INTEREPI6 bit null;
UPDATE cy_diag2 SET INTEREPI6=0 where INTEREPI6 IS NULL;

UPDATE cy_diag2 SET HPV_DNA='1' where HPV_DNA='Y';
UPDATE cy_diag2 SET HPV_DNA='0' where HPV_DNA<>'1';
alter table cy_diag2 alter column HPV_DNA bit null;
UPDATE cy_diag2 SET HPV_DNA=0 where HPV_DNA IS NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='cy_diag2')
BEGIN
ALTER TABLE cy_diag2 ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE cy_diag2 ADD CONSTRAINT [PK_cy_diag2] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAG3')
BEGIN
ALTER TABLE cy_diag2 ADD [DIAG3] [nvarchar](255) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAG3_DESC')
BEGIN
ALTER TABLE cy_diag2 ADD [DIAG3_DESC] [nvarchar](255) NULL;
END


--cy_diag3 table
UPDATE cy_diag3 SET SITE1='1' where SITE1='Y';
UPDATE cy_diag3 SET SITE1='0' where SITE1<>'1';
alter table cy_diag3 alter column SITE1 bit null;
UPDATE cy_diag3 SET SITE1=0 where SITE1 IS NULL;

UPDATE cy_diag3 SET SITE2='1' where SITE2='Y';
UPDATE cy_diag3 SET SITE2='0' where SITE2<>'1';
alter table cy_diag3 alter column SITE2 bit null;
UPDATE cy_diag3 SET SITE2=0 where SITE2 IS NULL;

UPDATE cy_diag3 SET SPECIMENA1='1' where SPECIMENA1='Y';
UPDATE cy_diag3 SET SPECIMENA1='0' where SPECIMENA1<>'1';
alter table cy_diag3 alter column SPECIMENA1 bit null;
UPDATE cy_diag3 SET SPECIMENA1=0 where SPECIMENA1 IS NULL;

UPDATE cy_diag3 SET SPECIMENA2='1' where SPECIMENA2='Y';
UPDATE cy_diag3 SET SPECIMENA2='0' where SPECIMENA2<>'1';
alter table cy_diag3 alter column SPECIMENA2 bit null;
UPDATE cy_diag3 SET SPECIMENA2=0 where SPECIMENA2 IS NULL;

UPDATE cy_diag3 SET SPECIMENA3='1' where SPECIMENA3='Y';
UPDATE cy_diag3 SET SPECIMENA3='0' where SPECIMENA3<>'1';
alter table cy_diag3 alter column SPECIMENA3 bit null;
UPDATE cy_diag3 SET SPECIMENA3=0 where SPECIMENA3 IS NULL;

UPDATE cy_diag3 SET CELLULARC1='1' where CELLULARC1='Y';
UPDATE cy_diag3 SET CELLULARC1='0' where CELLULARC1<>'1';
alter table cy_diag3 alter column CELLULARC1 bit null;
UPDATE cy_diag3 SET CELLULARC1=0 where CELLULARC1 IS NULL;

UPDATE cy_diag3 SET CELLULARC2='1' where CELLULARC2='Y';
UPDATE cy_diag3 SET CELLULARC2='0' where CELLULARC2<>'1';
alter table cy_diag3 alter column CELLULARC2 bit null;
UPDATE cy_diag3 SET CELLULARC2=0 where CELLULARC2 IS NULL;

UPDATE cy_diag3 SET CELLULARC3='1' where CELLULARC3='Y';
UPDATE cy_diag3 SET CELLULARC3='0' where CELLULARC3<>'1';
alter table cy_diag3 alter column CELLULARC3 bit null;
UPDATE cy_diag3 SET CELLULARC3=0 where CELLULARC3 IS NULL;

UPDATE cy_diag3 SET CELLULARC4='1' where CELLULARC4='Y';
UPDATE cy_diag3 SET CELLULARC4='0' where CELLULARC4<>'1';
alter table cy_diag3 alter column CELLULARC4 bit null;
UPDATE cy_diag3 SET CELLULARC4=0 where CELLULARC4 IS NULL;

UPDATE cy_diag3 SET CELLULARC5='1' where CELLULARC5='Y';
UPDATE cy_diag3 SET CELLULARC5='0' where CELLULARC5<>'1';
alter table cy_diag3 alter column CELLULARC5 bit null;
UPDATE cy_diag3 SET CELLULARC5=0 where CELLULARC5 IS NULL;

UPDATE cy_diag3 SET PREPAIR1='1' where PREPAIR1='Y';
UPDATE cy_diag3 SET PREPAIR1='0' where PREPAIR1<>'1';
alter table cy_diag3 alter column PREPAIR1 bit null;
UPDATE cy_diag3 SET PREPAIR1=0 where PREPAIR1 IS NULL;

UPDATE cy_diag3 SET PREPAIR2='1' where PREPAIR2='Y';
UPDATE cy_diag3 SET PREPAIR2='0' where PREPAIR2<>'1';
alter table cy_diag3 alter column PREPAIR2 bit null;
UPDATE cy_diag3 SET PREPAIR2=0 where PREPAIR2 IS NULL;

UPDATE cy_diag3 SET PREPAIR3='1' where PREPAIR3='Y';
UPDATE cy_diag3 SET PREPAIR3='0' where PREPAIR3<>'1';
alter table cy_diag3 alter column PREPAIR3 bit null;
UPDATE cy_diag3 SET PREPAIR3=0 where PREPAIR3 IS NULL;

UPDATE cy_diag3 SET PREPAIR4='1' where PREPAIR4='Y';
UPDATE cy_diag3 SET PREPAIR4='0' where PREPAIR4<>'1';
alter table cy_diag3 alter column PREPAIR4 bit null;
UPDATE cy_diag3 SET PREPAIR4=0 where PREPAIR4 IS NULL;

UPDATE cy_diag3 SET SPECIMENQ1='1' where SPECIMENQ1='Y';
UPDATE cy_diag3 SET SPECIMENQ1='0' where SPECIMENQ1<>'1';
alter table cy_diag3 alter column SPECIMENQ1 bit null;
UPDATE cy_diag3 SET SPECIMENQ1=0 where SPECIMENQ1 IS NULL;

UPDATE cy_diag3 SET SPECIMENQ2='1' where SPECIMENQ2='Y';
UPDATE cy_diag3 SET SPECIMENQ2='0' where SPECIMENQ2<>'1';
alter table cy_diag3 alter column SPECIMENQ2 bit null;
UPDATE cy_diag3 SET SPECIMENQ2=0 where SPECIMENQ2 IS NULL;

UPDATE cy_diag3 SET SPECIMENQ3='1' where SPECIMENQ3='Y';
UPDATE cy_diag3 SET SPECIMENQ3='0' where SPECIMENQ3<>'1';
alter table cy_diag3 alter column SPECIMENQ3 bit null;
UPDATE cy_diag3 SET SPECIMENQ3=0 where SPECIMENQ3 IS NULL;

UPDATE cy_diag3 SET SPECIMENQ4='1' where SPECIMENQ4='Y';
UPDATE cy_diag3 SET SPECIMENQ4='0' where SPECIMENQ4<>'1';
alter table cy_diag3 alter column SPECIMENQ4 bit null;
UPDATE cy_diag3 SET SPECIMENQ4=0 where SPECIMENQ4 IS NULL;

UPDATE cy_diag3 SET SPECIMENQ5='1' where SPECIMENQ5='Y';
UPDATE cy_diag3 SET SPECIMENQ5='0' where SPECIMENQ5<>'1';
alter table cy_diag3 alter column SPECIMENQ5 bit null;
UPDATE cy_diag3 SET SPECIMENQ5=0 where SPECIMENQ5 IS NULL;

UPDATE cy_diag3 SET INTERNEG='1' where INTERNEG='Y';
UPDATE cy_diag3 SET INTERNEG='0' where INTERNEG<>'1';
alter table cy_diag3 alter column INTERNEG bit null;
UPDATE cy_diag3 SET INTERNEG=0 where INTERNEG IS NULL;

UPDATE cy_diag3 SET INTERNEG1='1' where INTERNEG1='Y';
UPDATE cy_diag3 SET INTERNEG1='0' where INTERNEG1<>'1';
alter table cy_diag3 alter column INTERNEG1 bit null;
UPDATE cy_diag3 SET INTERNEG1=0 where INTERNEG1 IS NULL;

UPDATE cy_diag3 SET INTERNEG2='1' where INTERNEG2='Y';
UPDATE cy_diag3 SET INTERNEG2='0' where INTERNEG2<>'1';
alter table cy_diag3 alter column INTERNEG2 bit null;
UPDATE cy_diag3 SET INTERNEG2=0 where INTERNEG2 IS NULL;

UPDATE cy_diag3 SET INTERNEG3='1' where INTERNEG3='Y';
UPDATE cy_diag3 SET INTERNEG3='0' where INTERNEG3<>'1';
alter table cy_diag3 alter column INTERNEG3 bit null;
UPDATE cy_diag3 SET INTERNEG3=0 where INTERNEG3 IS NULL;

UPDATE cy_diag3 SET INTERNEG4='1' where INTERNEG4='Y';
UPDATE cy_diag3 SET INTERNEG4='0' where INTERNEG4<>'1';
alter table cy_diag3 alter column INTERNEG4 bit null;
UPDATE cy_diag3 SET INTERNEG4=0 where INTERNEG4 IS NULL;

UPDATE cy_diag3 SET INTERNEG5='1' where INTERNEG5='Y';
UPDATE cy_diag3 SET INTERNEG5='0' where INTERNEG5<>'1';
alter table cy_diag3 alter column INTERNEG5 bit null;
UPDATE cy_diag3 SET INTERNEG5=0 where INTERNEG5 IS NULL;

UPDATE cy_diag3 SET INTERNEG6='1' where INTERNEG6='Y';
UPDATE cy_diag3 SET INTERNEG6='0' where INTERNEG6<>'1';
alter table cy_diag3 alter column INTERNEG6 bit null;
UPDATE cy_diag3 SET INTERNEG6=0 where INTERNEG6 IS NULL;

UPDATE cy_diag3 SET INTERNEG7='1' where INTERNEG7='Y';
UPDATE cy_diag3 SET INTERNEG7='0' where INTERNEG7<>'1';
alter table cy_diag3 alter column INTERNEG7 bit null;
UPDATE cy_diag3 SET INTERNEG7=0 where INTERNEG7 IS NULL;

UPDATE cy_diag3 SET INTERNEG8='1' where INTERNEG8='Y';
UPDATE cy_diag3 SET INTERNEG8='0' where INTERNEG8<>'1';
alter table cy_diag3 alter column INTERNEG8 bit null;
UPDATE cy_diag3 SET INTERNEG8=0 where INTERNEG8 IS NULL;

UPDATE cy_diag3 SET INTERNEG9='1' where INTERNEG9='Y';
UPDATE cy_diag3 SET INTERNEG9='0' where INTERNEG9<>'1';
alter table cy_diag3 alter column INTERNEG9 bit null;
UPDATE cy_diag3 SET INTERNEG9=0 where INTERNEG9 IS NULL;

UPDATE cy_diag3 SET INTEREPI='1' where INTEREPI='Y';
UPDATE cy_diag3 SET INTEREPI='0' where INTEREPI<>'1';
alter table cy_diag3 alter column INTEREPI bit null;
UPDATE cy_diag3 SET INTEREPI=0 where INTEREPI IS NULL;

UPDATE cy_diag3 SET INTEREPI1='1' where INTEREPI1='Y';
UPDATE cy_diag3 SET INTEREPI1='0' where INTEREPI1<>'1';
alter table cy_diag3 alter column INTEREPI1 bit null;
UPDATE cy_diag3 SET INTEREPI1=0 where INTEREPI1 IS NULL;

UPDATE cy_diag3 SET INTEREPI1A='1' where INTEREPI1A='Y';
UPDATE cy_diag3 SET INTEREPI1A='0' where INTEREPI1A<>'1';
alter table cy_diag3 alter column INTEREPI1A bit null;
UPDATE cy_diag3 SET INTEREPI1A=0 where INTEREPI1A IS NULL;

UPDATE cy_diag3 SET INTEREPI1B='1' where INTEREPI1B='Y';
UPDATE cy_diag3 SET INTEREPI1B='0' where INTEREPI1B<>'1';
alter table cy_diag3 alter column INTEREPI1B bit null;
UPDATE cy_diag3 SET INTEREPI1B=0 where INTEREPI1B IS NULL;

UPDATE cy_diag3 SET INTEREPI2='1' where INTEREPI2='Y';
UPDATE cy_diag3 SET INTEREPI2='0' where INTEREPI2<>'1';
alter table cy_diag3 alter column INTEREPI2 bit null;
UPDATE cy_diag3 SET INTEREPI2=0 where INTEREPI2 IS NULL;

UPDATE cy_diag3 SET INTEREPI2A='1' where INTEREPI2A='Y';
UPDATE cy_diag3 SET INTEREPI2A='0' where INTEREPI2A<>'1';
alter table cy_diag3 alter column INTEREPI2A bit null;
UPDATE cy_diag3 SET INTEREPI2A=0 where INTEREPI2A IS NULL;

UPDATE cy_diag3 SET INTEREPI2B='1' where INTEREPI2B='Y';
UPDATE cy_diag3 SET INTEREPI2B='0' where INTEREPI2B<>'1';
alter table cy_diag3 alter column INTEREPI2B bit null;
UPDATE cy_diag3 SET INTEREPI2B=0 where INTEREPI2B IS NULL;

UPDATE cy_diag3 SET INTEREPI2C='1' where INTEREPI2C='Y';
UPDATE cy_diag3 SET INTEREPI2C='0' where INTEREPI2C<>'1';
alter table cy_diag3 alter column INTEREPI2C bit null;
UPDATE cy_diag3 SET INTEREPI2C=0 where INTEREPI2C IS NULL;

UPDATE cy_diag3 SET INTEREPI3='1' where INTEREPI3='Y';
UPDATE cy_diag3 SET INTEREPI3='0' where INTEREPI3<>'1';
alter table cy_diag3 alter column INTEREPI3 bit null;
UPDATE cy_diag3 SET INTEREPI3=0 where INTEREPI3 IS NULL;

UPDATE cy_diag3 SET INTEREPI4='1' where INTEREPI4='Y';
UPDATE cy_diag3 SET INTEREPI4='0' where INTEREPI4<>'1';
alter table cy_diag3 alter column INTEREPI4 bit null;
UPDATE cy_diag3 SET INTEREPI4=0 where INTEREPI4 IS NULL;

UPDATE cy_diag3 SET INTEREPI4A='1' where INTEREPI4A='Y';
UPDATE cy_diag3 SET INTEREPI4A='0' where INTEREPI4A<>'1';
alter table cy_diag3 alter column INTEREPI4A bit null;
UPDATE cy_diag3 SET INTEREPI4A=0 where INTEREPI4A IS NULL;

UPDATE cy_diag3 SET INTEREPI4B='1' where INTEREPI4B='Y';
UPDATE cy_diag3 SET INTEREPI4B='0' where INTEREPI4B<>'1';
alter table cy_diag3 alter column INTEREPI4B bit null;
UPDATE cy_diag3 SET INTEREPI4B=0 where INTEREPI4B IS NULL;

UPDATE cy_diag3 SET INTEREPI4C='1' where INTEREPI4C='Y';
UPDATE cy_diag3 SET INTEREPI4C='0' where INTEREPI4C<>'1';
alter table cy_diag3 alter column INTEREPI4C bit null;
UPDATE cy_diag3 SET INTEREPI4C=0 where INTEREPI4C IS NULL;

UPDATE cy_diag3 SET INTEREPI5='1' where INTEREPI5='Y';
UPDATE cy_diag3 SET INTEREPI5='0' where INTEREPI5<>'1';
alter table cy_diag3 alter column INTEREPI5 bit null;
UPDATE cy_diag3 SET INTEREPI5=0 where INTEREPI5 IS NULL;

UPDATE cy_diag3 SET INTEREPI5A='1' where INTEREPI5A='Y';
UPDATE cy_diag3 SET INTEREPI5A='0' where INTEREPI5A<>'1';
alter table cy_diag3 alter column INTEREPI5A bit null;
UPDATE cy_diag3 SET INTEREPI5A=0 where INTEREPI5A IS NULL;

UPDATE cy_diag3 SET INTEREPI5B='1' where INTEREPI5B='Y';
UPDATE cy_diag3 SET INTEREPI5B='0' where INTEREPI5B<>'1';
alter table cy_diag3 alter column INTEREPI5B bit null;
UPDATE cy_diag3 SET INTEREPI5B=0 where INTEREPI5B IS NULL;

UPDATE cy_diag3 SET INTEREPI5C='1' where INTEREPI5C='Y';
UPDATE cy_diag3 SET INTEREPI5C='0' where INTEREPI5C<>'1';
alter table cy_diag3 alter column INTEREPI5C bit null;
UPDATE cy_diag3 SET INTEREPI5C=0 where INTEREPI5C IS NULL;

UPDATE cy_diag3 SET INTEREPI5D='1' where INTEREPI5D='Y';
UPDATE cy_diag3 SET INTEREPI5D='0' where INTEREPI5D<>'1';
alter table cy_diag3 alter column INTEREPI5D bit null;
UPDATE cy_diag3 SET INTEREPI5D=0 where INTEREPI5D IS NULL;

UPDATE cy_diag3 SET INTEREPI6='1' where INTEREPI6='Y';
UPDATE cy_diag3 SET INTEREPI6='0' where INTEREPI6<>'1';
alter table cy_diag3 alter column INTEREPI6 bit null;
UPDATE cy_diag3 SET INTEREPI6=0 where INTEREPI6 IS NULL;

UPDATE cy_diag3 SET HPV_DNA='1' where HPV_DNA='Y';
UPDATE cy_diag3 SET HPV_DNA='0' where HPV_DNA<>'1';
alter table cy_diag3 alter column HPV_DNA bit null;
UPDATE cy_diag3 SET HPV_DNA=0 where HPV_DNA IS NULL;

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='cy_diag3')
BEGIN
ALTER TABLE cy_diag3 ADD [id] [int] IDENTITY(1,1) NOT NULL;
ALTER TABLE cy_diag3 ADD CONSTRAINT [PK_cy_diag3] primary key (ID);
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAG3')
BEGIN
ALTER TABLE cy_diag3 ADD [DIAG3] [nvarchar](255) NULL;
END

IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='DIAG3_DESC')
BEGIN
ALTER TABLE cy_diag3 ADD [DIAG3_DESC] [nvarchar](255) NULL;
END


IF NOT EXISTS(SELECT a.name FROM syscolumns a,sysobjects b WHERE a.id=b.id AND LTRIM(a.name) = 'id' AND LTRIM(b.name)='reportContent')
BEGIN
ALTER TABLE cy_diag3 ADD [reportContent] [nvarchar](max) NULL;
END


--findingCommentsReport table
IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[findingCommentsReport]') AND type in (N'U'))
CREATE TABLE [dbo].[findingCommentsReport](
	[key] [nvarchar](255) NULL,
	[description] [nvarchar](1000) NULL,
	[UPDATE_BY] [nvarchar](255) NULL,
	[UPDATE_AT] [datetime] NULL,
	[UPDATE_CTR] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_findingCommentsReport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
