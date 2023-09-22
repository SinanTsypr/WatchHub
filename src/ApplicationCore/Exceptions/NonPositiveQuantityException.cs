using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class NonPositiveQuantityException : Exception
    {
        public NonPositiveQuantityException() : base("Quantity must be positive.")
        {
            
        }
    }
}
