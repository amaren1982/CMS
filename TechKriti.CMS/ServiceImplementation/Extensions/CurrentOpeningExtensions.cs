using Bussiness.Entities.CurrentOpeningManagement;
using Common.CurrentOpeningManagement;
using Datacontracts.CurrentOpeningManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Extensions.CurrentOpeningManagement
{
    public static class CurrentOpeningExtensions
    {
        public static List<CurrentOpeningDataContract> ToDatacontract(this List<DAL.Datamodel.CurrentOpening> currentOpening)
        {
            List<CurrentOpeningDataContract> dc = new List<CurrentOpeningDataContract>();

            currentOpening.ForEach(item =>
                {                   
                    dc.Add(item.ToDataContract());
                });

            return dc;
        }

        public static CurrentOpeningDataContract ToDataContract(this DAL.Datamodel.CurrentOpening item)
        {
            CurrentOpeningDataContract dcNews = new CurrentOpeningDataContract();

            dcNews.Id = item.Id;
            dcNews.Company = item.Company;
            dcNews.IsActive = item.IsActive;
            dcNews.OpenTillDate = item.OpenTillDate;
            dcNews.Position = item.Position;
            dcNews.SkillSet = item.SkillSet;
            dcNews.Qualification = item.Qualification;
            dcNews.Email = item.Email;

            return dcNews;
        }

        public static ICurrentOpeningSearchFilter ToFilter(this CurrentOpeningSearchFilterDataContract item)
        {
            ICurrentOpeningSearchFilter bussinessEntityFilter = new CurrentOpeningSearchFilter();

            bussinessEntityFilter.Company = item.Company;
            bussinessEntityFilter.Count = item.Count;
            bussinessEntityFilter.Email = item.Email;
            bussinessEntityFilter.IsActive = item.IsActive;
            bussinessEntityFilter.OpenTillDate = item.OpenTillDate;
            bussinessEntityFilter.Position = item.Position;
            bussinessEntityFilter.Qualification = item.Qualification;
            bussinessEntityFilter.SkillSet = item.SkillSet;
            bussinessEntityFilter.StartIndex = item.StartIndex;            

            return bussinessEntityFilter;
        }

        public static ICurrentOpening ToBussinessEntity(this CurrentOpeningDataContract item)
        {
            ICurrentOpening bussinessEntity = new CurrentOpening();

            bussinessEntity.Id = item.Id;
            bussinessEntity.Company = item.Company;
            bussinessEntity.IsActive = item.IsActive;
            bussinessEntity.OpenTillDate = item.OpenTillDate;
            bussinessEntity.Position = item.Position;
            bussinessEntity.SkillSet = item.SkillSet;
            bussinessEntity.Qualification = item.Qualification;
            bussinessEntity.Email = item.Email;

            return bussinessEntity;
        }
    }
}
