#region Included namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included namespaces

namespace Enforcement.Domain.Common
{
    #region UploadPath
    /// <summary>
    /// UploadPath
    /// </summary>
    public class UploadPath
    {
        /// <summary>
        /// AssetImages
        /// </summary>
        public string AssetImages { get; set; }

        /// <summary>
        /// QRCodes.
        /// </summary>
        public string QRCodes { get; set; }
    }
    #endregion UploadPath
}
