using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper.Exception
{
    public class KORMapperException : System.Exception
    {
        public KORMapperException() { }

        public KORMapperException(string message) : base(message) { }

        public KORMapperException(string message, System.Exception inner) : base(message, inner) { }
    }
}
