using Common.QualificaionManagement;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class CreateCategoryRequestManager
    {
        ICategory categoryToBeCreated;
        private TechKritiCMSEntities dbContext = null;

        public CreateCategoryRequestManager(ICategory categoryToBeCreated)
        {
            this.categoryToBeCreated = categoryToBeCreated;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response { public bool Success { get; set; } }

        public Response ProcessRequest()
        {
            Response response = new Response();

            MainCategory candidateCatgory = new MainCategory();
            candidateCatgory.Name = categoryToBeCreated.Name;

            dbContext.MainCategories.Add(candidateCatgory);
            dbContext.SaveChanges();

            response.Success = true;

            return response;
        }
    }
}
