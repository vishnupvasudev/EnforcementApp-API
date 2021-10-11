
-- =============================================
-- Author:		<Author, Vishnu Vasudevan>
-- Create date: <Create Date, 08-Aug-2021>
-- Description:	<Description, EnforcementAssetsDetailsInsert>
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
  CreatedBy,
  CreatedDate
  ) SELECT      
   EnforcementID,          
   StoredFileName,      
   ActualFileName,      
   CreatedBy,
   GETDATE()
  FROM OPENJSON(@EnforcementAssets)      
  WITH (      
  EnforcementID INT,      
  StoredFileName VARCHAR(300),    
  ActualFileName VARCHAR(300),
  CreatedBy BIGINT 
  )      
    
  SELECT SCOPE_IDENTITY() AS AssetID 
END