using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SourceIndexViewModel
    {
        public List<SourceViewModel> SourceViewModels { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<string> OrganNames { get; set; }

        public List<string> FilterOrganNames { get; set; }

        public string FilterOrganName { get; set; }

        public string FilterSuperOrganName { get; set; }

        public List<int> Ids { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Название организации")]
        public string OrganizationName { get; set; }

        [Display(Name = "Фонд организации")]
        public decimal OrganizationFunds { get; set; }

        [Display(Name = "Название вышестоящей организации")]
        public string SuperiorOrganizationName { get; set; }

        [Display(Name = "Фонд вышестоящей организации")]
        public decimal SuperiorOrganizationFunds { get; set; }

        [Display(Name = "Фонд Министерства Энергетики")]
        public decimal MinistryOfEnergyFund { get; set; }

        [Display(Name = "Республиканский бюджет")]
        public decimal RepublicBudget { get; set; }

        [Display(Name = "Местный бюджет")]
        public decimal LocalBudget { get; set; }
    }
}
