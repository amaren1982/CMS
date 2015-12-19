using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class CreateSubCategoryRequestManager
    {
        ICategory categoryToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateSubCategoryRequestManager(ICategory categoryToBeCreated)
        {
            this.categoryToBeCreated = categoryToBeCreated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            Category candidateCatgory = new Category();
            candidateCatgory.Name = categoryToBeCreated.Name;
            candidateCatgory.Code = categoryToBeCreated.Code;
            candidateCatgory.MainCategoryId = categoryToBeCreated.ParentCategoryId;

            dbContext.Categories.Add(candidateCatgory);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
