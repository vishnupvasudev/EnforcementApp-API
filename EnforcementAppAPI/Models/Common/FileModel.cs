using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EnforcementAppAPI.Models.Common
{
    #region FileModel
    /// <summary>
    /// FileModel
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// FileContent
        /// </summary>
        public IFormFile FileUrl { get; set; }

        /// <summary>
        /// Encrypted FileID
        /// </summary>
        public string FileType { get; set; }
    }
    #endregion
}
