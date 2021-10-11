#region Included Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enforcement.BLL.Interface;
using Enforcement.Domain.Common;
using Microsoft.AspNetCore.Http;
#endregion Included Namespaces

namespace Enforcement.BLL.Implementation
{
    #region CommonBLL
    /// <summary>
    /// CommonBLL
    /// </summary>
    public class CommonBLL : ICommon
    {
        /// <summary>
        /// UploadFile.
        /// </summary>
        /// <param name="uploadFilepath"></param>
        /// <param name="lstDocuments"></param>
        /// <returns>uploaded file path and name.</returns>
        public async Task<List<DocumentUpload>> UploadFile(string uploadFilepath, List<IFormFile> lstDocuments)
        {
            List<DocumentUpload> lstUploadedFiles = new List<DocumentUpload>();
            if (lstDocuments.Any())
            {
                foreach (IFormFile file in lstDocuments)
                {
                    if (file.Length > 0)
                    {
                        string generatedFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        if (!Directory.Exists(uploadFilepath))
                        {
                            Directory.CreateDirectory(uploadFilepath);
                        }

                        string filePath = Path.Combine(uploadFilepath, generatedFileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        lstUploadedFiles.Add(new DocumentUpload(file.FileName, generatedFileName));
                    }
                }
            }

            return lstUploadedFiles;
        }
    }
    #endregion CommonBLL
}
