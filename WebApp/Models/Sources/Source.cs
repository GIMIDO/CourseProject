using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    // Класс, представляющий собой модель записи в таблице Источники
    public class Source
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public decimal OrganizationFunds { get; set; }
        public int SuperiorOrganization { get; set; }
        public decimal SuperiorOrganizationFunds { get; set; }
        public decimal MinistryOfEnergyFund { get; set; }
        public decimal RepublicBudget { get; set; }
        public decimal LocalBudget { get; set; }
        public Source(){}
    }
}
