#nullable  disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareEnterprises.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Role Name")]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }

       
    }
}
