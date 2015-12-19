using Datacontracts.Misc;
using Datacontracts.QualificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
   [ServiceContract]
    public interface IQualificationsManagement
    {
       [OperationContract]
       EmptyResponse CreateQualification(CreateQualificationRequest request);

       [OperationContract]
       EmptyResponse UpdateQualification(UpdateQualificationRequest request);

       [OperationContract]
       EmptyResponse DeleteQualification(DeleteQualificationRequest request);

       [OperationContract]
       SearchQualificationsResponse SearchQualifications(SearchQualificationsRequest request);

       [OperationContract]
       GetQualificationByIdResponse GetQualificationById(GetQualificationByIdRequest request);

       [OperationContract]
       GetCategoriesResponse GetCategories(GetCategoriesRequest request);

       [OperationContract]
       GetSubCategoriesResponse GetSubCategories(GetSubCategoriesRequest request);

       [OperationContract]
       GetChildCategoriesResponse GetChildCategories(GetChildCategoriesRequest request);

       [OperationContract]
       EmptyResponse CreateCategory(CreateCategoryRequest request);

       [OperationContract]
       EmptyResponse UpdateCategory(UpdateCategoryRequest request);

       [OperationContract]
       DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request);

       [OperationContract]
       EmptyResponse CreateSubCategory(CreateCategoryRequest request);

       [OperationContract]
       EmptyResponse UpdateSubCategory(UpdateCategoryRequest request);

       [OperationContract]
       DeleteCategoryResponse DeleteSubCategory(DeleteCategoryRequest request);

       [OperationContract]
       EmptyResponse CreateChildCategory(CreateCategoryRequest request);

       [OperationContract]
       EmptyResponse UpdateChildCategory(UpdateCategoryRequest request);

       [OperationContract]
       DeleteCategoryResponse DeleteChildCategory(DeleteCategoryRequest request);
    }
}
