#region Included Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.User
{
    #region LoginModel
    /// <summary>
    /// LoginModel
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
    #endregion LoginModel
}
