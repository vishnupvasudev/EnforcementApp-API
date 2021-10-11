#region Included Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.User
{
    #region UserModel
    /// <summary>
    /// UserModel
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// EmailID
        /// </summary>
        [Required]
        public string EmailID { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
    }
    #endregion UserModel
}
