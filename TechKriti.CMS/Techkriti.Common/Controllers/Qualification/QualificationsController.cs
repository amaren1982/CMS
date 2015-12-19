using Datacontracts.Misc;
using Datacontracts.QualificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Techkriti.Common.Proxy;

namespace Techkriti.Common.Controllers.Qualification
{
    public class QualificationsController
    {
        #region Qualification CRUD

        public static bool SaveQualification(QualificationDataContract qualificationToBeSaved)
        {
            try
            {
                if (qualificationToBeSaved.Id > 0) return UpdateQualification(qualificationToBeSaved);
                else return AddQualification(qualificationToBeSaved);
            }
            catch (Exception ex)
            {
               //TO DO LOG 
                throw;
            }
        }

        public static bool AddQualification(QualificationDataContract qualificationToBeSaved)
        {
            CreateQualificationRequest request = new CreateQualificationRequest();
            EmptyResponse response = null;
            request.QualificationToBeSaved = qualificationToBeSaved;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.CreateQualification(request);
            }

            return response.Success;
        }

        public static bool UpdateQualification(QualificationDataContract qualificationToBeUpdated)
        {
            UpdateQualificationRequest request = new UpdateQualificationRequest();
            request.QualificationToBeSaved = qualificationToBeUpdated;

            EmptyResponse response = null;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.UpdateQualification(request);
            }

