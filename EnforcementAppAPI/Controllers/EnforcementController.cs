#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Enforcement.BLL.Interface;
using Enforcement.BLL.Interface.Enforcement;
using Enforcement.Domain;
using Enforcement.Domain.Common;
using EnforcementAppAPI.Common;
using EnforcementAppAPI.Models.Common;
using EnforcementAppAPI.Models.Enforcement;
using KeyVault.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using Utilities;
#endregion Included Namespaces

namespace EnforcementAppAPI.Controllers
{
    #region EnforcementController
    /// <summary>
    /// EnforcementController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnforcementController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// _iEnforcement
        /// </summary>
        private readonly IEnforcement _iEnforcement;

        /// <summary>
        /// _iCommon
        /// </summary>
        private readonly ICommon _iCommon;

        /// <summary>
        /// _hostingEnvironment
        /// </summary>
        private readonly IWebHostEnvironment hostingEnvironment;

        /// <summary>
        /// _iKeyValueProvider
        /// </summary>
        private readonly IKeyValueProvider iKeyValueProvider;

        /// <summary>
        /// _protector
        /// </summary>
        private readonly IDataProtector _protector;

        #endregion Private members

        #region EnforcementController
        /// <summary>
        /// EnforcementController
        /// </summary>
        /// <param name="iEnforcement"></param>
        /// <param name="iCommon"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="iKeyValueProvider"></param>
        /// <param name="protector"></param>
        public EnforcementController(IEnforcement iEnforcement, ICommon iCommon, IWebHostEnvironment hostingEnvironment,
            IKeyValueProvider iKeyValueProvider, IDataProtectionProvider protector)
        {
            this._iEnforcement = iEnforcement;
            this._iCommon = iCommon;
            this.hostingEnvironment = hostingEnvironment;
            this.iKeyValueProvider = iKeyValueProvider;
            this._protector = protector.CreateProtector("Enforcement");
        }
        #endregion EnforcementController

        #region SubmitAssetDetails
        /// <summary>
        /// SubmitAssetDetails
        /// </summary>
        /// <param name="enforcementDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewEnforcement")]
        public async Task<ReturnBaseModel<QRCodeModel>> AddEnforcementDetails([FromForm] EnforcementItemModel enforcementDetails)
        {
            bool status;
            long enforcementID;
            string QRCodeBase64;
            string protectedEnforcementID;
            var returnObject = new ReturnBaseModel<QRCodeModel>();
            QRCodeModel qrmodelObj = new QRCodeModel();
            List<DocumentUpload> documents = new List<DocumentUpload>();

            if (ModelState.IsValid && enforcementDetails != null)
            {
                enforcementID = this._iEnforcement.AddEnforcementdetails(this.MapEnforcementModelToDomain(enforcementDetails));
                if (enforcementID > 0 && enforcementDetails.Images.Count > 0)
                {
                    ////Save asset images
                    UploadPath uploadPaths = this.iKeyValueProvider.GetValues<UploadPath>("AppSettings:UploadPath");
                    string filepath = Path.Combine(this.hostingEnvironment.ContentRootPath, uploadPaths.AssetImages);
                    documents = await this._iCommon.UploadFile(filepath, enforcementDetails.Images);
                    bool docSaveStatus = this._iEnforcement.AddEnforcementAssets(this.MapDocumentListToDomain(documents, enforcementID));

                    ////Generate QR Code
                    protectedEnforcementID = this._protector.Protect(enforcementID.ToString());
                    QRCodeBase64 = Convert.ToBase64String(this.GenerateQRCode(protectedEnforcementID));
                    status = this._iEnforcement.UpdateEnforcementQRDetails(enforcementID, protectedEnforcementID);
                    qrmodelObj.Qrcode = status ? QRCodeBase64 : "";
                    qrmodelObj.QrCodeID = protectedEnforcementID;

                    returnObject.SuccessResponse(qrmodelObj);
                }
                else
                {
                    returnObject.ErrorResponse();
                }
            }
            else
            {
                returnObject.BadRequestResponse();
            }

            return returnObject;
        }
        #endregion SubmitAssetDetails

