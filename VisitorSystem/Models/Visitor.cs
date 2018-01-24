using System.ComponentModel.DataAnnotations;

namespace VisitorSystem.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z]+[,.]?[ ]|[a-zA-Z]+['-]?)+$", ErrorMessage = "Name should be in English")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([\u0600-\u06FF]+[,.]?[ ]|[\u0600-\u06FF]+['-]?)+$", ErrorMessage = "Name should be in Arabic")]
        public string ArName { get; set; }

        public Nationality Nationality { get; set; }
        [Display(Name = "Nationality")]
        public int NationalityId { get; set; }

        public IDType IDType { get; set; }
        [Display(Name = "Identity Type")]
        public int IDTypeId { get; set; }

        [Required]
        [Display(Name="Identity Number")]
        [MinLength(10)]
        [RegularExpression(@"^(?!^0+$ )[a-zA-Z0-9]{3,20}$", ErrorMessage ="Identity Number is not valid")]
        public string IdNumber { get; set; }

        public bool Arrived { get; set; }

        public Request Request { get; set; }
        public int RequestId { get; set; }

        public byte[] Document1 { get; set; }
        public byte[] Document2 { get; set; }

        public string firstDoc { get; set; }
        public string secondDoc { get; set; }

        public string ctDoc1 { get; set; }
        public string ctDoc2 { get; set; }

    }
}