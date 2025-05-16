using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Enter a service icon link")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage ="Enter a service title")]
        [StringLength(100, ErrorMessage = "Service title can contain maximum of 100 characters")]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
