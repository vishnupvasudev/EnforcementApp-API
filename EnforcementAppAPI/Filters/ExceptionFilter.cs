#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Utilities.Interfaces;
#endregion Included Namespaces

namespace EnforcementAppAPI.Filters
{
    #region ExceptionFilter
    /// <summary>
    /// ExceptionFilter
    /// </summary>
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        /// <summary>
        /// ILog
        /// </summary>
        private readonly ILog _logger;

        #region Constructor
        /// <summary>
        /// ExceptionFilter
        /// </summary>
        /// <param name="logger"></param>
        public ExceptionFilter(ILog logger)
        {
            this._logger = logger;
        }
        #endregion

        #region OnException
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            string additionalInfo = controllerName.ToString() + "-" + actionName.ToString();

            string fullMessage = string.Format("\n ======START====== \n Exception \n " + additionalInfo);
            string seperateError = string.Format(" \n ======END====== \n ");

            string exceptionStackTrace = (context.Exception.StackTrace ?? string.Empty) + "\n" +
               (context.Exception.InnerException != null ? (context.Exception.InnerException.Message ?? string.Empty) + "\n" + (context.Exception.InnerException.StackTrace ?? string.Empty) : string.Empty);

            fullMessage += string.Format(
                "\n Exception : {0}\n ExceptionDetails{1} \n ExceptionTime : {2} \n {3} \n ",
                context.Exception.Message, exceptionStackTrace,
                DateTime.Now.ToLongTimeString(),
                seperateError);

            // Get stack trace for the exception with source file information
            var st = new System.Diagnostics.StackTrace(context.Exception, false);

            if (st != null)
            {
                // Get the top stack frame
                var frame = st.GetFrame(0);
                if (frame != null)
                {
                    // Get the line number from the stack frame
                    var line = frame.GetFileLineNumber();

                    if (line > 0)
                    {
                        fullMessage += "\n Error LineNumber : " + line;
                    }
                }
            }

            this._logger.Error(fullMessage);

            context.ExceptionHandled = false;
            ////context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Error" }));
            ////throw new Exception(fullMessage);
        }
        #endregion
    }
    #endregion ExceptionFilter
}
