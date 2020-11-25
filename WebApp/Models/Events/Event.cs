using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    // Класс, представляющий собой модель записи в таблице События
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public Event() {}
    }
}
