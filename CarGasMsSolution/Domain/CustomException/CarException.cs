using System;

namespace Domain.CustomException
{
    public class CarException : Exception
    {
        public CarException(string message)
            : base(String.Format(message))
        { }
    }
}
