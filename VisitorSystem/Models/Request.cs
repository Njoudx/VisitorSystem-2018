using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace VisitorSystem.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        public Reason Reason { get; set; }
        [Required]
        [Display(Name = "Reason")]
        public int ReasonId { get; set; }

        [Required]
        [Display(Name = "From")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "To")]
        public DateTime DateTo { get; set; }

        [Display(Name ="Requester")]
        public string RequestFrom { get; set; }

        public Department Department { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\u0600-\u06FF ]+$", ErrorMessage ="Company name is not correct.")]
        public string Company { set; get; }

        public int VisitorSystem { get; set; }

        public List<Visitor> Visitors { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }

        public Status Status { get; set; }
        public int StatusId { get; set; }

        public Location Location { get; set; }
        public int LocationId { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public string ISFFilePath { get; set; }

        [Display(Name ="Authorizor")]
        public int AuthorizorId { set; get; }

        /*There's no need of these two values, need to be removed.*/
        public int FirstApproval { get; set; }
        public int ISSApproval { get; set; }
        /*Done*/

        public string getFullName(string username)
        {
            string fullName = null;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(context, "SASREFALJ\\" + username.ToUpper()))
                {
                    if (user != null)
                    {
                        fullName = user.DisplayName;
                        return fullName;
                    }
                    else
                    {
                        return username;
                    }
                }
            }
        }


    }
}