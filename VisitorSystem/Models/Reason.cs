using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Models
{
    public class Reason
    {
        public int Id { get; set; }
        [Display(Name = "Reason in English")]
        public string Name { get; set; }
        [Display(Name="Reason in Arabic")]
        public string ArName { get; set; }
    }
}