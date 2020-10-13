using System.ComponentModel.DataAnnotations;

namespace ContextLibrary.Domain_Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public Event() { }
        public Event(int id, string name, string unit)
        {
            Id = id;
            Name = name;
            Unit = unit;
        }
    }
}
