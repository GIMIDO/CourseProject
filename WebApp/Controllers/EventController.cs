using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class EventController : Controller
    {
        // Объект контекста данных
        private readonly ApplicationDBContext db;

        public EventController(ApplicationDBContext applicationContext)
        {
            db = applicationContext;
        }

        // Метод получения страницы клиентов.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string unit = "Все")
        {
            int pageSize = 20;
            List<Event> events = db.Events.ToList();
            List<int> Ids = events.Select(item => item.Id).ToList();
            List<string> units = events.Select(item => item.Unit).ToList();

            units.Add("Все");

            if (unit != "Все")
            {
                events = events.Where(item => item.Unit == unit).ToList();
            }

            EventIndexViewModel eventIndexViewModel = new EventIndexViewModel()
            {
                Events = events.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = Ids,
                PageViewModel = new PageViewModel(events.Count, page, pageSize),
                FilterUnits = units
            };

            return View(eventIndexViewModel);
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public IActionResult AddEvent(EventIndexViewModel model)
        {
            var names = db.Events.Select(item => item.Name);
            ViewData["Message"] = "";
            model.Events = db.Events.ToList();
            model.Ids = db.Events.Select(item => item.Id).ToList();
            if (model.Name == null)
            {
                ViewData["Message"] += "Отсутствие значений в строках";
                return View("~/Views/Event/Index.cshtml", model);
            }
            if (names.Contains(model.Name) || model.Name.Length == 0 || model.Name.Length > 50)
            {
                ViewData["Message"] += "Неправильный ввод названия";
                return View("~/Views/Event/Index.cshtml", model);
            }
            else
            {
                var id = 0;
                if (db.Events.Count() != 0)
                {
                    id = db.Events.Select(item => item.Id).Max();
                }
                id++;
                db.Events.Add(new Event() { Id = id, Name = model.Name, Unit = model.Unit });
                db.SaveChanges();
                model.Events = db.Events.ToList();
                model.Ids = db.Events.Select(item => item.Id).ToList();
                return View("~/Views/Event/Index.cshtml", model);
            }
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public IActionResult DeleteEvent(EventIndexViewModel model)
        {
            ViewData["Message"] = "";
            var eventElem = db.Events.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Events.Remove(eventElem);
            db.SaveChanges();
            model.Events = db.Events.ToList();
            model.Ids = db.Events.Select(item => item.Id).ToList();
            return View("~/Views/Event/Index.cshtml", model);
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public IActionResult UpdateEvent(EventIndexViewModel model)
        {
            var names = db.Events.Select(item => item.Name);
            ViewData["Message"] = "";
            model.Events = db.Events.ToList();
            model.Ids = db.Events.Select(item => item.Id).ToList();
            if (model.Name == null)
            {
                ViewData["Message"] += "Отсутствие значений в строках";
                return View("~/Views/Event/Index.cshtml", model);
            }
            if (names.Contains(model.Name) || model.Name.Length == 0 || model.Name.Length > 50)
            {
                ViewData["Message"] += "Неправильный ввод названия";
                return View("~/Views/Event/Index.cshtml", model);
            }
            else
            {
                var eventElem = db.Events.Where(item => item.Id == model.Id).FirstOrDefault();
                eventElem.Name = model.Name;
                eventElem.Unit = model.Unit;
                db.SaveChanges();
                return View("~/Views/Event/Index.cshtml", model);
            }
        }
    }
}
