using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepartmentCode { get; set; }
        [StringLength(220)]
        public string DepartmentName { get; set; }
        public int ParentId { get; set; }
        [StringLength(550)]
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
