using System;
using System.ComponentModel.DataAnnotations;

namespace ContextLibrary.Domain_Entities
{
    public class Source
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public decimal OrganizationFunds { get; set; }
        public int SuperiorOrganization { get; set; }
        public decimal SuperiorOrganizationFunds { get; set; }
        public decimal MinistryOfEnergyFunds { get; set; }
        public decimal RepublicBudget { get; set; }
        public decimal LocalBudget { get; set; }
        public Source() { }
        public Source(int id, int organId, decimal organFunds, int superOrganId, decimal superOrganFunds, decimal minFunds, decimal repFunds, decimal localFunds)
        {
            Id = id;
            OrganizationId = organId;
            OrganizationFunds = organFunds;
            SuperiorOrganization = superOrganId;
            SuperiorOrganizationFunds = superOrganFunds;
            MinistryOfEnergyFunds = minFunds;
            RepublicBudget = repFunds;
            LocalBudget = localFunds;
        }
    }
}
