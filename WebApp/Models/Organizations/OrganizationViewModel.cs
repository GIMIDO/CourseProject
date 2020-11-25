namespace WebApp.Models
{
    // Класс модели представления записи из таблицы Организации
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeOfOwnership { get; set; }
        public string DirectorFIO { get; set; }
        public string MainEnergeticFIO { get; set; }
        public string Address { get; set; }
    }
}