        #region GetEnforcementDetails
        /// <summary>
        /// GetEnforcementDetails
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEnforcementDetails")]
        public async Task<ReturnBaseModel<EnforcementReturnModel>> GetEnforcementDetails(string itemCode)
        {
            long enforcementID = 0;
            string filepath;
            var webClient = new WebClient();
            EnforcementReturnModel enforcementMod = null;
            Int64.TryParse(this._protector.Unprotect(itemCode), out enforcementID);
            var returnObject = new ReturnBaseModel<EnforcementReturnModel>();
            if (enforcementID > 0)
            {
                EnforcementDetails enforceDet = await Task.FromResult(this._iEnforcement.SelectEnforcementDetailsByID((int)enforcementID));
                List<EnforcementAsset> enforceAsstList = await Task.FromResult(this._iEnforcement.SelectEnforcementAssetByID((int)enforcementID));

                if (enforceDet != null)
                {
                    enforcementMod = new EnforcementReturnModel()
                    {
                        CaseID = enforceDet.CaseID,
                        CaseTitle = enforceDet.CaseTitle,
                        CaseNumber = enforceDet.CaseNumber,
                        ItemName = enforceDet.Title,
                        Description = enforceDet.Description
                    };

                    foreach (EnforcementAsset item in enforceAsstList)
                    {
                        ItemImageModel imageModel = new ItemImageModel();
                        string apiBaseUrl = this.iKeyValueProvider.GetValues("ApiUrl");
                        filepath = Path.Combine(apiBaseUrl, "api/Enforcement/ItemImage?file=");
                        filepath += item.StoredFileName;
                        imageModel.Url = filepath;
                        enforcementMod.Images.Add(imageModel);
                    }
                }
                else
                {
                    returnObject.BadRequestResponse();
                }

                returnObject.SuccessResponse(enforcementMod);
            }
            else
            {
                returnObject.ErrorResponse();
            }

            return returnObject;
        }
        #endregion GetEnforcementDetails

        #region ItemImage
        /// <summary>
        /// ItemImage
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ItemImage")]
        public async Task<ActionResult> ItemImage(string file)
        {
            string filePath;
            var webClient = new WebClient();
            UploadPath uploadPaths = this.iKeyValueProvider.GetValues<UploadPath>("AppSettings:UploadPath");
            filePath = Path.Combine(this.hostingEnvironment.ContentRootPath, uploadPaths.AssetImages);
            filePath = Path.Combine(filePath, file);
            return await Task.FromResult(this.PhysicalFile(filePath, "image/jpeg"));
        }
        #endregion ItemImage

        #region Private Methods

        #region GenerateQRCode
        /// <summary>
        /// GenerateQRCode
        /// </summary>
        /// <param name="qrText"></param>
        /// <returns></returns>
        private Byte[] GenerateQRCode(string qrText)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ////qrCodeImage.Save("sample.jpeg", ImageFormat.Jpeg);
            return BitmapToBytesCode(qrCodeImage);
        }
        #endregion GenerateQRCode

        #region BitmapToBytesCode
        /// <summary>
        /// BitmapToBytesCode
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        #endregion BitmapToBytesCode 

        #region MapEnforcementModelToDomain
        /// <summary>
        /// MapEnforcementModelToDomain
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private EnforcementDetails MapEnforcementModelToDomain(EnforcementItemModel model)
        {
            EnforcementDetails domObj = new EnforcementDetails()
            {
                Title = model.ItemName,
                CaseID = model.CaseID,
                Description = model.Description
            };

            return domObj;
        }
        #endregion MapEnforcementModelToDomain

        #region MapDocumentListToDomain
        /// <summary>
        /// MapDocumentListToDomain
        /// </summary>
        /// <param name="documentList"></param>
        /// <param name="enforcementID"></param>
        /// <returns></returns>
        private List<EnforcementAsset> MapDocumentListToDomain(List<DocumentUpload> documentList, long enforcementID)
        {
            List<EnforcementAsset> docList = documentList.Select(x => new EnforcementAsset()
            {
                EnforcementID = enforcementID,
                ActualFileName = x.IDDocumentName,
                StoredFileName = x.IDDocumentSavedFileName
            }).ToList();

            return docList;
        }
        #endregion MapDocumentListToDomain

        #endregion Private Methods
    }
    #endregion EnforcementController
}
