#region Included namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Utilities.Interfaces
{
    #region IActionLog
    /// <summary>
    /// IActionLog
    /// </summary>
    public interface IActionLog
    {
        #region WriteLog
        /// <summary>
        /// Write Log
        /// </summary>
        /// <param name="objModel"></param>
        void WriteLog(ActionLogManagement.ActionLog objModel);
        #endregion WriteLog
    }
    #endregion
}
