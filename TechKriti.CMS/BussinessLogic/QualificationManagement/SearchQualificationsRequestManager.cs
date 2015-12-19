using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class SearchQualificationsRequestManager
    {
        IQualificationSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchQualificationsRequestManager(IQualificationSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<SelectionCriteria> Qualifications { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateQualificationsQuery = from qualifications in dbContext.SelectionCriterias
                                               select qualifications;
            var countQuery = from qualifications in dbContext.SelectionCriterias
                             select qualifications;

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.Description))
            {
                candidateQualificationsQuery = candidateQualificationsQuery.Where( item => item.Description.Contains(this.filter.Description) );
                countQuery = countQuery.Where(item => item.Description.Contains(this.filter.Description));
            }

            ////// filter the list if needed
            if ( (this.filter.SubCategoryId.HasValue) && ( this.filter.SubCategoryId > 0 ) )
            {
                candidateQualificationsQuery = candidateQualificationsQuery.Where( item => item.SubCategoryId == this.filter.SubCategoryId );
                countQuery = countQuery.Where( item => item.SubCategoryId == this.filter.SubCategoryId  );
            }

            // paginate
            candidateQualificationsQuery = candidateQualificationsQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                        Take(this.filter.Count.Value);

            // execute the query            
            response.TotalNumberofRecords = countQuery.Count();
            response.Qualifications = candidateQualificationsQuery.ToList();

            return response;
        }
    }
}
