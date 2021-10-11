#region Included Namespaces
using System;
#endregion Included Namespaces

namespace Enforcement.Domain
{
    #region User
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// UserID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// EmailID
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
    #endregion User
}
