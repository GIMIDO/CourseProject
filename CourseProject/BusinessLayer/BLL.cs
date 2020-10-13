using ContextLibrary;
using ContextLibrary.Domain_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    // Класс бизнес-логики приложения
    public class BLL
    {
        // Метод получения списка событий
        public List<Event> GetEvents(DbContextOptions<ApplicationDBContext> options)
        {
            List<Event> events;
            using (ApplicationDBContext context = new ApplicationDBContext(options))
            {
                events = context.Events.ToList();
            }
            return events;
        }
        // Метод получения списка событий по заданному полю
        public List<Event> GetEventByUnit(DbContextOptions<ApplicationDBContext> options, string unit)
        {
            List<Event> events;
            using (ApplicationDBContext context = new ApplicationDBContext(options))
            {
                events = context.Events.Select(elem => elem).Where(elem => elem.Unit == unit).ToList();
            }
            return events;
        }
        // Метод получения списка типов владения и кол-ва организаций
        public Dictionary<string, int> GetOrganizationCountWithTypes(DbContextOptions<ApplicationDBContext> options)
        {
            Dictionary<string, int> countInTypes = new Dictionary<string, int>();
            int count;
            using (ApplicationDBContext context = new ApplicationDBContext(options))
            {
                var organizations = context.Organizations.ToList().GroupBy(item => item.TypeOfOwnership).Select(item => item);
                foreach (var elem in organizations)
                {
                    count = elem.Select(item => item).Count();
                    countInTypes.Add(elem.Key, count);
                }
            }
            return countInTypes;
        }
        // Метод получения списка организаций и ФИО их директоров
        public Dictionary<string, string> GetOrganizationWithDirector(DbContextOptions<ApplicationDBContext> options)
        {
            Dictionary<string, string> organizationsWithDirectors = new Dictionary<string, string>();
            using (ApplicationDBContext context = new ApplicationDBContext(options))
            {
                var organizations = context.Organizations.Select(item => item).ToList();
                foreach (var elem in organizations)
                {
                    var emplName = context.Employees.Where(item => item.Id == elem.DirectorId).Select(item => item.FIO).First();
                    organizationsWithDirectors.Add(elem.Name, emplName);
                }
            }
            return organizationsWithDirectors;
        }
        // Метод получения списка организаций c определенным типом владения и ФИО их директоров
        public Dictionary<string, string> GetOrganizationWithDirectorAndType(DbContextOptions<ApplicationDBContext> options, string type)
        {
            Dictionary<string, string> organizationsWithDirectors = new Dictionary<string, string>();
            using (ApplicationDBContext context = new ApplicationDBContext(options))
            {
                var organizations = context.Organizations.Where(item => item.TypeOfOwnership == type).Select(item => item).ToList();
                foreach (var elem in organizations)
                {
                    var emplName = context.Employees.Where(item => item.Id == elem.DirectorId).Select(item => item.FIO).First();
                    organizationsWithDirectors.Add(elem.Name, emplName);
                }
            }
            return organizationsWithDirectors;
        }
        // Метод добавления записи в таблицу "События"
        public void AddEvent(string name, string unit, DbContextOptions<ApplicationDBContext> options)
        {
            using ApplicationDBContext context = new ApplicationDBContext(options);
            var names = context.Events.Select(item => item.Name);
            var units = context.Events.Select(item => item.Unit);
            var id = context.Events.Select(item => item.Id).Max();
            if (!names.Contains(name) && !units.Contains(unit))
            {
                context.Events.Add(new Event(id + 1, name, unit));
                context.SaveChanges();
            }
        }
        // Метод добавления записи в таблицу "Источники"
        public void AddSource(string organName, decimal organFunds, string superOrganName, decimal superOrganFunds, decimal minFunds, decimal repFunds, decimal localFunds, DbContextOptions<ApplicationDBContext> options)
        {
            using ApplicationDBContext context = new ApplicationDBContext(options);
            if (context.Organizations.Where(item => item.Name == organName).Count() != 0 && context.Organizations.Where(item => item.Name == superOrganName).Count()
                != 0 && organFunds >= 0 && superOrganFunds >= 0 && minFunds >= 0 && repFunds >= 0 && localFunds >= 0)
            {
                var organId = context.Organizations.Where(item => item.Name == organName).Select(item => item.Id).Single();
                var superOrganId = context.Organizations.Where(item => item.Name == superOrganName).Select(item => item.Id).Single();
                var id = context.Sources.Select(item => item.Id).Max();
                context.Sources.Add(new Source(id + 1, organId, organFunds, superOrganId, superOrganFunds, minFunds, repFunds, localFunds));
                context.SaveChanges();
            }
        }
        // Метод удаления записи из таблицы "События" по ключу
        public void DeleteEvent(int id, DbContextOptions<ApplicationDBContext> options)
        {
            using ApplicationDBContext context = new ApplicationDBContext(options);
            var eventElem = context.Events.Where(item => item.Id == id).Single();
            context.Events.Remove(eventElem);
            context.SaveChanges();
        }
        // Метод удаления записи из таблицы "Источники" по ключу
        public void DeleteSource(int id, DbContextOptions<ApplicationDBContext> options)
        {
            using ApplicationDBContext context = new ApplicationDBContext(options);
            var source = context.Sources.Where(item => item.Id == id).Single();
            context.Sources.Remove(source);
            context.SaveChanges();
        }
        // Метод обновления записи в таблице "Организации"
        public void UpdateOrganization(int id, string name, string type, string directorFIO, string mainEnergFIO, string address, DbContextOptions<ApplicationDBContext> options)
        {
            using ApplicationDBContext context = new ApplicationDBContext(options);
            var order = context.Organizations.Where(item => item.Id == id).Single();
            order.Name = name;
            order.TypeOfOwnership = type;
            order.DirectorId = context.Employees.Where(item => item.FIO == directorFIO).Select(item => item.Id).First();
            order.MainEnergeticId = context.Employees.Where(item => item.FIO == mainEnergFIO).Select(item => item.Id).First();
            order.Address = address;
            context.SaveChanges();
        }
    }
}
