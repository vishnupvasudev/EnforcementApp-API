  
-- =============================================  
-- Author:  Vishnu Vasudevan
-- Create date: 06 Aug 2021
-- Description: Insert users  
-- =============================================  
CREATE PROCEDURE [enm].[UserInsert]  
@Name varchar(500),   
@Password nvarchar(50)=null,  
@EmailID nvarchar(50),   
@PhoneNumber varchar(50)=null  
AS  
BEGIN  
  
 DECLARE @UserID BIGINT = NULL  
   
 SELECT @UserID = UserID FROM enm.[AppUser] WHERE EmailID = @EmailID  
   
 IF(ISNULL(@UserID,0)=0)  
 BEGIN  
   
  INSERT INTO enm.[AppUser]  
             ([Name]  
             ,[Password]  
             ,[EmailID]  
             ,[PhoneNumber]  
             ,[CreatedDate]  
			,IsActive)  
			VALUES  
             (@Name,  
			 @Password,  
			 @EmailID ,   
			 @PhoneNumber,   
			 GETDATE() ,  
			 1)  
    
  SELECT @@IDENTITY AS UserID  
 END  
 ELSE  
 BEGIN  
  SELECT -1 AS UserID --User already exists  
 END  
END