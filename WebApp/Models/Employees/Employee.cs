using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    // Класс, представляющий собой модель записи в таблице Работники
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Position { get; set; }
        public string Number { get; set; }
        public Employee() {}
    }
}
