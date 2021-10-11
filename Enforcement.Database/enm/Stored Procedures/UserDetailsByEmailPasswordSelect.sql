-- =============================================  
-- Author:  Vishnu Vasudevan 
-- Create date: 08 Aug 2021 
-- Description: usr.UserDetailsByEmailPasswordSelect  
-- =============================================  
CREATE PROCEDURE [enm].[UserDetailsByEmailPasswordSelect] 
 @UserName VARCHAR(50),  
 @Password NVARCHAR(100)  
AS  
BEGIN  
 SELECT UserID,  
     [Name],  
     [Password],  
     [EmailID],   
     [PhoneNumber],
	 IsActive
  FROM enm.[AppUser]  
  WHERE EmailID = @UserName  
  AND [Password] = @Password  
END