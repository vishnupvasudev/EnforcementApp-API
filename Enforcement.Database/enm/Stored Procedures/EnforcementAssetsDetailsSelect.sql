
-- =============================================
-- Author:		<Author, Vishnu Vasudevan>
-- Create date: <Create Date, 08-Aug-2021>
-- Description:	<Description, enm.EnforcementAssetsDetailsSelect>
-- =============================================
CREATE PROCEDURE enm.EnforcementAssetsDetailsSelect 
	@EnforcementID INT
AS
BEGIN
	SELECT AssetID,
	EnforcementID,
	StoredFileName,
	ActualFileName
	FROM [enm].[EnforcementAssets]
	WHERE EnforcementID = @EnforcementID
END