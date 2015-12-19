using Common.NewsManagement;
using Common.SectorsManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.SectionManagement;

namespace BussinessLogic.SectionManagement
{
    public class SearchSectionsRequestManager
    {
        private ISectionSearchFilter filter = null;
        private TechKritiCMSEntities dbContext = null;

        public SearchSectionsRequestManager(ISectionSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<SectionMaster> Sections { get; set; }            
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateSectionsQuery = from sections in dbContext.SectionMasters
                                         select sections;           
           
            candidateSectionsQuery = candidateSectionsQuery.Where(item => item.SectionType == (int)this.filter.SectionType);
            response.Sections = candidateSectionsQuery.ToList();

            return response;
        }
    }
}
