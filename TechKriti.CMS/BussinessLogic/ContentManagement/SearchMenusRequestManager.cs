using DAL.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ContentManagement;

namespace BussinessLogic.ContentMangement
{
    public class SearchMenusRequestManager
    {
        IMenuSearchFilter filter;   
        private TechKritiCMSEntities dbContext = null;

        public SearchMenusRequestManager(IMenuSearchFilter filter)
        {
            this.filter = filter;
            dbContext = new TechKritiCMSEntities();
        }        

        public class Response
        {
            public List<Menu> Menus { get; set; }
            public int TotalNumberofRecords { get; set; }
        }

        public Response ProcessRequest()
        {
            Response response = new Response();

            var candidateMenusQuery = from menu in dbContext.Menus
                                      select menu;
            var countQuery = from menu in dbContext.Menus                             
                             select menu;

            // filter the list if needed
            if (!string.IsNullOrEmpty(this.filter.MenuName))
            {
                candidateMenusQuery = candidateMenusQuery.Where(item => item.MenuName.Contains(this.filter.MenuName));
                countQuery = countQuery.Where(item => item.MenuName.Contains(this.filter.MenuName));
            }

            // filter the list if needed
            if (this.filter.IsActive.HasValue && this.filter.IsActive.Value)
            {
                candidateMenusQuery = candidateMenusQuery.Where(item => (item.IsActive.HasValue) &&
                                                                      (item.IsActive == this.filter.IsActive));

                countQuery = countQuery.Where(item => (item.IsActive.HasValue) &&
                                                      (item.IsActive == this.filter.IsActive));
            }

            // paginate
            if (this.filter.StartIndex.HasValue && this.filter.Count.HasValue)
                candidateMenusQuery = candidateMenusQuery.OrderByDescending(item => item.Id).Skip(this.filter.StartIndex.Value)
                                                                                            .Take(this.filter.Count.Value);

            response.Menus = candidateMenusQuery.ToList();
            response.TotalNumberofRecords = countQuery.Count();  
           
            return response;
        }
    }
}
