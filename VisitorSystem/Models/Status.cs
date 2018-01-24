using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Display(Name="Status")]
        public string Name { get; set; }
    }
}