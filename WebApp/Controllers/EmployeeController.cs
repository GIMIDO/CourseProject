using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        // Объект контекста данных
        private readonly ApplicationDBContext db;

        public EmployeeController(ApplicationDBContext applicationContext)
        {
            db = applicationContext;
        }

        // Метод получения страницы работников.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string position = "Все", string number = null)
        {
            int pageSize = 20;
            List<Employee> employees = db.Employees.ToList();
            List<int> Ids = employees.Select(item => item.Id).ToList();
            List<string> positions = employees.Select(item => item.Position).ToList();
            positions.Add("Все");

            if (position != "Все")
            {
                employees = employees.Where(item => item.Position == position).ToList();
            }

            if (number != null)
            {
                employees = employees.Where(item => item.Number.Contains(number)).ToList();
            }


            EmployeeIndexViewModel employeeIndexViewModel = new EmployeeIndexViewModel()
            {
                Employees = employees.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = Ids,
                PageViewModel = new PageViewModel(employees.Count, page, pageSize),
                FilterPositions = positions
            };

            return View(employeeIndexViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddEmployee(EmployeeIndexViewModel model)
        {
            var fios = db.Employees.Select(item => item.FIO);
            ViewData["Message"] = "";
            model.Employees = db.Employees.ToList();
            model.Ids = db.Employees.Select(item => item.Id).ToList();
            if (model.FIO == null || model.Number == null || model.Position == null)
            {
                ViewData["Message"] += "Отсутствие значений в строках";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            if (fios.Contains(model.FIO) || model.FIO.Length == 0 || model.FIO.Length > 100)
            {
                ViewData["Message"] += "Неправильный ввод ФИО";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            else if (model.Position.Length == 0 || model.Position.Length > 50)
            {
                ViewData["Message"] += "Неправильный ввод должности";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            else if (model.Number.Length < 9 || model.Number.Length > 12)
            {
                ViewData["Message"] += "Неправильный ввод номера";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            else
            {
                var id = 0;
                if (db.Employees.Count() != 0)
                {
                    id = db.Employees.Select(item => item.Id).Max();
                }
                id++;
                db.Employees.Add(new Employee() { Id = id, FIO = model.FIO, Position = model.Position, Number = model.Number });
                db.SaveChanges();
                model.Employees = db.Employees.ToList();
                model.Ids = db.Employees.Select(item => item.Id).ToList();
                return View("~/Views/Employee/Index.cshtml", model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeIndexViewModel model)
        {
            ViewData["Message"] = "";
            var employee = db.Employees.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            model.Employees = db.Employees.ToList();
            model.Ids = db.Employees.Select(item => item.Id).ToList();
            return View("~/Views/Employee/Index.cshtml", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeIndexViewModel model)
        {
            var fios = db.Employees.Select(item => item.FIO);
            ViewData["Message"] = "";
            model.Employees = db.Employees.ToList();
            model.Ids = db.Employees.Select(item => item.Id).ToList();
            if (model.FIO == null || model.Number == null || model.Position == null)
            {
                ViewData["Message"] += "Отсутствие значений в строках";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            if (fios.Contains(model.FIO) || model.FIO.Length == 0 || model.FIO.Length > 100)
            {
                ViewData["Message"] += "Неправильный ввод ФИО";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            else if (model.Position.Length == 0 || model.Position.Length > 50)
            {
                ViewData["Message"] += "Неправильный ввод должности";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            else if (model.Number.Length < 9 || model.Number.Length > 12)
            {
                ViewData["Message"] += "Неправильный ввод номера";
                return View("~/Views/Employee/Index.cshtml", model);
            }
            else
            {
                var employee = db.Employees.Where(item => item.Id == model.Id).FirstOrDefault();
                employee.FIO = model.FIO;
                employee.Position = model.Position;
                employee.Number = model.Number;
                db.SaveChanges();
                return View("~/Views/Employee/Index.cshtml", model);
            }
        }
    }
}
