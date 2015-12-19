using Datacontracts.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datacontracts.ContentManagement;
using Common.ContentManagement;
using Bussiness.Entities.ContentManagement;

namespace ServiceImplementation.Extensions.ContentManagement
{
    public static class MenusManagementExtensions
    {
        public static List<MenuDataContract> ToDataContract(this List<DAL.Datamodel.Menu> items)
        {
            List<MenuDataContract> dc = new List<MenuDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static MenuDataContract ToDataContract(this DAL.Datamodel.Menu item)
        {
            MenuDataContract dc = new MenuDataContract();

            dc.MenuName = item.MenuName;
            dc.Id = item.Id;
            dc.DisplayOrderId = item.DisplayOrderId;
            dc.IsActive = item.IsActive;
            dc.ParentMenuId = item.ParentMenuId;

            return dc;
        }

        public static IMenu ToBussinessEntity(this MenuDataContract item)
        {
            IMenu bo = new Menu();

            bo.Id = item.Id;
            bo.MenuName = item.MenuName;
            bo.IsActive = item.IsActive;
            bo.ParentMenuId = item.ParentMenuId;
            bo.DisplayOrderId = item.DisplayOrderId;    

            return bo;
        }

        public static IPage ToBussinessEntity(this PageDataContract item)
        {
            IPage bo = new Page();

            bo.Id = item.Id;
            bo.Title = item.Title;
            bo.Content = item.Content;
            bo.CreatedOn = item.CreatedOn;
            bo.MenuId = item.MenuId;
            bo.Status = item.Status;
            bo.CreatedBy = item.CreatedBy;
            bo.Description = item.Description;
            bo.H1 = item.H1;
            bo.H2 = item.H2;
            bo.SeoTitle = item.SeoTitle;
            bo.MetaKeys = item.MetaKeys;

            return bo;
        }

        public static IMenuSearchFilter ToFilter(this MenuSearchFilterDataContract item)
        {
            IMenuSearchFilter filter = new MenuSearchFilter();

            filter.Count = item.Count;
            filter.MenuName = item.MenuName;
            filter.StartIndex = item.StartIndex;
            filter.IsActive = item.IsActive;

            return filter;
        }      

        public static IPageSearchFilter ToFilter(this PageSearchFilterDataContract item)
        {
            IPageSearchFilter filter = new PageSearchFilter();

            filter.Count = item.Count;
            filter.Title = item.Title;
            filter.StartIndex = item.StartIndex;
            filter.Status = item.Status;

            return filter;
        }

        public static List<PageDataContract> ToDataContract(this List<DAL.Datamodel.Page> items)
        {
            List<PageDataContract> dc = new List<PageDataContract>();

            items.ForEach(item => dc.Add(item.ToDataContract()));

            return dc;
        }

        public static PageDataContract ToDataContract(this DAL.Datamodel.Page item)
        {
            PageDataContract dc = new PageDataContract();

            dc.Title = item.Title;
            dc.Id = item.Id;
            dc.Content = item.Content;
            dc.MenuId = item.MenuId;
            dc.CreatedBy = item.CreatedBy;
            dc.CreatedOn = item.CreatedOn;
            dc.Status = item.Status == 1 ? PageStatus.Draft : PageStatus.Published;
            dc.Description = item.Description;
            dc.H1 = item.H1;
            dc.H2 = item.H2;
            dc.SeoTitle = item.SeoTitle;
            dc.MetaKeys = item.MetaKeys;

            return dc;
        }
    }
}
