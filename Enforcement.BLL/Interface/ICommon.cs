#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enforcement.Domain.Common;
using Microsoft.AspNetCore.Http;
#endregion Included Namespaces

namespace Enforcement.BLL.Interface
{
    #region ICommon
    /// <summary>
    /// ICommon
    /// </summary>
    public interface ICommon
    {
        /// <summary>
        /// UploadFile
        /// </summary>
        /// <param name="uploadFilepath"></param>
        /// <param name="lstDocuments"></param>
        /// <returns></returns>
        Task<List<DocumentUpload>> UploadFile(string uploadFilepath, List<IFormFile> lstDocuments);
    }
    #endregion ICommon
}
