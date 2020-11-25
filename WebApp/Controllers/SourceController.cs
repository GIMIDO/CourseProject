using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class SourceController : Controller
    {
        // Объект контекста данных
        private readonly ApplicationDBContext db;

        public SourceController(ApplicationDBContext applicationContext)
        {
            db = applicationContext;
        }

        // Метод получения страницы клиентов.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string organName = "Все", string superOrganName = "Все")
        {
            return View(GetViewModel(page, organName, superOrganName));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSource(SourceIndexViewModel model)
        {
            ViewData["Message"] = "";
            if (model.OrganizationFunds <= 0)
            {
                ViewData["Message"] += "Неправильное значение фонда организации";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.SuperiorOrganizationFunds <= 0)
            {
                ViewData["Message"] += "Неправильное значение фонда вышестоящей организации";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.LocalBudget <= 0)
            {
                ViewData["Message"] += "Неправильное значение местного бюджета";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.MinistryOfEnergyFund <= 0)
            {
                ViewData["Message"] += "Неправильное значение фонда Министерства Энергетики";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.RepublicBudget <= 0)
            {
                ViewData["Message"] += "Неправильное значение республиканского бюджета";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else
            {
                var id = 0;
                if (db.Sources.Count() != 0)
                {
                    id = db.Sources.Select(item => item.Id).Max();
                }
                id++;   
                db.Sources.Add(new Source()
                {
                    Id = id,
                    SuperiorOrganization = db.Organizations.Where(item => item.Name == model.SuperiorOrganizationName).First().Id,
                    OrganizationFunds = model.OrganizationFunds,
                    LocalBudget = model.LocalBudget,
                    MinistryOfEnergyFund = model.MinistryOfEnergyFund,
                    OrganizationId = db.Organizations.Where(item => item.Name == model.OrganizationName).First().Id,
                    RepublicBudget = model.RepublicBudget,
                    SuperiorOrganizationFunds = model.SuperiorOrganizationFunds
                });
                db.SaveChanges();
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteSource(SourceIndexViewModel model)
        {
            ViewData["Message"] = "";
            var source = db.Sources.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Sources.Remove(source);
            db.SaveChanges();
            return View("~/Views/Source/Index.cshtml", GetViewModel(1));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateSource(SourceIndexViewModel model)
        {
            ViewData["Message"] = "";
            if (model.OrganizationFunds <= 0)
            {
                ViewData["Message"] += "Неправильное значение фонда организации";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.SuperiorOrganizationFunds <= 0)
            {
                ViewData["Message"] += "Неправильное значение фонда вышестоящей организации";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.LocalBudget <= 0)
            {
                ViewData["Message"] += "Неправильное значение местного бюджета";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.MinistryOfEnergyFund <= 0)
            {
                ViewData["Message"] += "Неправильное значение фонда Министерства Энергетики";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else if (model.RepublicBudget <= 0)
            {
                ViewData["Message"] += "Неправильное значение республиканского бюджета";
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
            else
            {
                var source = db.Sources.Where(item => item.Id == model.Id).FirstOrDefault();
                source.SuperiorOrganization = db.Organizations.Where(item => item.Name == model.SuperiorOrganizationName).First().Id;
                source.OrganizationFunds = model.OrganizationFunds;
                source.LocalBudget = model.LocalBudget;
                source.MinistryOfEnergyFund = model.MinistryOfEnergyFund;
                source.OrganizationId = db.Organizations.Where(item => item.Name == model.OrganizationName).First().Id;
                source.RepublicBudget = model.RepublicBudget;
                source.SuperiorOrganizationFunds = model.SuperiorOrganizationFunds;
                db.SaveChanges();
                return View("~/Views/Source/Index.cshtml", GetViewModel(1));
            }
        }

        private SourceIndexViewModel GetViewModel(int page, string organName = "Все", string superOrganName = "Все")
        {
            int pageSize = 20;
            List<int> Ids = db.Sources.Select(item => item.Id).ToList();
            List<Source> sources = db.Sources.ToList();
            List<Organization> organizations = db.Organizations.ToList();
            List<SourceViewModel> sourceViewModels = new List<SourceViewModel>();
            foreach (var source in sources)
            {
                sourceViewModels.Add(new SourceViewModel()
                {
                    Id = source.Id,
                    LocalBudget = source.LocalBudget,
                    MinistryOfEnergyFund = source.MinistryOfEnergyFund,
                    SuperiorOrganizationFunds = source.SuperiorOrganizationFunds,
                    SuperiorOrganizationName = organizations.Where(item => item.Id == source.SuperiorOrganization).First().Name,
                    OrganizationFunds = source.OrganizationFunds,
                    OrganizationName = organizations.Where(item => item.Id == source.OrganizationId).First().Name,
                    RepublicBudget = source.RepublicBudget
                });
            }

            List<string> organNames = organizations.Select(item => item.Name).ToList();
            organNames.Add("Все");

            if (organName != "Все")
            {
                sourceViewModels = sourceViewModels.Where(item => item.OrganizationName == organName).ToList();
            }
            if (superOrganName != "Все")
            {
                sourceViewModels = sourceViewModels.Where(item => item.SuperiorOrganizationName == superOrganName).ToList();
            }

            SourceIndexViewModel sourceIndexViewModel = new SourceIndexViewModel()
            {
                SourceViewModels = sourceViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = Ids,
                OrganNames = organizations.Select(item => item.Name).ToList(),
                PageViewModel = new PageViewModel(sourceViewModels.Count, page, pageSize),
                FilterOrganNames = organNames
            };
            return sourceIndexViewModel;
        }
    }
}
