using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class DeleteSubCategoryRequestManager
    {
        private int categoryID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteSubCategoryRequestManager(int categoryID)
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

            var selectionCriteriaQuery = from category in dbContext.SubCategories
                                     where category.CategoryId == this.categoryID
                                     select category;

            SubCategory selectionCriteria = selectionCriteriaQuery.FirstOrDefault();

            if (selectionCriteria != null)
            {
                response.Success = false;
                response.FailureReasonCode = LogicalErrorCode.ChildCategoryExists;
            }
            else
            {

                var candidateCategoryQuery = from category in dbContext.Categories
                                             where category.Id == this.categoryID
                                             select category;

                Category candidateCategory = candidateCategoryQuery.First();

                dbContext.Categories.Remove(candidateCategory);
                dbContext.SaveChanges();

                response.Success = true;
            }

            return response;
        }
    }
}
