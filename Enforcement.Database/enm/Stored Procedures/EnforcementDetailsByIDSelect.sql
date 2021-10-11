  
-- =============================================  
-- Author:  <Author, Vishnu Vasudevan>  
-- Create date: <Create Date, 10-08-2021>  
-- Description: <Description, enm.EnforcementDetailsByIDSelect>  
-- =============================================  
CREATE PROCEDURE [enm].[EnforcementDetailsByIDSelect]   
 @EnforcementID INT  
AS  
BEGIN  
 SELECT EnforcementID,  
 Title,  
 CaseID,  
 null CaseTitle,  
 null CaseNumber,  
 Description,  
 QRCodeID  
 FROM enm.EnforcementDetails  
 WHERE EnforcementID = @EnforcementID  
END