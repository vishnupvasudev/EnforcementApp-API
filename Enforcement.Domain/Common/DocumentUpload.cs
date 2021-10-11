#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace Enforcement.Domain.Common
{
    #region DocumentUpload
    /// <summary>
    /// DocumentUpload
    /// </summary>
    public class DocumentUpload
    {
        /// <summary>
        /// DocumentUpload.
        /// </summary>
        public DocumentUpload()
        {
        }

        /// <summary>
        /// DocumentUpload.
        /// </summary>
        /// <param name="documentName"></param>
        /// <param name="fileName"></param>
        public DocumentUpload(string documentName, string fileName)
        {
            IDDocumentName = documentName;
            IDDocumentSavedFileName = fileName;
        }

        /// <summary>
        /// IDDocumentName
        /// </summary>
        public string IDDocumentName { get; set; }

        /// <summary>
        /// IDDocumentSavedFileName
        /// </summary>
        public string IDDocumentSavedFileName { get; set; }
    }
    #endregion DocumentUpload
}
