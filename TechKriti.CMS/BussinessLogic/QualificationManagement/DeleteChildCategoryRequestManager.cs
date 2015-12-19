using Common;
using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.QualificationManagement
{
    public class DeleteChildCategoryRequestManager
    {
        private int categoryID;       
        private TechKritiCMSEntities dbContext = null;

        public DeleteChildCategoryRequestManager(int categoryID)
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

            var selectionCriteriaQuery = from category in dbContext.SelectionCriterias
                                     where category.SubCategoryId == this.categoryID
                                     select category;

            SelectionCriteria selectionCriteria = selectionCriteriaQuery.FirstOrDefault();

            if (selectionCriteria != null)
            {
                response.Success = false;
                response.FailureReasonCode = LogicalErrorCode.CannotDeleteSubCategoryQualificationExists;
            }
            else
            {

                var candidateCategoryQuery = from category in dbContext.SubCategories
                                             where category.Id == this.categoryID
                                             select category;

                SubCategory candidateCategory = candidateCategoryQuery.First();

                dbContext.SubCategories.Remove(candidateCategory);
                dbContext.SaveChanges();

                response.Success = true;
            }

            return response;
        }
    }
}
