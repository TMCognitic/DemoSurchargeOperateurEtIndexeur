using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexeur
{
    public class BinaryVisitor
    {
        public int Value { get; set; }

        public int this[int column]
        {
            get 
            {
                if (column < 0)
                    throw new InvalidOperationException();

                return (Value >> column) % 2; 
            }
        }
    }
}
