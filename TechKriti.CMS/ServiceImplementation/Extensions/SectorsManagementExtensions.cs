
using Bussiness.Entities.SectorsManagement;
using Common.SectorsManagement;
using Datacontracts.SectorsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.SectionManagement;
using Common.SectionManagement;
using Bussiness.Entities.SectionManagement;

namespace ServiceImplementation.Extensions.SectorsManagement
{
    public static class SectorsManagementExtensions
    {
        public static List<SectorDataContract> ToDataContract(this List<DAL.Datamodel.Sector> items)
        {
            List<SectorDataContract> dc = new List<SectorDataContract>();

            items.ForEach( i => dc.Add(i.ToDataContract()) );

            return dc;
        }

        public static SectorDataContract ToDataContract( this DAL.Datamodel.Sector item )
        {
            SectorDataContract dc = new SectorDataContract();

            dc.Id = item.Id;          
            dc.SectorName = item.SectorName;            
            dc.ParentSectorId = item.ParentSectorId;           

            return dc;
        }

        public static ISector ToBussinessEntity(this SectorDataContract item)
        {
            ISector bussinessEntitySector = new Sector();

            bussinessEntitySector.Id = item.Id;            
            bussinessEntitySector.SectorName = item.SectorName;           
            bussinessEntitySector.ParentSectorId = item.ParentSectorId;

            return bussinessEntitySector;
        }

        public static ISectorsSearchFilter ToFilter(this SectorSearchFilterDataContract item)
        {
            ISectorsSearchFilter filter = new SectorSearchFilter();

            filter.Count = item.Count;
            filter.StartIndex = item.StartIndex; 
            filter.SectorName = item.SectorName;            
            filter.GetParentSectorsOnly = item.GetParentSectorsOnly;             

            return filter;
        }

        public static List<SectionDataContract> ToDataContract(this List<DAL.Datamodel.SectionMaster> items)
        {
            List<SectionDataContract> dc = new List<SectionDataContract>();

            items.ForEach(i => dc.Add(i.ToDataContract()));

            return dc;
        }

        public static SectionDataContract ToDataContract(this DAL.Datamodel.SectionMaster item)
        {
            SectionDataContract dc = new SectionDataContract();

            dc.Id = item.Id;
            dc.Name = item.Name;         
            return dc;
        }

        public static ISection ToBussinessEntity(this SectionDataContract item)
        {
            ISection bussinessEntitySection = new Section();

            bussinessEntitySection.Id = item.Id;
            bussinessEntitySection.Name = item.Name;
            bussinessEntitySection.SectionType = item.SectionType;
            
            return bussinessEntitySection;
        }

        public static ISectionSearchFilter ToFilter(this SectionSearchFilterDataContract item)
        {
            ISectionSearchFilter filter = new SectionSearchFilter();

            filter.Count = item.Count;
            filter.StartIndex = item.StartIndex;
            filter.SectionType = item.SectionType;           

            return filter;
        }
    }
}
