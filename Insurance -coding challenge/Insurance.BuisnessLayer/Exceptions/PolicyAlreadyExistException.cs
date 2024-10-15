using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BuisnessLayer.Exceptions
{
    public class PolicyAlreadyExistException : Exception
    {
        public PolicyAlreadyExistException(string message) : base(message) { }
      
    }
}
