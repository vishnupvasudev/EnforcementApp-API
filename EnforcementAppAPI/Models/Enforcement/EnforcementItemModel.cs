#region Included Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.Enforcement
{
    #region EnforcementItemModel
    /// <summary>
    /// EnforcementItemModel
    /// </summary>
    public class EnforcementItemModel
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string ItemName { get; set; }

        /// <summary>
        /// CaseNumber
        /// </summary>
        [Required]
        public long CaseID { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// AssetFiles
        /// </summary>
        [Required]
        public List<IFormFile> Images { get; set; }
    }
    #endregion EnforcementItemModel
}
