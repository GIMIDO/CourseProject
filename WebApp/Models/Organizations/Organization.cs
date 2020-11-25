using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApp.Models
{
    // Класс, представляющий собой модель записи в таблице Организации
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeOfOwnership { get; set; }
        public int DirectorId { get; set; }
        public int MainEnergeticId { get; set; }
        public string Address { get; set; }
        public Organization() {}
    }
}
