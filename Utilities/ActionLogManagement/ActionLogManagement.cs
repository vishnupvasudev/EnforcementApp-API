#region Included namespaces
using System;
using Experimental.System.Messaging;
using KeyVault.Interfaces;
#endregion

namespace Utilities.ActionLogManagement
{
    #region ActionLogManagement
    /// <summary>
    /// ActionLogManagement
    /// </summary>
    public class ActionLogManagement : Interfaces.IActionLog
    {
        #region Data Member

        /// <summary>
        /// keyValueProvider
        /// </summary>
        private readonly IKeyValueProvider _ikeyValueProvider;

        /// <summary>
        /// _queue
        /// </summary>
        private MessageQueue _queue;

        #endregion

        #region Constructor
        /// <summary>
        /// QueueManagement Constructor
        /// </summary>
        /// <param name="ikeyValueProvider"></param>
        public ActionLogManagement(IKeyValueProvider ikeyValueProvider)
        {
            this._ikeyValueProvider = ikeyValueProvider;
        }
        #endregion

        #region WriteLog 
        /// <summary>
        /// WriteLog
        /// </summary>
        /// <param name="objModel"></param>
        public void WriteLog(ActionLog objModel)
        {
            if (objModel != null)
            {
                objModel.IPAddress = objModel.RemoteIpAddress.ToString();

                this.WriteActionLogToQueue(objModel);
            }
        }
        #endregion  WriteLog - interface

        #region WriteLog to Queue
        /// <summary>
        /// Write_Log
        /// </summary>
        /// <param name="actionLogDomain"></param>
        /// <returns></returns>
        public bool WriteActionLogToQueue(ActionLog actionLogDomain)
        {
            bool result = true;
            string QueuePath = this._ikeyValueProvider.GetValues("ActionLogQueue").ToString();

            if (MessageQueue.Exists(QueuePath))
            {
                this._queue = new MessageQueue(QueuePath);
                this._queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ActionLog) });
                this._queue.Send(actionLogDomain);
            }

            return result;
        }
        #endregion
    }
    #endregion
}
