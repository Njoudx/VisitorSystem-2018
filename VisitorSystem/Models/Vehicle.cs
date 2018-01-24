using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Type")]
        public int CarTypeId { get; set; }
        public string Model { get; set; }
        [Display(Name ="Plate Number")]
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}