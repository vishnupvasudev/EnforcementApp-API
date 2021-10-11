#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Enforcement.BLL.Interface.Enforcement;
using Enforcement.DAL;
#endregion Included Namespaces

namespace Enforcement.BLL.Implementation.Enforcement
{
    #region EnforcementBLL
    /// <summary>
    /// EnforcementBLL
    /// </summary>
    public class EnforcementBLL : IEnforcement
    {
        #region Private members

        /// <summary>
        /// IRepository
        /// </summary>
        private readonly IRepository _iRepository;

        #endregion Private members

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iRepository"></param>
        public EnforcementBLL(IRepository iRepository)
        {
            this._iRepository = iRepository;
        }
        #endregion Constructor

        #region AddEnforcementdetails
        /// <summary>
        /// AddEnforcementDetails
        /// </summary>
        /// <param name="enforcement"></param>
        /// <returns></returns>
        public long AddEnforcementdetails(Domain.EnforcementDetails enforcement)
        {
            DataAccessParameters objParam = new DataAccessParameters();

            if (enforcement != null)
            {
                objParam.Add("@Title", enforcement.Title.Trim());
                objParam.Add("@CaseID", enforcement.CaseID);
                objParam.Add("@Description", enforcement.Description.Trim());
                objParam.Add("@CreatedBy", enforcement.CreatedBy);
            }

            return this._iRepository.AddAndReturnPrimaryKey("enm.EnforcementDetailsInsert", objParam);
        }
        #endregion AddEnforcementdetails

        #region UpdateEnforcementQRDetails
        /// <summary>
        /// UpdateEnforcementQRDetails
        /// </summary>
        /// <param name="EnforcementID"></param>
        /// <param name="QRCodeID"></param>
        /// <returns></returns>
        public bool UpdateEnforcementQRDetails(long EnforcementID, string QRCodeID)
        {
            DataAccessParameters objParam = new DataAccessParameters();

            if (EnforcementID > 0)
            {
                objParam.Add("@EnforcementID", EnforcementID);
                objParam.Add("@QRCodeID", QRCodeID);

                return this._iRepository.Update("enm.EnforcementQRCodeDetailsUpdate", objParam);
            }
            else
            {
                return false;
            }
        }
        #endregion UpdateEnforcementQRDetails

        #region AddEnforcementAssets
        /// <summary>
        /// AddEnforcementAssets
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        public bool AddEnforcementAssets(List<Domain.EnforcementAsset> assets)
        {
            DataAccessParameters objParam = new DataAccessParameters();
            if (assets != null)
            {
                objParam.Add("@EnforcementAssets", JsonSerializer.Serialize<List<Domain.EnforcementAsset>>(assets));
            }

            return this._iRepository.AddAndReturnPrimaryKey("enm.EnforcementAssetsDetailsInsert", objParam) > 0;
        }
        #endregion AddEnforcementAssets

        #region UpdateEnforcementQRDetails
        /// <summary>
        /// UpdateEnforcementQRDetails
        /// </summary>
        /// <param name="EnforcementID"></param>
        /// <returns></returns>
        public List<Domain.EnforcementAsset> SelectEnforcementAssetByID(int EnforcementID)
        {
            DataAccessParameters objParam = new DataAccessParameters();

            if (EnforcementID > 0)
            {
                objParam.Add("@EnforcementID", EnforcementID);
            }

            return this._iRepository.SelectQuery<Domain.EnforcementAsset>("enm.EnforcementAssetsDetailsSelect", objParam);
        }
        #endregion UpdateEnforcementQRDetails

        #region SelectEnforcementDetailsByID
        /// <summary>
        /// SelectEnforcementDetailsByID
        /// </summary>
        /// <param name="EnforcementID"></param>
        /// <returns></returns>
        public Domain.EnforcementDetails SelectEnforcementDetailsByID(int EnforcementID)
        {
            DataAccessParameters objParam = new DataAccessParameters();

            if (EnforcementID > 0)
            {
                objParam.Add("@EnforcementID", EnforcementID);
            }

            return this._iRepository.SelectQuery<Domain.EnforcementDetails>("enm.EnforcementDetailsByIDSelect", objParam).FirstOrDefault();
        }
        #endregion SelectEnforcementDetailsByID

        #region SelectAllCases
        /// <summary>
        /// SelectAllCases
        /// </summary>
        /// <returns></returns>
        public List<Domain.Case> SelectAllCases()
        {
            DataAccessParameters objParam = new DataAccessParameters();

            return this._iRepository.SelectQuery<Domain.Case>("enm.CaseAllDetailsSelect", objParam);
        }
        #endregion SelectAllCases
    }
    #endregion EnforcementBLL
}
