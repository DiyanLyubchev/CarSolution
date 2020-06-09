using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DieselCarDataAccess.Database
{
    [Table("DIESELCAR")]
    public class DieselCarTable
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
