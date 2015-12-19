using Common.CurrentOpeningManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.NewsManagement
{
    public class SearchCurrentOpeningsRequestManager
    {
        //private string company;
        //private string position;
        //private string qualification;
        //private string skillSet;
        //private string email;
        //private DateTime? openTillDate;
        //private bool? isActive;
        //private int? startIndex;
        //private int? numberOfRecords;

        ICurrentOpeningSearchFilter filter;

        private TechKritiCMSEntities dbContext = null;

        //public SearchCurrentOpeningsRequestManager(string company, string position, string qualification, string skillSet,
        //                                          string email, DateTime? openTillDate, bool? isActive, int? startIndex, int? numberOfRecords)
        //{
        //    this.company = company;
        //    this.position = position;
        //    this.qualification = qualification;
        //    this.skillSet = skillSet;
        //    this.email = email;
        //    this.openTillDate = openTillDate;
        //    this.isActive = isActive;
        //    this.startIndex = startIndex;
        //    this.numberOfRecords = numberOfRecords;

        //    dbContext = new TechKritiCMSEntities();
        //}

        public SearchCurrentOpeningsRequestManager(ICurrentOpeningSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response 
        { 
            public List<CurrentOpening> CurrentOpenings { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateCurrentOpeningsQuery = from currentOpening in dbContext.CurrentOpenings                                            
                                                select currentOpening;

            var countQuery = from currentOpening in dbContext.CurrentOpenings
                             select currentOpening;

            // filter the list if needed
            if (! (string.IsNullOrEmpty(this.filter.Company)) )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where(item => item.Company.Contains( this.filter.Company) );
                countQuery = countQuery.Where( item => item.Company.Contains(this.filter.Company) );
            }

            // filter the list if needed
            if (! (string.IsNullOrEmpty(this.filter.Email)) )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where( item => item.Email.Contains(this.filter.Email) );
                countQuery = countQuery.Where( item => item.Company.Contains( this.filter.Email) );
            }

            // filter the list if needed
            if ( this.filter.IsActive.HasValue && this.filter.IsActive.Value )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where(item =>  (item.IsActive.HasValue) &&
                                                                                             (item.IsActive == this.filter.IsActive));

                countQuery = countQuery.Where(item => (item.IsActive.HasValue) &&
                                                      (item.IsActive == this.filter.IsActive));
            }

            // filter the list if needed
            if ( this.filter.OpenTillDate.HasValue )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where(item => item.OpenTillDate.Value.Year == this.filter.OpenTillDate.Value.Year &&
                                                                                            item.OpenTillDate.Value.Month == this.filter.OpenTillDate.Value.Month &&
                                                                                            item.OpenTillDate.Value.Day == this.filter.OpenTillDate.Value.Day);

                countQuery = countQuery.Where(item => item.OpenTillDate.Value.Year == this.filter.OpenTillDate.Value.Year &&
                                                      item.OpenTillDate.Value.Month == this.filter.OpenTillDate.Value.Month &&
                                                      item.OpenTillDate.Value.Day == this.filter.OpenTillDate.Value.Day);
            }

            // filter the list if needed
            if (! (string.IsNullOrEmpty(this.filter.Position)) )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where( item => item.Position.Contains(this.filter.Position) );
                countQuery = countQuery.Where( item => item.Position.Contains(this.filter.Position) );
            }

            // filter the list if needed
            if (! (string.IsNullOrEmpty(this.filter.Qualification)) )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where( item => item.Qualification.Contains(this.filter.Qualification) );
                countQuery = countQuery.Where(item => item.Qualification.Contains( this.filter.Qualification) );
            }

            // filter the list if needed
            if (! (string.IsNullOrEmpty(this.filter.SkillSet)) )
            {
                candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.Where(item => item.SkillSet.Contains(this.filter.SkillSet) );
                countQuery = countQuery.Where( item => item.SkillSet.Contains(this.filter.SkillSet) );
            }

            // paginate
            candidateCurrentOpeningsQuery = candidateCurrentOpeningsQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value).
                                                                                            Take(this.filter.Count.Value);

            // execute the query 
            List<CurrentOpening> candidateCurrentOpenings = candidateCurrentOpeningsQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();
            response.CurrentOpenings = candidateCurrentOpenings;    

            return response;
        }
    }
}