            return response.Success;
        }

        public static bool DeleteQualification(int qualificationId)
        {
            try
            {
                DeleteQualificationRequest request = new DeleteQualificationRequest();
                EmptyResponse response = null;
                request.QualificationId = qualificationId;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteQualification(request);
                }

                return response.Success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static QualificationDataContract GetQualificationById(int qualificationId)
        {
            GetQualificationByIdRequest request = new GetQualificationByIdRequest();
            request.QualificationId = qualificationId;
            GetQualificationByIdResponse response = null;

            try
            {
                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetQualificationById(request);
                }

                return response.Qualification;

            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                return null;
            }
        }

        #endregion

        #region Category CRUD

        public static bool SaveCategory(CategoryDataContract categoryToBeSaved)
        {
            try
            {
                if (categoryToBeSaved.Id > 0) return UpdateCategory(categoryToBeSaved);
                else return AddCategory(categoryToBeSaved);
            }
            catch (Exception ex)
            {
                //TO DO LOG 
                throw;
            }
        }

        public static bool AddCategory(CategoryDataContract categoryToBeSaved)
        {
            CreateCategoryRequest request = new CreateCategoryRequest();
            EmptyResponse response = null;
            request.CategoryToBeSaved = categoryToBeSaved;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.CreateCategory(request);
            }

            return response.Success;
        } 

        public static bool UpdateCategory(CategoryDataContract categoryToBeUpdated)
        {
            UpdateCategoryRequest request = new UpdateCategoryRequest();
            request.CategoryToBeSaved = categoryToBeUpdated;

            EmptyResponse response = null;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.UpdateCategory(request);
            }

            return response.Success;
        }

        public static bool DeleteCategory(int categoryId, out string errorMessage)
        {
            DeleteCategoryRequest request = new DeleteCategoryRequest();
            request.CategoryId = categoryId;
            DeleteCategoryResponse response = null;

            try
            {
                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteCategory(request);
                }

                errorMessage = response.FailureReason.ToString();
                return response.IsDeleted;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static CategoryDataContract GetCategoryById(int categoryId)
        {
            try
            {
                GetCategoriesRequest request = new GetCategoriesRequest();
                request.Filter = new CategorySearchDataContract();
                request.Filter.CategoryId = categoryId;

                GetCategoriesResponse response = null;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetCategories(request);
                }

                return response.Categories != null ? response.Categories.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }


        #endregion

        #region SubCategory CRUD

        public static bool SaveSubCategory(CategoryDataContract categoryToBeSaved)
        {
            try
            {
                if (categoryToBeSaved.Id > 0) return UpdateSubCategory(categoryToBeSaved);
                else return AddSubCategory(categoryToBeSaved);
            }
            catch (Exception ex)
            {
                //TO DO LOG 
                throw;
            }
        }

        public static bool AddSubCategory(CategoryDataContract categoryToBeSaved)
        {
            CreateCategoryRequest request = new CreateCategoryRequest();
            EmptyResponse response = null;
            request.CategoryToBeSaved = categoryToBeSaved;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.CreateSubCategory(request);
            }

            return response.Success;
        }

        public static bool UpdateSubCategory(CategoryDataContract categoryToBeUpdated)
        {
            UpdateCategoryRequest request = new UpdateCategoryRequest();
            request.CategoryToBeSaved = categoryToBeUpdated;

            EmptyResponse response = null;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.UpdateSubCategory(request);
            }

            return response.Success;
        }

        public static bool DeleteSubCategory(int categoryId, out string errorMessage)
        {
            DeleteCategoryRequest request = new DeleteCategoryRequest();
            request.CategoryId = categoryId;
            DeleteCategoryResponse response = null;

            try
            {
                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteSubCategory(request);
                }

                errorMessage = response.FailureReason.ToString();
                return response.IsDeleted;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static CategoryDataContract GetSubCategoryById(int categoryId)
        {
            try
            {
                GetSubCategoriesRequest request = new GetSubCategoriesRequest();
                request.Filter = new CategorySearchDataContract();
                request.Filter.CategoryId = categoryId;

                GetSubCategoriesResponse response = null;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetSubCategories(request);
                }

                return response.Categories != null ? response.Categories.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static CategoryDataContract GetChildCategoryById(int categoryId)
        {
            try
            {
                GetChildCategoriesRequest request = new GetChildCategoriesRequest();
                request.Filter = new CategorySearchDataContract();
                request.Filter.CategoryId = categoryId;

                GetChildCategoriesResponse response = null;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetChildCategories(request);
                }

                return response.Categories != null ? response.Categories.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }


        #endregion

        #region Child Category CRUD

        public static bool SaveChildCategory(CategoryDataContract categoryToBeSaved)
        {
            try
            {
                if (categoryToBeSaved.Id > 0) return UpdateChildCategory(categoryToBeSaved);
                else return AddChildCategory(categoryToBeSaved);
            }
            catch (Exception ex)
            {
                //TO DO LOG 
                throw;
            }
        }

        public static bool AddChildCategory(CategoryDataContract categoryToBeSaved)
        {
            CreateCategoryRequest request = new CreateCategoryRequest();
            EmptyResponse response = null;
            request.CategoryToBeSaved = categoryToBeSaved;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.CreateChildCategory(request);
            }

            return response.Success;
        }

        public static bool UpdateChildCategory(CategoryDataContract categoryToBeUpdated)
        {
            UpdateCategoryRequest request = new UpdateCategoryRequest();
            request.CategoryToBeSaved = categoryToBeUpdated;

            EmptyResponse response = null;

            using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
            {
                response = client.ServiceChannel.UpdateChildCategory(request);
            }

            return response.Success;
        }

        public static bool DeleteChildCategory(int categoryId, out string errorMessage)
        {
            DeleteCategoryRequest request = new DeleteCategoryRequest();
            request.CategoryId = categoryId;
            DeleteCategoryResponse response = null;

            try
            {
                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.DeleteChildCategory(request);
                }

                errorMessage = response.FailureReason.ToString();
                return response.IsDeleted;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        #endregion
          
        public static List<QualificationDataContract> SearchQualifications(string description, int? subCategoryId , int startIndex, int count,
                                                             out int totalNumnerOfRecords)
        {
            try
            {
                SearchQualificationsRequest request = new SearchQualificationsRequest();
                SearchQualificationsResponse response = null;

                QualificationSearchDataContract filter = new QualificationSearchDataContract();
                filter.StartIndex = startIndex;
                filter.Count = count;
                filter.Description = description;
                filter.SubCategoryId = subCategoryId;
                request.Filter = filter;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.SearchQualifications(request);
                }

                totalNumnerOfRecords = response.Count;
                return response.Qualifications;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }       

        public static List<CategoryDataContract> GetCategories( string categoryName, int? startIndex, int? count, out int totalNumberOfRecords)
        {
            try
            {
                GetCategoriesRequest request = new GetCategoriesRequest();
                request.Filter = new CategorySearchDataContract();
                request.Filter.Count = count;
                request.Filter.StartIndex = startIndex;
                request.Filter.CategoryName = categoryName;

                GetCategoriesResponse response = null;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetCategories(request);
                }

                totalNumberOfRecords = response.Count;
                return response.Categories;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<CategoryDataContract> GetCategories()
        {
            int totalNumberOfRecords = 0;
            return GetCategories(string.Empty, default(Nullable<int>), default(Nullable<int>), out totalNumberOfRecords);
        }

        public static List<CategoryDataContract> GetSubCategories( string subCategoryName, string subCategoryCode, int? startIndex, int? count, 
                                                                    int? parentCategoryId, out int totalNumberOfRecords)
        {
            try
            {
                GetSubCategoriesRequest request = new GetSubCategoriesRequest();
                request.Filter = new CategorySearchDataContract();
                request.Filter.ParentCategoryId = parentCategoryId;
                request.Filter.StartIndex = startIndex;
                request.Filter.Count = count;
                request.Filter.CategoryName = subCategoryName;
                request.Filter.CategoryCode = subCategoryCode;
                GetSubCategoriesResponse response = null;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetSubCategories(request);
                }

                totalNumberOfRecords = response.Count;
                return response.Categories;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<CategoryDataContract> GetChildCategories( string childCategoryName, string childCategoryCode, 
                                                                     int? startIndex, int? count, int? parentCategoryId, out int totalNumberOfRecords)
        {
            try
            {
                GetChildCategoriesRequest request = new GetChildCategoriesRequest();
                request.Filter = new CategorySearchDataContract();
                request.Filter.ParentCategoryId = parentCategoryId;
                request.Filter.StartIndex = startIndex;
                request.Filter.Count = count;
                request.Filter.CategoryName = childCategoryName;
                request.Filter.CategoryCode = childCategoryCode;
                GetChildCategoriesResponse response = null;

                using (QualificationsManagementClient client = ProxyFactory.CreateQualificationsManagementProxy())
                {
                    response = client.ServiceChannel.GetChildCategories(request);
                }

                totalNumberOfRecords = response.Count;
                return response.Categories;
            }
            catch (Exception ex)
            {
                //TO DO LOG EXCEPTION
                throw;
            }
        }

        public static List<CategoryDataContract> GetSubCategories(int? parentCategoryId, out int totalNumberOfRecords)
        {
            return GetSubCategories( string.Empty, string.Empty, default(Nullable<int>), default(Nullable<int>), parentCategoryId, out totalNumberOfRecords);
        }

        public static List<CategoryDataContract> GetChildCategories(int? parentCategoryId, out int totalNumberOfRecords)
        {
            return GetChildCategories( string.Empty, string.Empty, default(Nullable<int>), default(Nullable<int>), parentCategoryId, out totalNumberOfRecords);
        }
    }
}