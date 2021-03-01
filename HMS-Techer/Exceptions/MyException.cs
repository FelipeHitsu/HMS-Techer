using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Exceptions
{
    class MyException : ApplicationException
    {
        public MyException(string message) : base(message)
        {

        }
    }
}
