using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Position
    {
        public Position()
        {
            Employees = new List<Employee>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(550)]
        public string PositionName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
