CREATE TABLE [enm].[EnforcementDetails] (
    [EnforcementID] INT           IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (150) NOT NULL,
    [CaseID]        BIGINT        NULL,
    [Description]   VARCHAR (300) NULL,
    [QRCodeID]      VARCHAR (600) NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [ModifiedDate]  DATETIME      NULL,
    CONSTRAINT [PK_EnforcementDetails] PRIMARY KEY CLUSTERED ([EnforcementID] ASC)
);





