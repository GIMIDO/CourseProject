using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class OrganizationController : Controller
    {
        // Объект контекста данных
        private readonly ApplicationDBContext db;

        public OrganizationController(ApplicationDBContext applicationContext)
        {
            db = applicationContext;
        }

        // Метод получения страницы клиентов.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string director = "Все", string address = null)
        {
            return View(GetViewModel(page, director, address));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddOrganization(OrganizationIndexViewModel model)
        {
            ViewData["Message"] = "";
            if (model.Name == null || model.TypeOfOwnership == null || model.Address == null)
            {
                ViewData["Message"] += "Отсутствие значений в строках";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            if (model.Name.Length == 0 || model.Name.Length > 35)
            {
                ViewData["Message"] += "Неправильный ввод названия";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            else if (model.TypeOfOwnership.Length == 0 || model.TypeOfOwnership.Length > 100)
            {
                ViewData["Message"] += "Неправильный ввод вида хозяйствования";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            else if (model.Address.Length == 0 || model.Address.Length > 60)
            {
                ViewData["Message"] += "Неправильный ввод адреса";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            else
            {
                var id = 0;
                if (db.Organizations.Count() != 0)
                {
                    id = db.Organizations.Select(item => item.Id).Max();
                }
                id++;
                db.Organizations.Add(new Organization()
                {
                    Id = id,
                    DirectorId = db.Employees.Where(item => item.FIO == model.DirectorFIO).First().Id,
                    Address = model.Address,
                    MainEnergeticId = db.Employees.Where(item => item.FIO == model.MainEnergeticFIO).First().Id,
                    Name = model.Name,
                    TypeOfOwnership = model.TypeOfOwnership
                });
                db.SaveChanges();
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteOrganization(OrganizationIndexViewModel model)
        {
            ViewData["Message"] = "";
            var organization = db.Organizations.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Organizations.Remove(organization);
            db.SaveChanges();
            return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateOrganization(OrganizationIndexViewModel model)
        {
            ViewData["Message"] = "";
            if (model.Name == null || model.TypeOfOwnership == null || model.Address == null)
            {
                ViewData["Message"] += "Отсутствие значений в строках";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            if (model.Name.Length == 0 || model.Name.Length > 35)
            {
                ViewData["Message"] += "Неправильный ввод названия";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            else if (model.TypeOfOwnership.Length == 0 || model.TypeOfOwnership.Length > 100)
            {
                ViewData["Message"] += "Неправильный ввод вида хозяйствования";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            else if (model.Address.Length == 0 || model.Address.Length > 60)
            {
                ViewData["Message"] += "Неправильный ввод адреса";
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
            else
            {
                var organization = db.Organizations.Where(item => item.Id == model.Id).FirstOrDefault();
                organization.Address = model.Address;
                organization.DirectorId = db.Employees.Where(item => item.FIO == model.DirectorFIO).First().Id;
                organization.MainEnergeticId = db.Employees.Where(item => item.FIO == model.MainEnergeticFIO).First().Id;
                organization.Name = model.Name;
                organization.TypeOfOwnership = model.TypeOfOwnership;
                db.SaveChanges();
                return View("~/Views/Organization/Index.cshtml", GetViewModel(1));
            }
        }

        private OrganizationIndexViewModel GetViewModel(int page, string director = "Все", string address = null)
        {
            int pageSize = 20;
            List<int> Ids = db.Organizations.Select(item => item.Id).ToList();
            List<Organization> organizations = db.Organizations.ToList();
            List<Employee> employees = db.Employees.ToList();
            List<OrganizationViewModel> organizationViewModels = new List<OrganizationViewModel>();
            foreach (var organization in organizations)
            {
                organizationViewModels.Add(new OrganizationViewModel()
                {
                    Id = organization.Id,
                    DirectorFIO = employees.Where(item => item.Id == organization.DirectorId).First().FIO,
                    Address = organization.Address,
                    MainEnergeticFIO = employees.Where(item => item.Id == organization.MainEnergeticId).First().FIO,
                    Name = organization.Name,
                    TypeOfOwnership = organization.TypeOfOwnership
                });
            }

            List<string> emplFIOs = employees.Select(item => item.FIO).ToList();
            emplFIOs.Add("Все");

            if (director != "Все")
            {
                organizationViewModels = organizationViewModels.Where(item => item.DirectorFIO == director).ToList();
            }

            if (address != null)
            {
                organizationViewModels = organizationViewModels.Where(item => item.Address == address).ToList();
            }

            OrganizationIndexViewModel organizationIndexViewModel = new OrganizationIndexViewModel()
            {
                OrganizationViewModels = organizationViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = Ids,
                EmployeesFIOs = employees.Select(item => item.FIO).ToList(),
                PageViewModel = new PageViewModel(organizationViewModels.Count, page, pageSize),
                FilterDirectorFIOs = emplFIOs,
            };
            return organizationIndexViewModel;
        }
    }
}
