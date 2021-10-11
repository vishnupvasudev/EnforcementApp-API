using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnforcementAppAPI.Common.Constants
{
    #region StatusMessage
    /// <summary>
    /// StatusMessage
    /// </summary>
    public static class StatusMessage
    {
        /// <summary>
        /// BadRequest
        /// </summary>
        public const string BadRequest = "Bad Request";

        /// <summary>
        /// Failed
        /// </summary>
        public const string Failed = "Failed";

        /// <summary>
        /// NoError
        /// </summary>
        public const string Success = "Success";

        /// <summary>
        /// SendEmailFailed
        /// </summary>
        public const string SendEmailFailed = "Email send failed";

        /// <summary>
        /// UserNotFount
        /// </summary>
        public const string UserNotFount = "User does not exist";

        /// <summary>
        /// UploadFailed
        /// </summary>
        public const string UploadFailed = "File Upload failed";

        /// <summary>
        /// Invalid Token
        /// </summary>
        public const string InvalidToken = "Invalid Token";
    }
    #endregion
}
