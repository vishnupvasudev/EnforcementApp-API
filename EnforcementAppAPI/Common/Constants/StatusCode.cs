using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnforcementAppAPI.Common.Constants
{
    #region StatusCode
    /// <summary>
    /// StatusCode
    /// </summary>
    public static class StatusCode
    {
        /// <summary>
        /// BadRequest
        /// </summary>
        public const string BadRequest = "400";

        /// <summary>
        /// Failed
        /// </summary>
        public const string Failed = "500";

        /// <summary>
        /// NoError
        /// </summary>
        public const string Success = "200";

        /// <summary>
        /// SendEmailFailed
        /// </summary>
        public const string SendEmailFailed = "550";

        /// <summary>
        /// ResourceNotFount
        /// </summary>
        public const string ResourceNotFount = "404";

        /// <summary>
        /// UploadFailed
        /// </summary>
        public const string UploadFailed = "409";

        /// <summary>
        /// Invalid Token
        /// </summary>
        public const string InvalidToken = "401";
    }
    #endregion
}
