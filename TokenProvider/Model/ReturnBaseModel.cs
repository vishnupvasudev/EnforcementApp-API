
#region Included Namespaces
using Newtonsoft.Json;
#endregion Included Namespaces

namespace TokenProvider.Model
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
        [JsonProperty("Output", NullValueHandling = NullValueHandling.Ignore)]
        public T Output { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool status { get; set; }

        /// <summary>
        /// errorCode
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// errorMessage
        /// </summary>
        public string errorMessage { get; set; }

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
