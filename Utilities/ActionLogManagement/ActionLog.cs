#region Included namespaces
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace Utilities.ActionLogManagement
{
    #region ActionLog
    /// <summary>
    /// ActionLog
    /// </summary>
    public class ActionLog
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Request
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// RequestURL
        /// </summary>
        public string RequestURL { get; set; }

        /// <summary>
        /// RequestURL
        /// </summary>
        [XmlIgnore]
        public IPAddress RemoteIpAddress { get; set; }

        /// <summary>
        /// HTTPType
        /// </summary>
        public string HTTPType { get; set; }

        /// <summary>
        /// APIMethod
        /// </summary>
        public string APIMethod { get; set; }

        /// <summary>
        /// IPAddress 
        /// </summary>
        public string IPAddress { get; set; }
    }
    #endregion
}
