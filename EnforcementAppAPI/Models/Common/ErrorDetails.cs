using System.Text.Json;

namespace EnforcementAppAPI.Models.Common
{
    #region ErrorDetails
    /// <summary>
    /// ErrorDetails
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// StatusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        #region ToString
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        #endregion ToString
    }
    #endregion ErrorDetails
}
