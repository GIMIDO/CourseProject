using System.ComponentModel.DataAnnotations;

namespace ContextLibrary.Domain_Entities
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeOfOwnership { get; set; }
        public int DirectorId { get; set; }
        public int MainEnergeticId { get; set; }
        public string Address { get; set; }
        public Organization() { }
    }
}
