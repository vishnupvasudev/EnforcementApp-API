#region Included Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Enforcement.Domain;
using Microsoft.AspNetCore.Http;
using Utilities;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.Enforcement
{
    #region EnforcementModel
    /// <summary>
    /// EnforcementModel
    /// </summary>
    public class EnforcementModel
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
        /// CreatedUserID
        /// </summary>
        [Required]
        public string EncCreatedUserID { get; set; }

        /// <summary>
        /// QRCodeBase64
        /// </summary>
        public string QRCodeBase64 { get; set; }

        /// <summary>
        /// QRCodeGUID
        /// </summary>
        public string QRCodeID { get; set; }

        /// <summary>
        /// EnforcementID
        /// </summary>
        public string EncEnforcementID { get; set; }
    }
    #endregion EnforcementModel
}
