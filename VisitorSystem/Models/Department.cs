using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name ="English Name")]
        [RegularExpression(@"^[A-Za-z]{3}", ErrorMessage ="English name should be three letters.")]
        public string Name { get; set; }

        [Display(Name = "Arabic Name")]
        [RegularExpression(@"^[\u0600-\u06FF]+$", ErrorMessage = "Name should be in Arabic.")]
        public string ArName { get; set; }
        public bool isEnable { get; set; }
    }
}