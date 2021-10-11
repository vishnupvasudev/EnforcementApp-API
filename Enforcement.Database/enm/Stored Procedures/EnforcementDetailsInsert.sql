  
-- =============================================  
-- Author:  <Author, Vishnu vasudevan>  
-- Create date: <Create Date, 08-08-2021>  
-- Description: <Description, enm.EnforcementDetailsInsert>  
-- =============================================  
CREATE PROCEDURE [enm].[EnforcementDetailsInsert]  
 @Title VARCHAR(300),  
 @CaseID BIGINT,  
 @Description VARCHAR(500),  
 @CreatedBy BIGINT  
AS  
BEGIN  
 INSERT INTO   
 enm.EnforcementDetails (  
 Title,  
 CaseID,  
 [Description],  
 CreatedDate   
 ) VALUES  
 (  
 @Title,  
 @CaseID,  
 @Description,  
 GETDATE() 
 )  
  
 SELECT SCOPE_IDENTITY() AS EnforcementID  
END