using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab04
{
    class TextFile : Component
    {
        public string text { get; set; }
        public TextFile(string name) : base(name)
        {
            this._size = name.Length;
        }
        private void Resize()
        {
            _size = name.Length + text.Length;
        }

        public override int GetSize()
        {
            Resize();
            return base.GetSize();
        }
    }
}
