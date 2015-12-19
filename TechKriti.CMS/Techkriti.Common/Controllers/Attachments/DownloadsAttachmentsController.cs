using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace Techkriti.Common.Controllers.Attachments
{
    public class DownloadsAttachmentsController : BaseAttachmentsController
    {
        public DownloadsAttachmentsController(FileUpload control) : base(control) { }

        protected override string destinationFolderPathKey { get { return ConfigurationManager.AppSettings["DownloadsUploadFolder"]; } }
    }
}