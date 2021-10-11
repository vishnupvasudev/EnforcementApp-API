#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.Enforcement
{
    #region QRCodeModel
    /// <summary>
    /// QRCodeModel
    /// </summary>
    public class QRCodeModel
    {
        /// <summary>
        /// code
        /// </summary>
        public string Qrcode { get; set; }

        /// <summary>
        /// CodeID
        /// </summary>
        public string QrCodeID { get; set; }
    }
    #endregion QRCodeModel
}
