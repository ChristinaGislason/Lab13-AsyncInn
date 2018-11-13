using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab13_AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Type of Room")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio,
        [Display(Name = "1 Bedroom")]
        OneBedroom,
        [Display(Name = "2 Bedroom")]
        TwoBedroom
    }
}
