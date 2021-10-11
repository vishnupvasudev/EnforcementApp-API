#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.Enforcement
{
    #region CaseModel
    /// <summary>
    /// CaseModel
    /// </summary>
    public class CaseModel
    {
        /// <summary>
        /// CaseID
        /// </summary>
        public long CaseID { get; set; }

        /// <summary>
        /// CaseNumber
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// CaseTitle
        /// </summary>
        public string CaseTitle { get; set; }
    }
    #endregion CaseModel
}
