using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class DeleteCategoryRequestManager
    {
        private int categoryID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteCategoryRequestManager(int categoryID)
        {
            this.categoryID = categoryID;
            dbContext = new TechKritiCMSEntities();
        }

        public class Response
        {
            public bool Success { get; set; }
            public LogicalErrorCode FailureReasonCode;
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var childCategoryQuery = from childCategory in dbContext.Categories
                                     where childCategory.MainCategoryId == this.categoryID
                                     select childCategory;

            Category childSector = childCategoryQuery.FirstOrDefault();

            if (childSector != null)
            {
                response.Success = false;
                response.FailureReasonCode = LogicalErrorCode.ChildCategoryExists;
            }
            else
            {

                var candidateCategoryQuery = from category in dbContext.MainCategories
                                             where category.Id == this.categoryID
                                             select category;

                MainCategory candidateCategory = candidateCategoryQuery.First();

                dbContext.MainCategories.Remove(candidateCategory);
                dbContext.SaveChanges();

                response.Success = true;
            }

            return response;
        }
    }
}
