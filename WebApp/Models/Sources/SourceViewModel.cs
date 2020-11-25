using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    // Класс модели представления записи из таблицы Источники
    public class SourceViewModel
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public decimal OrganizationFunds { get; set; }
        public string SuperiorOrganizationName { get; set; }
        public decimal SuperiorOrganizationFunds { get; set; }
        public decimal MinistryOfEnergyFund { get; set; }
        public decimal RepublicBudget { get; set; }
        public decimal LocalBudget { get; set; }
    }
}
