using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorePro.Models
{
    [Table("Tbl_Demo")]
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rollno { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DOB { get; set; }

        public string Mobile { get; set; }

        public string Gender { get; set; }
        public decimal Fee { get; set; }
        public string Dept { get; set; }
        public Boolean Status { get; set; }
    }

    [Keyless]
    public class LoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
