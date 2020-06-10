using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StateMachineDataAccess.Database
{   
    [Table("STATEMACHINE_CAR")]
    public class StateMachineTable
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
    
        [Column("GASCARID")]
        public int GasCarId { get; set; }

        [Column("DIESELCARID")]
        public int DieselCarId { get; set; }

        [Column("State")]
        public char State { get; set; }
    }
}
