#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftwareEnterprises.Models
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }

        public int EmployeID { get; set; }

        [ForeignKey("EmployeID")]

        public Employee employee { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

      
    }

}
