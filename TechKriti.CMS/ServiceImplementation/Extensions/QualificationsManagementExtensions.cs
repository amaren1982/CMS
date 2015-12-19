using Bussiness.Entities.QualificationManagement;
using Common.QualificaionManagement;
using Datacontracts.QualificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Extensions.QualificationsManagement
{
    public static class QualificationsManagementExtensions
    {
        public static List<QualificationDataContract> ToDataContract(this List<DAL.Datamodel.SelectionCriteria> items)
        {
            List<QualificationDataContract> dc = new List<QualificationDataContract>();

            items.ForEach( i => dc.Add(i.ToDataContract()) );

            return dc;
        }

        public static QualificationDataContract ToDataContract(this DAL.Datamodel.SelectionCriteria item)
        {
            QualificationDataContract dc = new QualificationDataContract();

            dc.Id = item.Id;
            dc.Description = item.Description;            
            dc.ChildCategoryId = item.SubCategoryId;

            return dc;
        }


        public static List<CategoryDataContract> ToDataContract(this List<DAL.Datamodel.MainCategory> items)
        {
            List<CategoryDataContract> dc = new List<CategoryDataContract>();

            items.ForEach(i => dc.Add(i.ToDataContract()));

            return dc;
        }

        public static CategoryDataContract ToDataContract(this DAL.Datamodel.MainCategory item)
        {
            CategoryDataContract dc = new CategoryDataContract();

            dc.Id = item.Id;
            dc.Name = item.Name;              

            return dc;
        }

        public static List<CategoryDataContract> ToDataContract(this List<DAL.Datamodel.Category> items)
        {
            List<CategoryDataContract> dc = new List<CategoryDataContract>();

            items.ForEach(i => dc.Add(i.ToDataContract()));

            return dc;
        }

        public static List<CategoryDataContract> ToDataContract(this List<DAL.Datamodel.SubCategory> items)
        {
            List<CategoryDataContract> dc = new List<CategoryDataContract>();

            items.ForEach(i => dc.Add(i.ToDataContract()));

            return dc;
        }

        public static CategoryDataContract ToDataContract(this DAL.Datamodel.Category item)
        {
            CategoryDataContract dc = new CategoryDataContract();

            dc.Id = item.Id;
            dc.Name = item.Name;
            dc.ParentCategoryId = item.MainCategoryId;
            dc.Code = item.Code;

            return dc;
        }

        public static CategoryDataContract ToDataContract(this DAL.Datamodel.SubCategory item)
        {
            CategoryDataContract dc = new CategoryDataContract();

            dc.Id = item.Id;
            dc.Name = item.Name;
            dc.ParentCategoryId = item.CategoryId;
            dc.Code = item.Code;

            return dc;
        }

        public static IQualification ToBussinessEntity(this QualificationDataContract item)
        {
            IQualification bo = new Qualification();

            bo.Id = item.Id;
            bo.Description = item.Description;
            bo.ChildCategoryId = item.ChildCategoryId;           

            return bo;
        }

        public static ICategory ToBussinessEntity(this CategoryDataContract item)
        {
            ICategory bo = new Category();

            bo.Id = item.Id;
            bo.Name = item.Name;
            bo.Code = item.Code;
            bo.ParentCategoryId = item.ParentCategoryId;           

            return bo;
        }

        public static IQualificationSearchFilter ToFilter(this QualificationSearchDataContract item)
        {
            IQualificationSearchFilter filter = new QualificationSearchFilter();

            filter.Count = item.Count;           
            filter.StartIndex = item.StartIndex;
            filter.Description = item.Description;
            filter.Id = item.Id;
            filter.SubCategoryId = item.SubCategoryId;           

            return filter;
        }

        public static ICategorySearchFilter ToFilter(this CategorySearchDataContract item)
        {
            ICategorySearchFilter filter = new CategorySearchFilter();

            filter.Count = item.Count;
            filter.StartIndex = item.StartIndex;
            filter.CategoryId = item.CategoryId;
            filter.ParentCategoryId = item.ParentCategoryId;
            filter.CategoryName = item.CategoryName;
            filter.CategoryCode = item.CategoryCode;
        
            return filter;
        }
    }
}
