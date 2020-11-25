using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class OrganizationIndexViewModel
    {
        public List<OrganizationViewModel> OrganizationViewModels { get; set; }

        public List<string> EmployeesFIOs { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<string> FilterDirectorFIOs { get; set; }

        public string FilterDirectFIO { get; set; }

        public string FilterAddress { get; set; }

        public List<int> Ids { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Тип хозяйствования")]
        public string TypeOfOwnership { get; set; }

        [Display(Name = "ФИО директора")]
        public string DirectorFIO { get; set; }

        [Display(Name = "ФИО главного энергетика")]
        public string MainEnergeticFIO { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}
