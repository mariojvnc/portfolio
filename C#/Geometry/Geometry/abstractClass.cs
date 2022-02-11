using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    abstract class abstractClass
    {
        public string Name { get; private set; }

        protected abstractClass(string name)
        {
            Name = name;
        }
    }
}
