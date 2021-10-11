using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces
{
    #region ILog
    /// <summary>
    /// ILog
    /// </summary>
    public interface ILog
    {
        #region Methods

        /// <summary>
        /// Information
        /// </summary>
        /// <param name="message"></param>
        void Information(string message);

        /// <summary>
        /// Warning
        /// </summary>
        /// <param name="message"></param>
        void Warning(string message);

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        #endregion Methods
    }
    #endregion
}
