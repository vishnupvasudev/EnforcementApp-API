#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace Enforcement.BLL.Interface.Account
{
    #region IAuthentication
    /// <summary>
    /// IAuthentication
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// SaveToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        bool SaveToken(string accessToken, long userID);
    }
    #endregion IAuthentication
}
