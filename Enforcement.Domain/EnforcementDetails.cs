#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace Enforcement.Domain
{
    #region Enforcement
    /// <summary>
    /// Enforcement
    /// </summary>
    public class EnforcementDetails
    {
        /// <summary>
        /// EnforcementID
        /// </summary>
        public int EnforcementID { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// CaseNumber
        /// </summary>
        public long CaseID { get; set; }

        /// <summary>
        /// CaseTitle
        /// </summary>
        public string CaseTitle { get; set; }

        /// <summary>
        /// CaseNumber
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// QRCodeGUID
        /// </summary>
        public string QRCodeID { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }
    }
    #endregion Enforcement
}
