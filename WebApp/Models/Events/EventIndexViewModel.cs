using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class EventIndexViewModel
    {
        public List<Event> Events { get; set; }

        public List<int> Ids { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<string> FilterUnits { get; set; }

        public string FilterUnit { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }
    }
}
