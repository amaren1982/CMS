using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class UpdateChildCategoryRequestManager
    {
        ICategory categoryToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateChildCategoryRequestManager(ICategory categoryToBeCreated)
        {
            this.categoryToBeCreated = categoryToBeCreated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateCategoryQuery = from category in dbContext.SubCategories
                                             where category.Id == categoryToBeCreated.Id
                                             select category;

            SubCategory candidateCategory = candidateCategoryQuery.First();
            candidateCategory.Name = categoryToBeCreated.Name;
            candidateCategory.Code = categoryToBeCreated.Code;
            candidateCategory.CategoryId = categoryToBeCreated.ParentCategoryId;

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
