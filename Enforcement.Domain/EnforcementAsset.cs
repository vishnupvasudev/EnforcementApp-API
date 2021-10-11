#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace Enforcement.Domain
{
    #region EnforcementAsset
    /// <summary>
    /// EnforcementAsset
    /// </summary>
    public class EnforcementAsset
    {
        /// <summary>
        /// AssetID
        /// </summary>
        public long AssetID { get; set; }

        /// <summary>
        /// EnforcementID
        /// </summary>
        public long EnforcementID { get; set; }

        /// <summary>
        /// StoredFileName
        /// </summary>
        public string StoredFileName { get; set; }

        /// <summary>
        /// ActualFileName
        /// </summary>
        public string ActualFileName { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }
    }
    #endregion EnforcementAsset
}
