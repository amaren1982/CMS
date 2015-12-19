using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class GetChildCategoriesRequestManager
    {
        private ICategorySearchFilter filter = null;
        private TechKritiCMSEntities dbContext = null;

        public GetChildCategoriesRequestManager(ICategorySearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response
        {
            public List<SubCategory> ChildCategories { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateSubCategories = from subCategories in dbContext.SubCategories                                       
                                         select subCategories;

            var countQuery = from categories in dbContext.SubCategories
                             select categories;

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.CategoryName))
            {
                candidateSubCategories = candidateSubCategories.Where(item => item.Name.Contains(this.filter.CategoryName));
                countQuery = countQuery.Where(item => item.Name.Contains(this.filter.CategoryName));
            }

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.CategoryCode))
            {
                candidateSubCategories = candidateSubCategories.Where(item => item.Code.Contains(this.filter.CategoryCode));
                countQuery = countQuery.Where(item => item.Code.Contains(this.filter.CategoryCode));
            }

            // filter the list if needed
            if (this.filter.CategoryId.HasValue)
            {
                candidateSubCategories = candidateSubCategories.Where(item => (item.Id == this.filter.CategoryId.Value));
                countQuery = countQuery.Where(item => (item.Id == this.filter.CategoryId.Value));
            }


            // filter the list if needed
            if (this.filter.ParentCategoryId.HasValue)
            {
                candidateSubCategories = candidateSubCategories.Where(item => (item.CategoryId == this.filter.ParentCategoryId.Value));

                countQuery = countQuery.Where(item => (item.CategoryId == this.filter.ParentCategoryId.Value));
            }            

            // paginate
            if (this.filter.Count.HasValue && this.filter.StartIndex.HasValue)
                candidateSubCategories = candidateSubCategories.OrderByDescending(item => item.Id)
                                                                .Skip(this.filter.StartIndex.Value)
                                                                .Take(this.filter.Count.Value);

            response.ChildCategories = candidateSubCategories.ToList();
            response.TotalNumberofRecords = countQuery.Count();

            return response;
        }
    }
}
