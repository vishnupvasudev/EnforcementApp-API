CREATE TABLE [enm].[AppUser] (
    [UserID]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NULL,
    [Password]     NVARCHAR (50) NULL,
    [EmailID]      NVARCHAR (50) NULL,
    [PhoneNumber]  VARCHAR (20)  NULL,
    [CreatedBy]    BIGINT        NULL,
    [CreatedDate]  DATETIME      CONSTRAINT [DF_User_CreatedDate] DEFAULT (getdate()) NULL,
    [ModifiedBy]   BIGINT        NULL,
    [ModifiedDate] DATETIME      NULL,
    [IsActive]     BIT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

