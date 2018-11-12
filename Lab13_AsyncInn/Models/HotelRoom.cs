using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab13_AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        public decimal RoomID { get; set; }

        [Required(ErrorMessage = "Please provide a valid rate per night")]
        [Display(Name = "Rate Per Night")]
        public decimal Rate { get; set; }

        [Required]
        [Display(Name = "Pet-Friendly")]
        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }

        public Room Room { get; set; }

    }
}
