using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab04
{
    abstract class Component
    {
        public string name { get; set; }
        protected int _size;
        public Component(string name)
        {
            this.name = name;
        }
        public virtual int GetSize() {
            return _size;
        }
    }
}
