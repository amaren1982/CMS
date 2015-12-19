using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using Datacontracts.AttachmentsManagement;

namespace Techkriti.Common.Controllers.Attachments
{
    public abstract class BaseAttachmentsController
    {
        private FileUpload uploadControl;
        private TextBox attachmentDescriptionControl;
        protected abstract string destinationFolderPathKey { get; }

        private string destinationRootFolderPathKey { get { return ConfigurationManager.AppSettings["RootFolderForAttachments"]; } }
        private string rootDirectoryPath = string.Empty;
        private string uploadDirectoryPath = string.Empty;
        private string destinationFolder = string.Empty;

        public BaseAttachmentsController(FileUpload control) { this.uploadControl = control; }

        public BaseAttachmentsController(FileUpload control, TextBox attachmentDescription) 
        { 
            this.uploadControl = control;
            this.attachmentDescriptionControl = attachmentDescription;
        }

        public List<AttachmentDataContract> Upload()
        {
            List<AttachmentDataContract> uploadedAttachments = new List<AttachmentDataContract>();

            if (uploadControl.HasFiles)
            {
                CheckAndCreateUploadDirectory();

                foreach (HttpPostedFile uploadedFile in uploadControl.PostedFiles)
                {
                    string saveFileAt = string.Empty;
                    string fileName = Path.GetFileName(uploadedFile.FileName);                    
                    saveFileAt = Path.Combine(uploadDirectoryPath, fileName);

                    uploadedFile.SaveAs(saveFileAt);

                    destinationFolder = Path.Combine(destinationFolderPathKey, fileName);

                    AttachmentDataContract attachment = new AttachmentDataContract();
                    attachment.AttachmentPath = destinationFolder;
                    if (attachmentDescriptionControl != null) attachment.AttachmentCaption = attachmentDescriptionControl.Text;
                    uploadedAttachments.Add(attachment);
                }
            }

            return uploadedAttachments;
        }

        private void CheckAndCreateUploadDirectory()
        {
            rootDirectoryPath = HttpContext.Current.Server.MapPath(destinationRootFolderPathKey);
            if (!Directory.Exists(rootDirectoryPath)) Directory.CreateDirectory(rootDirectoryPath);

            uploadDirectoryPath = HttpContext.Current.Server.MapPath(destinationFolderPathKey);
            if (!Directory.Exists(uploadDirectoryPath)) Directory.CreateDirectory(uploadDirectoryPath);
        }
    }
}