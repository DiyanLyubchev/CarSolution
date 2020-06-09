using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.CustomException
{
    public class CarException : Exception
    {
        public CarException(string message)
            : base(String.Format(message))
        { }
    }
}
