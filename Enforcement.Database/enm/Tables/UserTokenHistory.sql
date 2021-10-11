CREATE TABLE [enm].[UserTokenHistory] (
    [UserTokenHistoryID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [AccessToken]        NVARCHAR (800) NULL,
    [UserID]             BIGINT         NULL,
    [CreatedDate]        DATETIME       NULL,
    CONSTRAINT [PK_UserTokenHistory_1] PRIMARY KEY CLUSTERED ([UserTokenHistoryID] ASC)
);

