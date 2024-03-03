using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorePro.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Eid { get; set; }
        public string Ename { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime dob { get; set; }
        public decimal Salary { get; set; }
    }
}
