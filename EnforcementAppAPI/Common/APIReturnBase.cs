using System;
using EnforcementAppAPI.Common.Constants;
using EnforcementAppAPI.Models.Common;
using Utilities;

namespace EnforcementAppAPI.Common
{
    #region APIReturnBase
    /// <summary>
    /// APIReturnBase
    /// </summary>
    public static class APIReturnBase
    {
        #region Constant variables
        /// <summary>
        /// VERSION
        /// </summary>
        private const string VERSION = "V1";
        #endregion Constant variables

        #region SuccessResponse
        /// <summary>
        /// SuccessResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> SuccessResponse<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = string.Empty;
                objReturn.ErrorMessage = string.Empty;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = true;
                objReturn.StatusCode = StatusCode.Success;
                objReturn.StatusMessage = StatusMessage.Success;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion SuccessResponse

        #region ErrorResponse
        /// <summary>
        /// ErrorResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> ErrorResponse<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = ErrorCode.Failed;
                objReturn.ErrorMessage = ErrorMessage.Failed;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.Failed;
                objReturn.StatusMessage = StatusMessage.Failed;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion

        #region ErrorResponse - with no output
        /// <summary>
        /// ErrorResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> ErrorResponse<T>(this ReturnBaseModel<T> objReturn)
        {
            if (objReturn != null)
            {
                objReturn.ErrorCode = ErrorCode.Failed;
                objReturn.ErrorMessage = ErrorMessage.Failed;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.Failed;
                objReturn.StatusMessage = StatusMessage.Failed;
                objReturn.Version = VERSION;
            }

            return objReturn;
        }
        #endregion

        #region BadRequestResponse
        /// <summary>
        /// BadRequestResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> BadRequestResponse<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = ErrorCode.BadRequest;
                objReturn.ErrorMessage = ErrorMessage.BadRequest;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.BadRequest;
                objReturn.StatusMessage = StatusMessage.BadRequest;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion

        #region BadRequestResponse - With no output
        /// <summary>
        /// BadRequestResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> BadRequestResponse<T>(this ReturnBaseModel<T> objReturn)
        {
            if (objReturn != null)
            {
                objReturn.ErrorCode = ErrorCode.BadRequest;
                objReturn.ErrorMessage = ErrorMessage.BadRequest;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.BadRequest;
                objReturn.StatusMessage = StatusMessage.BadRequest;
                objReturn.Version = VERSION;
            }

            return objReturn;
        }
        #endregion

        #region EmailSendFailed
        /// <summary>
        /// BadRequestResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> EmailSendFailed<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = ErrorCode.SendEmailFailed;
                objReturn.ErrorMessage = ErrorMessage.SendEmailFailed;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.SendEmailFailed;
                objReturn.StatusMessage = StatusMessage.SendEmailFailed;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion EmailSendFailed

        #region EmailSendFailed - With no output
        /// <summary>
        /// BadRequestResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> EmailSendFailed<T>(this ReturnBaseModel<T> objReturn)
        {
            if (objReturn != null)
            {
                objReturn.ErrorCode = ErrorCode.SendEmailFailed;
                objReturn.ErrorMessage = ErrorMessage.SendEmailFailed;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.SendEmailFailed;
                objReturn.StatusMessage = StatusMessage.SendEmailFailed;
                objReturn.Version = VERSION;
            }

            return objReturn;
        }
        #endregion EmailSendFailed

        #region ResourceNotFound
        /// <summary>
        /// ResourceNotFound
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> ResourceNotFound<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = ErrorCode.ResourceNotFount;
                objReturn.ErrorMessage = ErrorMessage.UserNotFount;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.ResourceNotFount;
                objReturn.StatusMessage = StatusMessage.UserNotFount;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion ResourceNotFound

        #region ResourceNotFound - With no output
        /// <summary>
        /// ResourceNotFound
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> ResourceNotFound<T>(this ReturnBaseModel<T> objReturn)
        {
            if (objReturn != null)
            {
                objReturn.ErrorCode = ErrorCode.ResourceNotFount;
                objReturn.ErrorMessage = ErrorMessage.UserNotFount;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.ResourceNotFount;
                objReturn.StatusMessage = StatusMessage.UserNotFount;
                objReturn.Version = VERSION;
            }

            return objReturn;
        }
        #endregion ResourceNotFound

        #region UploadFailed
        /// <summary>
        /// ResourceNotFound
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> UploadFailed<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = ErrorCode.UploadFailed;
                objReturn.ErrorMessage = ErrorMessage.UploadFailed;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.UploadFailed;
                objReturn.StatusMessage = StatusMessage.UploadFailed;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion UploadFailed

        #region UploadFailed - With no output
        /// <summary>
        /// ResourceNotFound
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> UploadFailed<T>(this ReturnBaseModel<T> objReturn)
        {
            if (objReturn != null)
            {
                objReturn.ErrorCode = ErrorCode.UploadFailed;
                objReturn.ErrorMessage = ErrorMessage.UploadFailed;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.UploadFailed;
                objReturn.StatusMessage = StatusMessage.UploadFailed;
                objReturn.Version = VERSION;
            }

            return objReturn;
        }
        #endregion UploadFailed - With no output

        #region ErrorResponse
        /// <summary>
        /// ErrorResponse
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="objOutput"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> InvalidToken<T>(this ReturnBaseModel<T> objReturn, T objOutput)
        {
            if (objReturn != null && objOutput != null)
            {
                objReturn.ErrorCode = ErrorCode.InvalidToken;
                objReturn.ErrorMessage = ErrorMessage.InvalidToken;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.InvalidToken;
                objReturn.StatusMessage = StatusMessage.Failed;
                objReturn.Version = VERSION;
                objReturn.Output = objOutput;
            }

            return objReturn;
        }
        #endregion

        #region ErrorResponseWithStringOutput
        /// <summary>
        /// ErrorResponseWithStringOutput
        /// </summary>
        /// <typeparam name="T">ReturnBaseModel</typeparam>
        /// <param name="objReturn"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static ReturnBaseModel<T> ErrorResponseWithStringOutput<T>(this ReturnBaseModel<T> objReturn, string errorMessage)
        {
            if (objReturn != null)
            {
                objReturn.ErrorCode = ErrorCode.Failed;
                objReturn.ErrorMessage = errorMessage;
                objReturn.ResponseDate = DateTime.Now.GetDateInFormat();
                objReturn.Status = false;
                objReturn.StatusCode = StatusCode.Failed;
                objReturn.StatusMessage = StatusMessage.Failed;
                objReturn.Version = VERSION;
            }

            return objReturn;
        }
        #endregion
    }
    #endregion APIReturnBase
}