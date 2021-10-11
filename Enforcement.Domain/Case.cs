using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enforcement.Domain
{
    #region Case
    /// <summary>
    /// Case
    /// </summary>
    public class Case
    {
        /// <summary>
        /// CaseID
        /// </summary>
        public long CaseID { get; set; }

        /// <summary>
        /// CaseNumber
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// CaseTitle
        /// </summary>
        public string CaseTitle { get; set; }
    }
    #endregion Case
}
