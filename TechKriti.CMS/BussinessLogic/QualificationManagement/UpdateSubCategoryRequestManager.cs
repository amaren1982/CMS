using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class UpdateSubCategoryRequestManager
    {
        ICategory categoryToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public UpdateSubCategoryRequestManager(ICategory categoryToBeCreated)
        {
            this.categoryToBeCreated = categoryToBeCreated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateCategoryQuery = from category in dbContext.Categories
                                             where category.Id == categoryToBeCreated.Id
                                             select category;

            Category candidateCategory = candidateCategoryQuery.First();
            candidateCategory.Name = categoryToBeCreated.Name;
            candidateCategory.Code = categoryToBeCreated.Code;
            candidateCategory.MainCategoryId = categoryToBeCreated.ParentCategoryId;

            dbContext.SaveChanges();
            response.Success = true;

            return response;
        }
    }
}
