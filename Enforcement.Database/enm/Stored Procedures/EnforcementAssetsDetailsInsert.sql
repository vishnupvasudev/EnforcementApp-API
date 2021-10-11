  
-- =============================================  
-- Author:  <Author, Vishnu Vasudevan>  
-- Create date: <Create Date, 08-Aug-2021>  
-- Description: <Description, EnforcementAssetsDetailsInsert>  
-- =============================================  
CREATE PROCEDURE enm.EnforcementAssetsDetailsInsert   
 @EnforcementAssets nvarchar(max)  
AS  
BEGIN  
 INSERT INTO         
  [enm].[EnforcementAssets](        
  EnforcementID,            
  StoredFileName,        
  ActualFileName,   
  CreatedDate  
  ) SELECT        
   EnforcementID,            
   StoredFileName,        
   ActualFileName,          
   GETDATE()  
  FROM OPENJSON(@EnforcementAssets)        
  WITH (        
  EnforcementID INT,        
  StoredFileName VARCHAR(300),      
  ActualFileName VARCHAR(300)  
  )        
      
  SELECT SCOPE_IDENTITY() AS AssetID   
END