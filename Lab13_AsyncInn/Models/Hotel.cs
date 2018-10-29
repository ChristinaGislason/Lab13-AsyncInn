using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="30 characters or less required")]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }            
    }
}
