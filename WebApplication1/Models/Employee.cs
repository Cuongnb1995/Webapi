using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeCode { get; set; }
        [StringLength(550)]
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        [StringLength(220)]
        public string Email { get; set; }
        [StringLength(220)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string CitizenIdentityCode { get; set; }
        public DateTime? CitizebIdentityDate { get; set; }
        [StringLength(550)]
        public string CitizebIdentityPlace { get; set; }
        public int WorkState { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        [StringLength(220)]
        public string SelfTaxCode { get; set; }
        public double? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
    }
}
