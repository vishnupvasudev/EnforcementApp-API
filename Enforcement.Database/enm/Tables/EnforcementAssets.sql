CREATE TABLE [enm].[EnforcementAssets] (
    [AssetID]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [EnforcementID]  INT           NOT NULL,
    [StoredFileName] VARCHAR (150) NOT NULL,
    [ActualFileName] VARCHAR (150) NOT NULL,
    [CreatedBy]      BIGINT        NOT NULL,
    [CreatedDate]    DATETIME      NOT NULL,
    CONSTRAINT [PK_EnforcementAssets] PRIMARY KEY CLUSTERED ([AssetID] ASC),
    CONSTRAINT [FK_EnforcementAssets_Enforcement_EnforcementID] FOREIGN KEY ([EnforcementID]) REFERENCES [enm].[EnforcementDetails] ([EnforcementID]),
    CONSTRAINT [FK_EnforcementAssets_User_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [enm].[AppUser] ([UserID])
);



