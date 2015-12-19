using BussinessLogic.QualificationManagement;
using Datacontracts.Misc;
using Datacontracts.QualificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceImplementation.Extensions.QualificationsManagement;

namespace ServiceInterface.ServiceImplementation.QualificationManagement
{
    public class QualificationsManagementServiceImpl : IQualificationsManagement
    {
        public EmptyResponse CreateQualification(CreateQualificationRequest request)
        {
            try
            {
                CreateQualificationRequestManager requestManger = new CreateQualificationRequestManager( request.QualificationToBeSaved.ToBussinessEntity() );
                CreateQualificationRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse UpdateQualification(UpdateQualificationRequest request)
        {
            try
            {
                UpdateQualificationRequestManager requestManger = new UpdateQualificationRequestManager( request.QualificationToBeSaved.ToBussinessEntity() );
                UpdateQualificationRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse DeleteQualification(DeleteQualificationRequest request)
        {
            try
            {
                DeleteQualificationRequestManager requestManger = new DeleteQualificationRequestManager( request.QualificationId );
                DeleteQualificationRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = bllResponse.Success;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public SearchQualificationsResponse SearchQualifications(SearchQualificationsRequest request)
        {
            try
            {
                SearchQualificationsRequestManager requestManger = new SearchQualificationsRequestManager( request.Filter.ToFilter() );
                SearchQualificationsRequestManager.Response bllResponse = requestManger.ProcessRequest();

                SearchQualificationsResponse response = new SearchQualificationsResponse();
                response.Qualifications = bllResponse.Qualifications.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetQualificationByIdResponse GetQualificationById(GetQualificationByIdRequest request)
        {
            try
            {
                GetQualificationByIdRequestManager requestManger = new GetQualificationByIdRequestManager(request.QualificationId);
                GetQualificationByIdRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetQualificationByIdResponse response = new GetQualificationByIdResponse();
                response.Qualification = bllResponse.Qualification.ToDataContract();
                response.Qualification.Category =  bllResponse.Qualification.SubCategory.ToDataContract();

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetCategoriesResponse GetCategories(GetCategoriesRequest request)
        {
            try
            {
                GetCategoriesRequestManager requestManger = new GetCategoriesRequestManager( request.Filter.ToFilter() );
                GetCategoriesRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetCategoriesResponse response = new GetCategoriesResponse();
                response.Categories = bllResponse.MainCategories.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetSubCategoriesResponse GetSubCategories(GetSubCategoriesRequest request)
        {
            try
            {
                GetSubCategoriesRequestManager requestManger = new GetSubCategoriesRequestManager(request.Filter.ToFilter());
                GetSubCategoriesRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetSubCategoriesResponse response = new GetSubCategoriesResponse();
                response.Categories = bllResponse.SubCategories.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public GetChildCategoriesResponse GetChildCategories(GetChildCategoriesRequest request)
        {
            try
            {
                GetChildCategoriesRequestManager requestManger = new GetChildCategoriesRequestManager(request.Filter.ToFilter());
                GetChildCategoriesRequestManager.Response bllResponse = requestManger.ProcessRequest();

                GetChildCategoriesResponse response = new GetChildCategoriesResponse();
                response.Categories = bllResponse.ChildCategories.ToDataContract();
                response.Count = bllResponse.TotalNumberofRecords;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse CreateCategory(CreateCategoryRequest request)
        {
            try
            {
                CreateCategoryRequestManager requestManger = new CreateCategoryRequestManager(request.CategoryToBeSaved.ToBussinessEntity());
                CreateCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse CreateSubCategory(CreateCategoryRequest request)
        {
            try
            {
                CreateSubCategoryRequestManager requestManger = new CreateSubCategoryRequestManager(request.CategoryToBeSaved.ToBussinessEntity());
                CreateSubCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse CreateChildCategory(CreateCategoryRequest request)
        {
            try
            {
                CreateChildCategoryRequestManager requestManger = new CreateChildCategoryRequestManager(request.CategoryToBeSaved.ToBussinessEntity());
                CreateChildCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse UpdateCategory(UpdateCategoryRequest request)
        {
            try
            {
                UpdateCategoryRequestManager requestManger = new UpdateCategoryRequestManager(request.CategoryToBeSaved.ToBussinessEntity());
                UpdateCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }


        public EmptyResponse UpdateSubCategory(UpdateCategoryRequest request)
        {
            try
            {
                UpdateSubCategoryRequestManager requestManger = new UpdateSubCategoryRequestManager(request.CategoryToBeSaved.ToBussinessEntity());
                UpdateSubCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public EmptyResponse UpdateChildCategory(UpdateCategoryRequest request)
        {
            try
            {
                UpdateChildCategoryRequestManager requestManger = new UpdateChildCategoryRequestManager(request.CategoryToBeSaved.ToBussinessEntity());
                UpdateChildCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                EmptyResponse response = new EmptyResponse();
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request)
        {
            try
            {
                DeleteCategoryRequestManager requestManger = new DeleteCategoryRequestManager(request.CategoryId);
                DeleteCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                DeleteCategoryResponse response = new DeleteCategoryResponse();
                response.IsDeleted = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public DeleteCategoryResponse DeleteSubCategory(DeleteCategoryRequest request)
        {
            try
            {
                DeleteSubCategoryRequestManager requestManger = new DeleteSubCategoryRequestManager(request.CategoryId);
                DeleteSubCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                DeleteCategoryResponse response = new DeleteCategoryResponse();
                response.IsDeleted = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }

        public DeleteCategoryResponse DeleteChildCategory(DeleteCategoryRequest request)
        {
            try
            {
                DeleteChildCategoryRequestManager requestManger = new DeleteChildCategoryRequestManager(request.CategoryId);
                DeleteChildCategoryRequestManager.Response bllResponse = requestManger.ProcessRequest();

                DeleteCategoryResponse response = new DeleteCategoryResponse();
                response.IsDeleted = bllResponse.Success;
                response.FailureReason = bllResponse.FailureReasonCode;

                return response;
            }
            catch (Exception ex)
            {
                //TO DO  -  logg exception somewhere
                throw;
            }
        }
    }
}
