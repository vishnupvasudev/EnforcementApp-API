#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EnforcementAppAPI.Models.User
{
    #region LoginReturnModel
    /// <summary>
    /// LoginReturnModel
    /// </summary>
    public class LoginReturnModel
    {
        /// <summary>
        /// UserID
        /// </summary>
        public string EncUserID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }
    }
    #endregion LoginReturnModel
}
