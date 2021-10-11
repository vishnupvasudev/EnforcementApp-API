    
-- =============================================    
-- Author:  Vishnu Vasudevan    
-- Create date: 06-08-2021  
-- Description: UserTokenInsert    
-- =============================================    
CREATE PROCEDURE [enm].[UserTokenInsert]    
@Token VARCHAR(MAX),    
@UserID BIGINT = NULL    
AS    
BEGIN    
 INSERT INTO [enm].[UserTokenHistory]    
            ([AccessToken]    
            ,[UserID]    
            ,[CreatedDate])    
 VALUES(@Token    
     ,@UserID    
     ,GETDATE())    
END