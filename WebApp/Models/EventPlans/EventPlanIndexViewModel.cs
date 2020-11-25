using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class EventPlanIndexViewModel
    {
        public List<EventPlanViewModel> EventPlanViewModels { get; set; }

        public List<string> EventNames { get; set; }

        public List<string> OrganNames { get; set; }

        public List<string> EmployeesFIOs { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<string> FilterEventsNames { get; set; }

        public string FilterEventName { get; set; }

        public List<string> FilterEmplFIOs { get; set; }

        public string FilterEmplFIO { get; set; }

        public List<int> Ids { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Название организации")]
        public string OrganizationName { get; set; }

        [Display(Name = "Название события")]
        public string EventName { get; set; }

        [Display(Name = "Начало события")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Конец события")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Планируемый объем")]
        public int PlanVolume { get; set; }

        [Display(Name = "Планируемая стоимость")]
        public decimal PlanCost { get; set; }

        [Display(Name = "Экономический эффект")]
        public double EconomicEffect { get; set; }

        [Display(Name = "ФИО сотрудника")]
        public string EmployeeFIO { get; set; }
    }
}
