using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisitorSystem.Models
{
    public class Authorizor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="ALJ Account")]
        [RegularExpression(@"^(alj|ALJ|Alj|ALj|aLj|AlJ|aLJ)[A-Za-z]{3}[0-9]{2}", ErrorMessage ="Please enter a valid ALJ account.")]
        public string ALJAccount { get; set; }

        public Department Department { get; set; }
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public bool isEnable { get; set; }
    }
}