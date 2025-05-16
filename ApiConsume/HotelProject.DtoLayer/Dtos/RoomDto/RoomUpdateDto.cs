using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Please enter the room number.")]
        public string? RoomNumber { get; set; }

        [Required(ErrorMessage = "Please enter the room cover image.")]
        public string? RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Please enter the price.")]
        public int Price { get; set; }

        [StringLength(100, ErrorMessage ="Please only enter 100 characters for the field.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter the bed count.")]

        public string? BedCount { get; set; }
        [Required(ErrorMessage = "Please enter the bathroom count.")]

        public string? BathCount { get; set; }
        public string? Wifi { get; set; }

        [Required(ErrorMessage = "Please enter the room description.")]
        public string? Description { get; set; }
    }
}
