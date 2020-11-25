using System;

namespace WebApp.Models
{
    // Класс модели представления записи из таблицы Планы событий
    public class EventPlanViewModel
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlanVolume { get; set; }
        public decimal PlanCost { get; set; }
        public double EconomicEffect { get; set; }
        public string EmployeeFIO { get; set; }
    }
}
