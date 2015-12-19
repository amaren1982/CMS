using Common.NewsManagement;
using Common.SectorsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.SectorsManagement
{
    public class SearchSectorsRequestManager
    {   
         ISectorsSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchSectorsRequestManager(ISectorsSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<Sector> Sectors { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateSectorsQuery = from sectors in dbContext.Sectors
                                     select sectors;
            var countQuery = from sectors in dbContext.Sectors
                             select sectors;

            // filter the list if needed
            if (! string.IsNullOrEmpty( this.filter.SectorName) )
            {
                candidateSectorsQuery = candidateSectorsQuery.Where(item => item.SectorName.Contains(this.filter.SectorName));
                countQuery = countQuery.Where(item => item.SectorName.Contains(this.filter.SectorName));
            }

            // filter the list if needed
            if ((this.filter.GetParentSectorsOnly.HasValue) && ((this.filter.GetParentSectorsOnly.Value)))
            {
                candidateSectorsQuery = candidateSectorsQuery.Where( item => item.ParentSectorId == null || item.ParentSectorId.Value == 0 );
                countQuery = countQuery.Where( item => item.ParentSectorId == null || item.ParentSectorId.Value == 0 );
            }

            // paginate
            if (this.filter.StartIndex.HasValue && this.filter.Count.HasValue)
            candidateSectorsQuery = candidateSectorsQuery.OrderByDescending(item => item.Id)
                                                         .Skip(this.filter.StartIndex.Value)
                                                         .Take(this.filter.Count.Value);

            // execute the query 
            List<Sector> candidateSectors = candidateSectorsQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();

            response.Sectors = candidateSectors;

            return response;
        }
    }
}
