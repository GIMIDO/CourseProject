using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class EventPlanController : Controller
    {
        // Объект контекста данных
        private readonly ApplicationDBContext db;

        public EventPlanController(ApplicationDBContext applicationContext)
        {
            db = applicationContext;
        }

        // Метод получения страницы клиентов.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string eventName = "Все", string emplFIO = "Все")
        {
            return View(GetViewModel(page, eventName, emplFIO));
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public IActionResult AddEventPlan(EventPlanIndexViewModel model)
        {
            ViewData["Message"] = "";
            if (model.PlanVolume <= 0)
            {
                ViewData["Message"] += "Неправильное значение планируемого объема";
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
            else if (model.EconomicEffect <= 0)
            {
                ViewData["Message"] += "Неправильное значение экономического эффекта";
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
            else if (model.PlanCost <= 0)
            {
                ViewData["Message"] += "Неправильное значение планируемой стоимости";
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
            else
            {
                var id = 0;
                if (db.EventPlans.Count() != 0)
                {
                    id = db.EventPlans.Select(item => item.Id).Max();
                }
                id++;
                db.EventPlans.Add(new EventPlan()
                {
                    Id = id,
                    EndDate = model.EndDate,
                    StartDate = model.StartDate,
                    EconomicEffect = model.EconomicEffect,
                    EmployeeId = db.Employees.Where(item => item.FIO == model.EmployeeFIO).First().Id,
                    EventId = db.Events.Where(item => item.Name == model.EventName).First().Id,
                    OrganizationId = db.Organizations.Where(item => item.Name == model.OrganizationName).First().Id,
                    PlanCost = model.PlanCost,
                    PlanVolume = model.PlanVolume
                });
                db.SaveChanges();
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public IActionResult DeleteEventPlan(EventPlanIndexViewModel model)
        {
            ViewData["Message"] = "";
            var eventPlan = db.EventPlans.Where(item => item.Id == model.Id).FirstOrDefault();
            db.EventPlans.Remove(eventPlan);
            db.SaveChanges();
            return View("~/Views/EventPlan/Index.cshtml", GetViewModel());
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public IActionResult UpdateEventPlan(EventPlanIndexViewModel model)
        {
            ViewData["Message"] = "";
            if (model.PlanVolume <= 0)
            {
                ViewData["Message"] += "Неправильное значение планируемого объема";
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
            else if (model.EconomicEffect <= 0)
            {
                ViewData["Message"] += "Неправильное значение экономического эффекта";
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
            else if (model.PlanCost <= 0)
            {
                ViewData["Message"] += "Неправильное значение планируемой стоимости";
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel(1));
            }
            else
            {
                var eventPlan = db.EventPlans.Where(item => item.Id == model.Id).FirstOrDefault();
                eventPlan.EconomicEffect = model.EconomicEffect;
                eventPlan.EmployeeId = db.Employees.Where(item => item.FIO == model.EmployeeFIO).First().Id;
                eventPlan.EndDate = model.EndDate;
                eventPlan.EventId = db.Events.Where(item => item.Name == model.EventName).First().Id;
                eventPlan.OrganizationId = db.Organizations.Where(item => item.Name == model.EventName).First().Id;
                eventPlan.PlanCost = model.PlanCost;
                eventPlan.PlanVolume = model.PlanVolume;
                eventPlan.StartDate = model.StartDate;
                db.SaveChanges();
                return View("~/Views/EventPlan/Index.cshtml", GetViewModel());
            }
        }

        private EventPlanIndexViewModel GetViewModel(int page = 1, string eventName = "Все", string emplFIO = "Все")
        {
            int pageSize = 20;
            List<int> Ids = db.EventPlans.Select(item => item.Id).ToList();
            List<EventPlan> eventPlans = db.EventPlans.ToList();
            List<Employee> employees = db.Employees.ToList();
            List<Event> events = db.Events.ToList();
            List<Organization> organizations = db.Organizations.ToList();
            List<EventPlanViewModel> eventPlanViewModels = new List<EventPlanViewModel>();
            foreach (var eventPlan in eventPlans)
            {
                eventPlanViewModels.Add(new EventPlanViewModel()
                {
                    Id = eventPlan.Id,
                    EndDate = eventPlan.EndDate,
                    EconomicEffect = eventPlan.EconomicEffect,
                    EmployeeFIO = employees.Where(item => item.Id == eventPlan.EmployeeId).First().FIO,
                    EventName = events.Where(item => item.Id == eventPlan.EventId).First().Name,
                    OrganizationName = organizations.Where(item => item.Id == eventPlan.OrganizationId).First().Name,
                    PlanCost = eventPlan.PlanCost,
                    PlanVolume = eventPlan.PlanVolume,
                    StartDate = eventPlan.StartDate
                });
            }

            List<string> eventNames = events.Select(item => item.Name).ToList();
            List<string> emplFIOs = employees.Select(item => item.FIO).ToList();
            eventNames.Add("Все");
            emplFIOs.Add("Все");

            if (eventName != "Все")
            {
                eventPlanViewModels = eventPlanViewModels.Where(item => item.EventName == eventName).ToList();
            }
            if (emplFIO != "Все")
            {
                eventPlanViewModels = eventPlanViewModels.Where(item => item.EmployeeFIO == emplFIO).ToList();
            }

            EventPlanIndexViewModel eventPlanIndexViewModel = new EventPlanIndexViewModel()
            {
                EventPlanViewModels = eventPlanViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = Ids,
                EmployeesFIOs = employees.Select(item => item.FIO).ToList(),
                EventNames = events.Select(item => item.Name).ToList(),
                OrganNames = organizations.Select(item => item.Name).ToList(),
                PageViewModel = new PageViewModel(eventPlanViewModels.Count, page, pageSize),
                FilterEmplFIOs = emplFIOs,
                FilterEventsNames = eventNames,
            };
            return eventPlanIndexViewModel;
        }
    }
}
