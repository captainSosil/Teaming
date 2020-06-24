/*
teamingTest의 배포 스크립트

이 코드는 도구를 사용하여 생성되었습니다.
파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
변경 내용이 손실됩니다.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "teamingTest"
:setvar DefaultFilePrefix "teamingTest"
:setvar DefaultDataPath "C:\Users\김태환\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\김태환\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
SQLCMD 모드가 지원되지 않으면 SQLCMD 모드를 검색하고 스크립트를 실행하지 않습니다.
SQLCMD 모드를 설정한 후에 이 스크립트를 다시 사용하려면 다음을 실행합니다.
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'이 스크립트를 실행하려면 SQLCMD 모드를 사용하도록 설정해야 합니다.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'$(DatabaseName)을(를) 만드는 중...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'데이터베이스 설정을 수정할 수 없습니다. 이러한 설정을 적용하려면 SysAdmin이어야 합니다.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'데이터베이스 설정을 수정할 수 없습니다. 이러한 설정을 적용하려면 SysAdmin이어야 합니다.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = AUTO, OPERATION_MODE = READ_WRITE, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'[dbo].[Answers]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Answers] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (25)  NOT NULL,
    [PostDate]     DATETIME       NOT NULL,
    [PostIp]       NVARCHAR (15)  NULL,
    [Title]        NVARCHAR (150) NOT NULL,
    [Content]      NVARCHAR (MAX) NOT NULL,
    [Category]     NVARCHAR (20)  NULL,
    [Email]        NVARCHAR (100) NULL,
    [Password]     NVARCHAR (255) NULL,
    [ReadCount]    INT            NULL,
    [Encoding]     NVARCHAR (20)  NOT NULL,
    [Homepage]     NVARCHAR (100) NULL,
    [ModifyDate]   DATETIME       NULL,
    [ModifyIp]     NVARCHAR (15)  NULL,
    [CommentCount] INT            NULL,
    [FileName]     NVARCHAR (255) NULL,
    [FileSize]     INT            NULL,
    [DownCount]    INT            NULL,
    [Ref]          INT            NOT NULL,
    [Step]         INT            NULL,
    [RefOrder]     INT            NULL,
    [AnswerNum]    INT            NULL,
    [ParentNum]    INT            NULL,
    [Num]          INT            NULL,
    [UID]          INT            NULL,
    [UserId]       INT            NULL,
    [UserName]     NVARCHAR (25)  NULL,
    [DivisionId]   INT            NULL,
    [CategoryId]   INT            NULL,
    [BoardId]      INT            NULL,
    [AplicationId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[AnswersComments]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[AnswersComments] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [ArticleId]    INT             NOT NULL,
    [Name]         NVARCHAR (25)   NOT NULL,
    [PostDate]     DATETIME        NOT NULL,
    [PostIp]       NVARCHAR (15)   NULL,
    [Title]        NVARCHAR (150)  NULL,
    [Content]      NVARCHAR (MAX)  NULL,
    [Category]     NVARCHAR (20)   NULL,
    [Opinion]      NVARCHAR (4000) NULL,
    [BoardName]    NVARCHAR (50)   NULL,
    [Password]     NVARCHAR (255)  NOT NULL,
    [Num]          INT             NULL,
    [UserId]       INT             NULL,
    [CategoryId]   INT             NULL,
    [BoardId]      INT             NULL,
    [AplicationId] INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT GetDate() FOR [PostDate];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT ('Free') FOR [Category];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [ReadCount];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [CommentCount];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [FileSize];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [DownCount];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [Step];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [RefOrder];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [AnswerNum];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [ParentNum];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [DivisionId];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [CategoryId];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [BoardId];


GO
PRINT N'[dbo].[Answers]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Answers]
    ADD DEFAULT 0 FOR [AplicationId];


GO
PRINT N'[dbo].[AnswersComments]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AnswersComments]
    ADD DEFAULT GetDate() FOR [PostDate];


GO
PRINT N'[dbo].[AnswersComments]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AnswersComments]
    ADD DEFAULT ('Free') FOR [Category];


GO
PRINT N'[dbo].[AnswersComments]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AnswersComments]
    ADD DEFAULT 0 FOR [CategoryId];


GO
PRINT N'[dbo].[AnswersComments]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AnswersComments]
    ADD DEFAULT 0 FOR [BoardId];


GO
PRINT N'[dbo].[AnswersComments]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[AnswersComments]
    ADD DEFAULT 0 FOR [AplicationId];


GO
PRINT N'[dbo].[AnswersCount]을(를) 만드는 중...';


GO
-- 특정 아티클 테이블의 전체 레코드 수 반환
CREATE PROCEDURE [dbo].[AnswersCount]
AS
	Select Count(*) From Answers
GO
PRINT N'[dbo].[AnswersDelete]을(를) 만드는 중...';


GO
-- 해당 글을 지우는 저장 프로시저(답변글이 있으면 업데이트하고 없으면 지운다.)
CREATE PROCEDURE [dbo].[AnswersDelete]
    @Id Int,				-- 일련번호
    @Password NVarChar(255) -- 암호 매개변수
AS
    --[A] 등록한 암호가 맞는지 확인
    Declare @cnt Int
    Select @cnt = Count(*) From Answers Where Id = @Id And Password = @Password

    If @cnt = 0
    Begin
        Return 0 -- 번호와 암호가 맞는게 없으면 0을 반환
    End	

    --[B] 등록한 암호가 맞으면 삭제 진행
    Declare @Ref Int
    Declare @RefOrder Int
    Declare @AnswerNum Int
    Declare @ParentNum Int

	--[a] 삭제하려는 글의 정보 읽어오기 
    Select
        @AnswerNum = AnswerNum,     @RefOrder = RefOrder,
        @Ref = Ref,                 @ParentNum = ParentNum
    From Answers
    Where Id = @Id

    If @AnswerNum = 0
    Begin
        --[b] 답변 글이 없으면 바로 삭제
        If @RefOrder > 0 
        Begin
            UPDATE Answers SET RefOrder = RefOrder - 1 WHERE Ref = @Ref AND RefOrder > @RefOrder
            UPDATE Answers SET AnswerNum = AnswerNum - 1 WHERE Id = @ParentNum
        End
        Delete Answers Where Id = @Id
        Delete Answers WHERE Id = @ParentNum AND ModifyIp = N'((DELETED))' AND AnswerNum = 0	
    End
	Else
	Begin
        --[c] 답변 글이 있으면 삭제하지 않고 내용만 Null 값으로 업데이트
        Update Answers 
        Set 
            Name = N'(Unknown)', Email = '', Password = '',
            Title = N'(삭제된 글입니다.)', 
            Content = N'(삭제된 글입니다. ' 
            + N'현재 답변이 포함되어 있기 때문에 내용만 삭제되었습니다.)',
            ModifyIp = N'((DELETED))', FileName = '', 
            FileSize = 0, CommentCount = 0
        Where Id = @Id  
	End
GO
PRINT N'[dbo].[AnswersDetails]을(를) 만드는 중...';


GO
-- 해당 아티클을 세부적으로 읽어오는 저장 프로시저
CREATE PROCEDURE [dbo].[AnswersDetails]
    @Id Int
As
    --[A] 조회수 카운트 1증가
    Update Answers Set ReadCount = ReadCount + 1 Where Id = @Id
    
    --[B] 모든 항목 조회
    Select * From Answers Where Id = @Id
GO
PRINT N'[dbo].[AnswersList]을(를) 만드는 중...';


GO
-- 전체 데이터 조회(게시판 리스트)
CREATE PROCEDURE [dbo].[AnswersList]
    @PageNumber Int = 1,
    @PageSize Int = 10
AS
    Select 
        [Id], 
        [Name], 
		[Email], 
        [PostDate], 
        [PostIp], 
        [Title], 
        [Category], 
        [ReadCount], 
        [FileName], 
        [FileSize], 
        [DownCount], 
        [CommentCount], 
        [Step]
    From Answers
    Order By Ref Desc, RefOrder Asc
    Offset ((@PageNumber - 1) * @PageSize) Rows Fetch Next @PageSize Rows Only;
GO
PRINT N'[dbo].[AnswersModify]을(를) 만드는 중...';


GO
-- 해당 아티클을 수정하는 저장 프로시저: 수정이 완료되면 1을 그렇지 않으면 0을 반환 
CREATE PROCEDURE [dbo].[AnswersModify]
    @Name       NVarChar(25), 
    @ModifyIp   NVarChar(15), 
    @Title      NVarChar(150), 
    @Content    NVarChar(Max),
	@Category	NVarChar(50), 

    @Email      NVarChar(100), 
    @Password   NVarChar(255), 
    @Encoding   NVarChar(10), 
    @Homepage   NVarChar(100),
    @FileName	NVarChar(255),
    @FileSize	Int,    
    @Id Int
As
	-- 번호와 암호가 맞으면 수정을 진행 
    Declare @cnt Int
    Select @cnt = Count(*) From Answers Where Id = @Id And Password = @Password

    If @cnt > 0 -- 번호와 암호가 맞는게 있다면...
    Begin
        Update Answers 
        Set 
            Name = @Name,					Email = @Email, 
            Title = @Title,					ModifyIp = @ModifyIp, 
            ModifyDate = GetDate(),			Content = @Content, 
            Encoding = @Encoding,			Homepage = @Homepage, 
            FileName = @FileName,			FileSize = @FileSize
        Where Id = @Id

        Select '1'
    End
    Else
	Begin
        Select '0'
	End
GO
PRINT N'[dbo].[AnswersReply]을(를) 만드는 중...';


GO
-- 게시판 아티클에 답변 저장 
CREATE PROCEDURE [dbo].[AnswersReply]
    @Name       NVarChar(25), 
    @PostIp     NVarChar(15), 
    @Title      NVarChar(150), 
    @Content    NVarChar(Max), 
    @Category   NVarChar(10) = '', 

    @Email      NVarChar(100), 
    @Password   NVarChar(255), 
    @Encoding   NVarChar(10), 
    @Homepage   NVarChar(100),
    @ParentNum  Int,                    -- 부모글의 고유번호(Id)
    @FileName   NVarChar(255),
    @FileSize   Int
AS
    --[0] 변수 선언
    Declare @MaxRefOrder Int
    Declare @MaxRefAnswerNum Int
    Declare @ParentRef Int
    Declare @ParentStep Int
    Declare @ParentRefOrder Int

    --[1] 부모글의 답변수(AnswerNum)를 1증가
    Update Answers Set AnswerNum = AnswerNum + 1 Where Id = @ParentNum 

    --[2] 같은 글에 대해서 답변을 두 번 이상하면 먼저 답변한 게 위에 나타나게 한다.
    Select @MaxRefOrder = RefOrder, @MaxRefAnswerNum = AnswerNum From Answers 
    Where 
        ParentNum = @ParentNum And 
        RefOrder = (Select Max(RefOrder) From Answers Where ParentNum = @ParentNum)

    If @MaxRefOrder Is Null
    Begin
        Select @MaxRefOrder = RefOrder From Answers Where Id = @ParentNum
        Set @MaxRefAnswerNum = 0  
    End 

    --[3] 중간에 답변달 때(비집고 들어갈 자리 마련)
    Select @ParentRef = Ref, @ParentStep = Step  From Answers Where Id = @ParentNum

    Update Answers Set RefOrder = RefOrder + 1  
	Where Ref = @ParentRef And RefOrder > (@MaxRefOrder + @MaxRefAnswerNum)

    --[4] 최종저장
    Insert Answers
    (
        Name, Email, Title, PostIp, Content, Password, Encoding, 
        Homepage, Ref, Step, RefOrder, ParentNum, FileName, FileSize,
        Category
    )
    Values
    (
        @Name, @Email, @Title, @PostIp, @Content, @Password, @Encoding, 
        @Homepage, @ParentRef, @ParentStep + 1, 
        @MaxRefOrder + @MaxRefAnswerNum + 1, @ParentNum, @FileName, @FileSize,
        @Category
    )
GO
PRINT N'[dbo].[AnswersSearchCount]을(를) 만드는 중...';


GO
-- 게시판 아티클의 검색 결과의 레코드 수 반환
CREATE PROCEDURE [dbo].[AnswersSearchCount]
    @SearchField NVarChar(25),
    @SearchQuery NVarChar(25)
AS
    Set @SearchQuery = '%' + @SearchQuery + '%'

    Select Count(*)
    From Answers
    Where
    (
        Case @SearchField 
            When 'Name' Then [Name]
            When 'Title' Then [Title]
            When 'Content' Then [Content]
            Else @SearchQuery
        End
    ) 
    Like 
    @SearchQuery
GO
PRINT N'[dbo].[AnswersSearchList]을(를) 만드는 중...';


GO
-- 게시판 아티클에서 데이터 검색 리스트 
CREATE PROCEDURE [dbo].[AnswersSearchList]
    @SearchField NVarChar(25),
    @SearchQuery NVarChar(25),
    @PageNumber Int = 1,
    @PageSize Int = 10
AS
    Select 
        [Id], 
		[Name], 
		[Email], 
		[Title], 
		[Category], 
		[PostDate],
        [ReadCount], [Ref], [Step], [RefOrder], [AnswerNum], 
        [ParentNum], [CommentCount], [FileName], [FileSize], 
        [DownCount]
    From Answers
    Where ( 
        Case @SearchField 
            When 'Name' Then [Name] 
            When 'Title' Then Title 
            When 'Content' Then Content 
            Else 
            @SearchQuery 
        End 
    ) Like '%' + @SearchQuery + '%'
    Order By Ref Desc, RefOrder Asc
    Offset ((@PageNumber - 1) * @PageSize) Rows Fetch Next @PageSize Rows Only;
GO
PRINT N'[dbo].[AnswersWrite]을(를) 만드는 중...';


GO
-- 게시판 아티클 데이터 저장 
CREATE PROCEDURE [dbo].[AnswersWrite]
	-- 5W1H
    @Name       NVarChar(25), 
    @PostIp     NVarChar(15), 
    @Title      NVarChar(150), 
    @Content    NVarChar(Max), 
	@Category   NVarChar(10), 

    @Email      NVarChar(100), 
    @Password   NVarChar(255), 
    @Encoding   NVarChar(10), 
    @Homepage   NVarChar(100),
    @FileName   NVarChar(255),
    @FileSize   Int
AS
    --[A] Ref 열에 일련번호 생성(현재 저장된 Ref 중 가장 큰 값에 1을 더해서 증가) 및 그룹화
    Declare @MaxRef Int
    Select @MaxRef = Max(IsNull(Ref, 0)) From Answers 
 
    If @MaxRef Is Null
        Set @MaxRef = 1 -- 테이블 생성 후 처음만 비교
    Else
        Set @MaxRef = @MaxRef + 1

	--[B] 만들어진 데이터를 저장하기 
    Insert Answers
    (
        Name, Email, Title, PostIp, Content, Category,  
        Password, Encoding, Homepage, Ref, FileName, FileSize
    )
    Values
    (
        @Name, @Email, @Title, @PostIp, @Content, @Category, 
        @Password, @Encoding, @Homepage, @MaxRef, @FileName, @FileSize
    )
GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'업데이트가 완료되었습니다.';


GO
