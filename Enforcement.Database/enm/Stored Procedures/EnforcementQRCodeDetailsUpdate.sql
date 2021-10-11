      
-- =============================================      
-- Author:  <Author, Vishnu vasudevan>      
-- Create date: <Create Date, 08-08-2021>      
-- Description: <Description, enm.EnforcementQRCodeDetailsUpdate>      
-- =============================================      
CREATE PROCEDURE enm.EnforcementQRCodeDetailsUpdate      
 @EnforcementID INT,      
 @QRCodeID VARCHAR(600)  
AS      
BEGIN      
 UPDATE      
 enm.EnforcementDetails SET      
 QRCodeID = @QRCodeID,          
 modifiedDate = GETDATE()      
 WHERE EnforcementID = @EnforcementID      
END