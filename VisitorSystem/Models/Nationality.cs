using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        [Display(Name="English")]
        public string Name { get; set; }
        [Display(Name="Arabic Name")]
        public string ArName { get; set; }
    }
}