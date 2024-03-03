using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorePro.Models
{
    [Table("vilageData")]
    public class CountryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vid { get; set; }

        public string Vname { get; set; }

        public string Vdist { get; set; }
        public int PinCode { get; set; }

    }
}
