using Bussiness.Entities.AttachmentsManagement;
using Common.AttachmentsManagement;
using Datacontracts.AttachmentsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Extensions.AttachmentsManagement
{
    public static class AttachmentsManagementExtensions
    {
        public static List<AttachmentDataContract> ToDataContract(this List<DAL.Datamodel.SectorAttachment> items)
        {
            List<AttachmentDataContract> dc = new List<AttachmentDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static AttachmentDataContract ToDataContract(this DAL.Datamodel.SectorAttachment item)
        {
            AttachmentDataContract dc = new AttachmentDataContract();

            dc.AttachmentId = item.Id;
            dc.AttachmentPath = item.DownloadPath;
            dc.AttachmentCaption = item.Caption;

            return dc;
        }

        public static List<AttachmentDataContract> ToDataContract(this List<DAL.Datamodel.PhotoGalleryAttachment> items)
        {
            List<AttachmentDataContract> dc = new List<AttachmentDataContract>();

            items.ForEach( item => dc.Add(item.ToDataContract()) );

            return dc;
        }

        public static AttachmentDataContract ToDataContract(this DAL.Datamodel.PhotoGalleryAttachment item)
        {
            AttachmentDataContract dc = new AttachmentDataContract();

            dc.AttachmentId = item.Id;
            dc.AttachmentPath = item.DownloadPath;              

            return dc;
        }

        public static List<AttachmentDataContract> ToDataContract(this List<DAL.Datamodel.TestimonialAttachment> items)
        {
            List<AttachmentDataContract> dc = new List<AttachmentDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static AttachmentDataContract ToDataContract(this DAL.Datamodel.TestimonialAttachment item)
        {
            AttachmentDataContract dc = new AttachmentDataContract();

            dc.AttachmentId = item.Id;
            dc.AttachmentPath = item.DownloadPath;

            return dc;
        }


        public static List<AttachmentDataContract> ToDataContract(this List<DAL.Datamodel.DownloadAttachment> items)
        {
            List<AttachmentDataContract> dc = new List<AttachmentDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static AttachmentDataContract ToDataContract(this DAL.Datamodel.DownloadAttachment item)
        {
            AttachmentDataContract dc = new AttachmentDataContract();

            dc.AttachmentId = item.Id;
            dc.AttachmentPath = item.DownloadPath;

            return dc;
        }



        public static List<IAttachment> ToBussinessEntity(this List<AttachmentDataContract> items)
        {
            List<IAttachment> attachmentsBO = new List<IAttachment>();

            items.ForEach(item => attachmentsBO.Add( item.ToBussinessEntity() ));

            return attachmentsBO;
        }

        public static IAttachment ToBussinessEntity(this AttachmentDataContract item)
        {
            IAttachment attachmentBO = new Attachment();

            attachmentBO.AttachmentId = item.AttachmentId;
            attachmentBO.AttachmentPath = item.AttachmentPath;
            attachmentBO.AttachmentCaption = item.AttachmentCaption;

            return attachmentBO;
        }
    }
}
