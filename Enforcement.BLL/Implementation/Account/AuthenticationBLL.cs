#region Included Namespaces
using Enforcement.BLL.Interface.Account;
using Enforcement.DAL;
#endregion Included Namespaces

namespace Enforcement.BLL.Implementation.Account
{
    #region AuthenticationBLL
    /// <summary>
    /// AuthenticationBLL
    /// </summary>
    public class AuthenticationBLL : IAuthentication
    {
        /// <summary>
        /// IRepository
        /// </summary>
        private readonly IRepository _iRepository;

        #region Constructor
        /// <summary>
        /// AdminManagementBLL
        /// </summary>
        /// <param name="iRepository"></param>
        public AuthenticationBLL(IRepository iRepository)
        {
            this._iRepository = iRepository;
        }
        #endregion Constructor

        #region SaveToken
        /// <summary>
        /// SaveToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool SaveToken(string accessToken, long userID)
        {
            DataAccessParameters objParam = new DataAccessParameters();
            objParam.Add("@UserID", userID);
            objParam.Add("@Token", accessToken);

            return _iRepository.Add("[enm].[UserTokenInsert]", objParam);
        }
        #endregion
    }
    #endregion AuthenticationBLL
}
