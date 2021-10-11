#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.Enforcement
{
    #region EnforcementReturnModel
    /// <summary>
    /// EnforcementReturnModel
    /// </summary>
    public class EnforcementReturnModel
    {
        /// <summary>
        /// ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// CaseNumber
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// CaseID
        /// </summary>
        public long CaseID { get; set; }

        /// <summary>
        /// CaseTitle
        /// </summary>
        public string CaseTitle { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Images
        /// </summary>
        public List<ItemImageModel> Images { get; set; } = new List<ItemImageModel>();
    }
    #endregion EnforcementReturnModel
}
