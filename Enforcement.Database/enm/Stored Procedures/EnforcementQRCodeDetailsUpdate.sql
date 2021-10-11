  
-- =============================================  
-- Author:  <Author, Vishnu vasudevan>  
-- Create date: <Create Date, 08-08-2021>  
-- Description: <Description, enm.EnforcementQRCodeDetailsUpdate>  
-- =============================================  
CREATE PROCEDURE enm.EnforcementQRCodeDetailsUpdate  
 @EnforcementID INT,  
 @QRCodeID VARCHAR(200),  
 @ModifiedBy BIGINT  
AS  
BEGIN  
 UPDATE  
 enm.EnforcementDetails SET  
 QRCodeID = @QRCodeID,  
 ModifiedBy = @ModifiedBy,  
 modifiedDate = GETDATE()  
 WHERE EnforcementID = @EnforcementID  
END