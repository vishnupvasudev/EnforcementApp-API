#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace Enforcement.BLL.Interface.Enforcement
{
    #region IEnforcement
    /// <summary>
    /// IEnforcement
    /// </summary>
    public interface IEnforcement
    {
        /// <summary>
        /// AddEnforcementDetails
        /// </summary>
        /// <param name="enforcement"></param>
        /// <returns></returns>
        long AddEnforcementdetails(Domain.EnforcementDetails enforcement);

        /// <summary>
        /// UpdateEnforcementQRDetails
        /// </summary>
        /// <param name="EnforcementID"></param>
        /// <param name="QRCodeID"></param>
        /// <returns></returns>
        bool UpdateEnforcementQRDetails(long EnforcementID, string QRCodeID);

        /// <summary>
        /// AddEnforcementAssets
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        bool AddEnforcementAssets(List<Domain.EnforcementAsset> assets);

        /// <summary>
        /// SelectEnforcementAssetByID
        /// </summary>
        /// <param name="EnforcementID"></param>
        /// <returns></returns>
        List<Domain.EnforcementAsset> SelectEnforcementAssetByID(int EnforcementID);

        /// <summary>
        /// SelectEnforcementDetailsByID
        /// </summary>
        /// <param name="EnforcementID"></param>
        /// <returns></returns>
        Domain.EnforcementDetails SelectEnforcementDetailsByID(int EnforcementID);

        /// <summary>
        /// SelectAllCases
        /// </summary>
        /// <returns></returns>
        List<Domain.Case> SelectAllCases();
    }
    #endregion IEnforcement
}
