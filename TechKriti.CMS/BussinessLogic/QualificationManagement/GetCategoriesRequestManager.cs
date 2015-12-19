using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class GetCategoriesRequestManager
    {
        private ICategorySearchFilter filter = null;
        private TechKritiCMSEntities dbContext = null;

        public GetCategoriesRequestManager(ICategorySearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response 
        { 
            public List<MainCategory> MainCategories { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateCategories = from categories in dbContext.MainCategories                                   
                                      select categories;

            var countQuery = from categories in dbContext.MainCategories
                             select categories;

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.CategoryName))
            {
                candidateCategories = candidateCategories.Where(item => item.Name.Contains(this.filter.CategoryName));
                countQuery = countQuery.Where(item => item.Name.Contains(this.filter.CategoryName));
            }

            if (this.filter.CategoryId.HasValue && this.filter.CategoryId.Value > 0)
            {
                candidateCategories = candidateCategories.Where(i => i.Id == this.filter.CategoryId);
                countQuery = countQuery.Where(i => i.Id == this.filter.CategoryId);
            }

            // paginate
            if( this.filter.Count.HasValue && this.filter.StartIndex.HasValue )
                candidateCategories = candidateCategories.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value)
                                                                                             .Take(this.filter.Count.Value);

            response.MainCategories = candidateCategories.ToList();
            response.TotalNumberofRecords = countQuery.Count();

            return response;
        }
    }
}
