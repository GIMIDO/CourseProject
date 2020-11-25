using System;
using System.Linq;

namespace WebApp.Models
{
    public static class DbInitializer
    {
        // Метод инициализации базы данных путем заполнения таблиц тестовыми наборами данных
        public static void Initialize(ApplicationDBContext db)
        {
            db.Database.EnsureCreated();

            Random rand = new Random();

            char[] letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            char[] lettersWithNumbers = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789".ToCharArray();

            // Проверка на наличие записей в таблице Работники
            if (!db.Employees.Any())
            {
                string fio = "";
                string posit = "";
                string phone = "+";
                int i = 0;
                while (i < 20)
                {
                    // Создание Id
                    int id = db.Employees.Count() + 1;

                    // Создание ФИО
                    int randInt = rand.Next(18, 100);
                    for (int j = 1; j <= randInt; j++)
                    {
                        fio += letters[rand.Next(33)];
                    }

                    // Создание должности
                    randInt = rand.Next(10, 50);
                    for (int j = 2; j <= randInt; j++)
                    {
                        posit += letters[rand.Next(33)];
                    }

                    // Создание должности
                    for (int j = 2; j <= 10; j++)
                    {
                        phone += numbers[rand.Next(33)];
                    }

                    db.Employees.Add(new Employee { Id = id, FIO = fio, Position = posit, Number = phone});
                }
                db.SaveChanges();
                i++;
            }

            // Проверка на наличие записей в таблице События
            if (!db.Events.Any())
            {
                string name = "";
                string unit = "";

                int i = 0;

                while (i < 20)
                {
                    // Создание Id
                    int id = db.Events.Count() + 1;

                    // Создание названия события
                    int randInt = rand.Next(10, 50);
                    for (int j = 1; j <= randInt; j++)
                    {
                        name += letters[rand.Next(33)];
                    }

                    randInt = rand.Next(6, 10);
                    for (int j = 1; j <= randInt; j++)
                    {
                        unit += letters[rand.Next(33)];
                    }

                    db.Events.Add(new Event { Id = id, Name = name, Unit = unit });
                }
                db.SaveChanges();
                i++;
            }

            // Проверка на наличие записей в таблице Организации
            if (!db.Organizations.Any())
            {
                string name = "";
                string type = "";
                string address = "";

                int i = 0;

                while (i < 100)
                {
                    // Создание Id
                    int id = db.Organizations.Count() + 1;

                    // Создание названия
                    int randInt = rand.Next(8, 25);
                    for (int j = 1; j <= randInt; j++)
                    {
                        name += letters[rand.Next(33)];
                    }

                    // Создание типа владения
                    randInt = rand.Next(8, 30);
                    for (int j = 1; j <= randInt; j++)
                    {
                        type += letters[rand.Next(33)];
                    }

                    // Создание адреса
                    randInt = rand.Next(11, 40);
                    for (int j = 1; j <= randInt; j++)
                    {
                        address += letters[rand.Next(33)];
                    }

                    // Создание Id директора
                    int directId = rand.Next(1, db.Employees.ToList().Select(elem => elem.Id).Max());

                    // Создание Id главного энергетика
                    int mainEnergId = rand.Next(1, db.Employees.ToList().Select(elem => elem.Id).Max());

                    db.Organizations.Add(new Organization { Id = id, Name = name, TypeOfOwnership = type, DirectorId = directId, MainEnergeticId = mainEnergId, Address = address });
                }
                db.SaveChanges();
                i++;
            }

            // Проверка на наличие записей в таблице Планы событий
            if (!db.EventPlans.Any())
            {
                int i = 0;

                while (i < 100)
                {
                    // Создание Id
                    int id = db.EventPlans.Count() + 1;

                    // Создание Id организации
                    int organId = rand.Next(1, db.Organizations.ToList().Select(elem => elem.Id).Max());

                    // Создание Id события
                    int eventId = rand.Next(1, db.Events.ToList().Select(elem => elem.Id).Max());

                    // Создание начала события
                    DateTime startDate = DateTime.Now.AddDays(-1);

                    // Создание конца события
                    DateTime endDate = DateTime.Now;

                    // Создание планируемой мощности
                    int planVolume = rand.Next(1, 100);

                    // Создание планируемой стоимости
                    decimal planCost = (decimal)rand.NextDouble() * 100;

                    // Создание экономического эффекта
                    float econEffect = (float)rand.NextDouble() * 10;

                    // Создание Id главного энергетика
                    int emplId = rand.Next(1, db.Employees.ToList().Select(elem => elem.Id).Max());

                    db.EventPlans.Add(new EventPlan { Id = id, OrganizationId = organId, EventId = eventId, StartDate = startDate, EndDate = endDate, PlanVolume = planVolume, PlanCost = planCost, EconomicEffect = econEffect, EmployeeId = emplId });
                }
                db.SaveChanges();
                i++;
            }

            // Проверка на наличие записей в таблице Источники
            if (!db.Sources.Any())
            {
                int i = 0;

                while (i < 100)
                {
                    // Создание Id
                    int id = db.Sources.Count() + 1;

                    // Создание Id организации
                    int organId = rand.Next(1, db.Organizations.ToList().Select(elem => elem.Id).Max());

                    // Создание фонда организации
                    decimal organFunds = (decimal)rand.NextDouble() * 10000;

                    // Создание Id вышестоящей организации
                    int superOrganId = rand.Next(1, db.Organizations.ToList().Select(elem => elem.Id).Max());

                    // Создание фонда вышестоящей организации
                    decimal superOrganFunds = (decimal)rand.NextDouble() * 10000;

                    // Создание фонда Министерства Энергетики
                    decimal ministryFunds = (decimal)rand.NextDouble() * 10000;

                    // Создание республиканского бюджета
                    decimal repBudg = (decimal)rand.NextDouble() * 10000;

                    // Создание местного бюджета
                    decimal locBudg = (decimal)rand.NextDouble() * 10000;

                    db.Sources.Add(new Source { Id = id, OrganizationId = organId, OrganizationFunds = organFunds, SuperiorOrganization = superOrganId, SuperiorOrganizationFunds = superOrganFunds, MinistryOfEnergyFund = ministryFunds, RepublicBudget = repBudg, LocalBudget = locBudg });
                }
                db.SaveChanges();
                i++;
            }
        }
    }
}