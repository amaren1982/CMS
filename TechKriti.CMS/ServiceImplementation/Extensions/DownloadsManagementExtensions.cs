
using Bussiness.Entities.SectorsManagement;
using Common.SectorsManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Downloads;
using Common.DownloadsManagement;
using Bussiness.Entities.DownloadsManagement;

namespace ServiceImplementation.Extensions.DownloadsManagement
{
    public static class DownloadsManagementExtensions
    {
        public static List<DownloadsDataContract> ToDataContract(this List<DAL.Datamodel.Download> items)
        {
            List<DownloadsDataContract> dc = new List<DownloadsDataContract>();

            items.ForEach( i => dc.Add(i.ToDataContract()) );

            return dc;
        }

        public static DownloadsDataContract ToDataContract(this DAL.Datamodel.Download item)
        {
            DownloadsDataContract dc = new DownloadsDataContract();

            dc.Id = item.Id;           
            dc.DisplayName = item.DisplayName;           
            dc.SectionId = item.SectionId;
            dc.IsActive = item.IsActive;           

            return dc;
        }

        public static IDownload ToBussinessEntity(this DownloadsDataContract item)
        {
            IDownload bo = new Downloads();

            bo.Id = item.Id;          
            bo.DisplayName = item.DisplayName;           
            bo.SectionId = item.SectionId;
            bo.IsActive = item.IsActive;

            return bo;
        }

        public static IDownloadsSearchFilter ToFilter(this DownloadsSearchFilterDataContract item)
        {
            IDownloadsSearchFilter filter = new DownloadsSearchFilter();

            filter.Count = item.Count;
            filter.CreatedBy = item.CreatedBy;
            filter.DisplayName = item.DisplayName;           
            filter.SectionId = item.SectionId;
            filter.StartIndex = item.StartIndex;
            filter.IsActive = item.IsActive;

            return filter;
        }
    }
}
