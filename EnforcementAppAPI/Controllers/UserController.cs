#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enforcement.BLL.Interface;
using Enforcement.BLL.Interface.Account;
using Enforcement.Domain;
using EnforcementAppAPI.Common;
using EnforcementAppAPI.Models.Common;
using EnforcementAppAPI.Models.User;
using KeyVault.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenProvider.Interfaces;
using Utilities;
#endregion Included Namespaces

namespace EnforcementAppAPI.Controllers
{
    #region UserController
    /// <summary>
    /// UserController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// _iUser
        /// </summary>
        private readonly IUser _iUser;

        /// <summary>
        /// _iAuthentication
        /// </summary>
        private readonly IAuthentication _iAuthentication;

        /// <summary>
        /// USEREMAILEXIST
        /// </summary>
        private const string USEREMAILEXIST = "Email Already Exist";

        #endregion Private members

        #region UserController
        /// <summary>
        /// UserController
        /// </summary>
        /// <param name="iUser"></param>
        /// <param name="iAuthentication"></param>
        public UserController(IUser iUser, IAuthentication iAuthentication)
        {
            this._iUser = iUser;
            this._iAuthentication = iAuthentication;
        }
        #endregion UserController

        #region Registration
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="tokenProvider"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Registration")]
        public ReturnBaseModel<LoginReturnModel> Registration([FromForm] UserModel userModel, [FromServices] ITokenProvider tokenProvider)
        {
            LoginReturnModel loginReturnModel = new LoginReturnModel();
            var objResponseModal = new ReturnBaseModel<LoginReturnModel>();
            string accessToken = string.Empty;

            long userID = 0;

            if (ModelState.IsValid && userModel != null)
            {
                var userDomain = this.MapUserModelToDomain(userModel);
                userID = this._iUser.Register(userDomain);

                if (userID > 0)
                {
                    accessToken = tokenProvider.GenerateToken(userDomain.Name, userID);

                    userDomain.UserID = userID;

                    loginReturnModel = this.MapUserDomainToLoginReturnModel(userDomain);
                    loginReturnModel.AccessToken = accessToken;

                    this._iAuthentication.SaveToken(accessToken, userID);

                    objResponseModal.SuccessResponse(loginReturnModel);
                }
                else if (userID == -1)
                {
                    objResponseModal.ErrorResponseWithStringOutput(USEREMAILEXIST);
                }
                else
                {
                    objResponseModal.ErrorResponse();
                }
            }
            else
            {
                objResponseModal.BadRequestResponse();
            }

            return objResponseModal;
        }
        #endregion Registration

        #region Login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="keyValueProvider"></param>
        /// <param name="tokenProvider"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ReturnBaseModel<LoginReturnModel> Login(LoginModel loginModel, [FromServices] IKeyValueProvider keyValueProvider, [FromServices] ITokenProvider tokenProvider)
        {
            string accessToken = string.Empty;
            var objResponseModal = new ReturnBaseModel<LoginReturnModel>();
            LoginReturnModel loginReturnModel = new LoginReturnModel();
            User objUser = new User();

            if (ModelState.IsValid && loginModel != null)
            {
                objUser = this._iUser.Authenticate(loginModel.Username.Trim(), loginModel.Password.Trim());
                loginReturnModel = this.MapUserDomainToLoginReturnModel(objUser);

                if (loginReturnModel != null)
                {
                    accessToken = tokenProvider.GenerateToken(objUser.Name, objUser.UserID);
                    loginReturnModel.AccessToken = accessToken;
                    this._iAuthentication.SaveToken(accessToken, objUser.UserID);
                    objResponseModal.SuccessResponse(loginReturnModel);
                }
                else
                {
                    objResponseModal.ErrorResponseWithStringOutput("Invalid credentials");
                }
            }
            else
            {
                objResponseModal.BadRequestResponse();
            }

            return objResponseModal;
        }
        #endregion Login

        #region Private Methods

        #region MapUserModelToDomain
        /// <summary>
        /// MapUserModelToDomain
        /// </summary>
        /// <param name="usrModle"></param>
        /// <returns></returns>
        private User MapUserModelToDomain(UserModel usrModle)
        {
            User domObj = new User()
            {
                Name = usrModle.Name,
                EmailID = usrModle.EmailID,
                PhoneNumber = usrModle.PhoneNumber,
                Password = usrModle.Password,
                IsActive = usrModle.IsActive,
            };

            return domObj;
        }
        #endregion MapUserModelToDomain 

        #region MapUserDomainToLoginReturnModel
        /// <summary>
        /// MapUserDomainToLoginReturnModel
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        private LoginReturnModel MapUserDomainToLoginReturnModel(User userObj)
        {
            LoginReturnModel loginReturnModel = null;

            if (userObj != null)
            {
                loginReturnModel = new LoginReturnModel()
                {
                    EmailID = userObj.EmailID,
                    EncUserID = userObj.UserID.ToString().Encrypt(),
                    Name = userObj.Name,
                    PhoneNumber = userObj.PhoneNumber
                };
            }

            return loginReturnModel;
        }
        #endregion MapUserDoaminToLoginReturnModel

        #endregion Private Methods
    }
    #endregion UserController
}