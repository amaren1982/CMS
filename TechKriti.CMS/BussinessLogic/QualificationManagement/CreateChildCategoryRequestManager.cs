using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class CreateChildCategoryRequestManager
    {
        ICategory categoryToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateChildCategoryRequestManager(ICategory categoryToBeCreated)
        {
            this.categoryToBeCreated = categoryToBeCreated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            SubCategory candidateCatgory = new SubCategory();
            candidateCatgory.Name = categoryToBeCreated.Name;
            candidateCatgory.Code = categoryToBeCreated.Code;
            candidateCatgory.CategoryId = categoryToBeCreated.ParentCategoryId;

            dbContext.SubCategories.Add(candidateCatgory);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
