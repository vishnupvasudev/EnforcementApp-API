#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enforcement.BLL.Interface;
using Enforcement.DAL;
using Enforcement.Domain;
using Utilities;
#endregion Included Namespaces

namespace Enforcement.BLL.Implementation
{
    #region UserBLL
    /// <summary>
    /// UserBLL
    /// </summary>
    public class UserBLL : IUser
    {
        #region Private members

        /// <summary>
        /// IRepository
        /// </summary>
        private readonly IRepository _iRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iRepository"></param>
        public UserBLL(IRepository iRepository)
        {
            this._iRepository = iRepository;
        }
        #endregion Constructor

        #region Register
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public long Register(User user)
        {
            DataAccessParameters objParam = new DataAccessParameters();

            if (user != null)
            {
                objParam.Add("@Name", user.Name.Trim());
                objParam.Add("@Password", user.Password.Encrypt());
                objParam.Add("@EmailID", user.EmailID.Trim());
                objParam.Add("@PhoneNumber", user.PhoneNumber);
            }

            return this._iRepository.AddAndReturnPrimaryKey("enm.UserInsert", objParam);
        }
        #endregion Register

        #region Authenticate
        /// <summary>
        /// AuthenticateAuthenticate
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Domain.User Authenticate(string email, string password)
        {
            DataAccessParameters param = new DataAccessParameters();

            param.Add("@UserName", email.Trim());
            param.Add("@Password", password.Encrypt());

            Domain.User usrObj = this._iRepository.FindByID<Domain.User>("enm.UserDetailsByEmailPasswordSelect", param);

            return usrObj;
        }
        #endregion Authenticate
    }
    #endregion UserBLL
}
