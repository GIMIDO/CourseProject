using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer;
using ContextLibrary;
using System.Collections.Generic;
using ContextLibrary.Domain_Entities;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("SqlServerConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            int choise = 1;
            BLL business_layer = new BLL();
            List<Event> events;
            Dictionary<string, string> organizationsAndDirectors;
            while (choise != 0)
            {
                Console.WriteLine("1. Вывести все данные из таблицы событий;");
                Console.WriteLine("2. Вывести все данные из таблицы событий, имеющих заданное объединение;");
                Console.WriteLine("3. Вывести кол-во организаций по каждому известному типу владения;");
                Console.WriteLine("4. Вывести список организаций и ФИО их директоров;");
                Console.WriteLine("5. Вывести список организаций, принадлежащих определенному типу, и ФИО их директоров;");
                Console.WriteLine("6. Добавление события;");
                Console.WriteLine("7. Добавление источника;");
                Console.WriteLine("8. Удаление события;");
                Console.WriteLine("9. Удаление источника;");
                Console.WriteLine("10. Обновление информации об организации;");
                Console.WriteLine("0. Выход.");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        events = business_layer.GetEvents(options);
                        foreach (var @event in events)
                        {
                            Console.WriteLine(@event.Id + "; " + @event.Name + "; " + @event.Unit);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите объединение");
                        string unit = Console.ReadLine();
                        events = business_layer.GetEventByUnit(options, unit);
                        foreach (var @event in events)
                        {
                            Console.WriteLine(@event.Id + "; " + @event.Name + "; " + @event.Unit);
                        }
                        break;
                    case 3:
                        Dictionary<string, int> countTypes = business_layer.GetOrganizationCountWithTypes(options);
                        foreach (var countType in countTypes)
                        {
                            Console.WriteLine(countType.Key + ": " + countType.Value.ToString());
                        }
                        break;
                    case 4:
                        organizationsAndDirectors = business_layer.GetOrganizationWithDirector(options);
                        foreach (var organAndDir in organizationsAndDirectors)
                        {
                            Console.WriteLine(organAndDir.Key + ": " + organAndDir.Value);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Введите тип организации");
                        string type = Console.ReadLine();
                        organizationsAndDirectors = business_layer.GetOrganizationWithDirectorAndType(options, type);
                        foreach (var organAndDir in organizationsAndDirectors)
                        {
                            Console.WriteLine(organAndDir.Key + ": " + organAndDir.Value);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Введите название");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите название объединения");
                        unit = Console.ReadLine();
                        business_layer.AddEvent(name, unit, options);
                        Console.WriteLine("Запись добавлена!");
                        break;
                    case 7:
                        Console.WriteLine("Введите название организации");
                        string organName = Console.ReadLine();
                        Console.WriteLine("Введите размер фонда организации");
                        decimal organFunds = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Введите название вышестоящей организации");
                        string superOrganName = Console.ReadLine();
                        Console.WriteLine("Введите размер фонда вышестоящей организации");
                        decimal superOrganFunds = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Введите размер фонда министерства энергетики");
                        decimal minFunds = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Введите размер республиканского бюджета");
                        decimal repFunds = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Введите размер местного бюджета");
                        decimal localFunds = decimal.Parse(Console.ReadLine());
                        business_layer.AddSource(organName, organFunds, superOrganName, superOrganFunds, minFunds, repFunds, localFunds, options);
                        Console.WriteLine("Запись добавлена!");
                        break;
                    case 8:
                        Console.WriteLine("Введите id события");
                        int id = int.Parse(Console.ReadLine());
                        business_layer.DeleteEvent(id, options);
                        Console.WriteLine("Запись удалена!");
                        break;
                    case 9:
                        Console.WriteLine("Введите id источника");
                        id = int.Parse(Console.ReadLine());
                        business_layer.DeleteSource(id, options);
                        Console.WriteLine("Запись удалена!");
                        break;
                    case 10:
                        Console.WriteLine("Введите id");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите название организации");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите тип владения организации");
                        type = Console.ReadLine();
                        Console.WriteLine("Введите ФИО директора");
                        string directorFIO = Console.ReadLine();
                        Console.WriteLine("Введите ФИО главного инженера");
                        string mainEnginFIO = Console.ReadLine();
                        Console.WriteLine("Введите адрес");
                        string address = Console.ReadLine();
                        business_layer.UpdateOrganization(id, name, type, directorFIO, mainEnginFIO, address, options);
                        Console.WriteLine("Запись обновлена!");
                        break;
                }
            }
        }
    }
}
