CREATE TABLE [enm].[EnforcementDetails] (
    [EnforcementID] INT           IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (150) NOT NULL,
    [CaseID]        BIGINT        NULL,
    [Description]   VARCHAR (300) NULL,
    [QRCodeID]      VARCHAR (60)  NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [CreatedBy]     BIGINT        NOT NULL,
    [ModifiedDate]  DATETIME      NULL,
    [ModifiedBy]    BIGINT        NULL,
    CONSTRAINT [PK_EnforcementDetails] PRIMARY KEY CLUSTERED ([EnforcementID] ASC),
    CONSTRAINT [FK_EnforcementDetails_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [enm].[AppUser] ([UserID]),
    CONSTRAINT [FK_EnforcementDetails_User_ModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES [enm].[AppUser] ([UserID])
);



