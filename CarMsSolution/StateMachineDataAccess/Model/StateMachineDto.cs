using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineDataAccess.Model
{
    public class StateMachineDto
    {
        public int Id { get; set; }
 
        public int GasCarId { get; set; }
    
        public int DieselCarId { get; set; }
    
        public char State { get; set; }

    }
}
