using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasCarDataAccess.Database
{
    [Table("GASCAR")]
    public class GasCarTable
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CARMODEL")]
        public string CarModel { get; set; }

        [Column("CARBRAND")]
        public string CarBrand { get; set; }
    }
}
