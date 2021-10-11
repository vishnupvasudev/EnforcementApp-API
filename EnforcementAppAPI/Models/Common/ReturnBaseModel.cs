using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnforcementAppAPI.Models.Common
{
    /// <summary>
    /// ReturnBaseModel
    /// </summary>
    /// <typeparam name="T">Generic Parameter</typeparam>
    public class ReturnBaseModel<T>
    {
        /// <summary>
        /// Output_
        /// </summary>
        [JsonPropertyName("Output")]
        public T Output { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// errorCode
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// errorMessage
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// StatusCode
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// StatusMessage
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// ResponseDate
        /// </summary>
        public string ResponseDate { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }
    }
}
