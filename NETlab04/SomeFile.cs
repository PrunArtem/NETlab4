using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab04
{
    class SomeFile : Component
    {
        public SomeFile(string name, int size) : base(name)
        {
            this._size = size + name.Length;
        }

        public override int GetSize()
        {
            return base.GetSize();
        }
    }
}
