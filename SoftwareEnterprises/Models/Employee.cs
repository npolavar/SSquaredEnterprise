#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareEnterprises.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Employee ID")]
        public string EmployesId { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        public int ParentId { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

       
    }
}
