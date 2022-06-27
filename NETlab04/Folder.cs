using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab04
{
    class Folder : Component
    {
        protected List<Component> _children = new List<Component>();
        public Folder(string name) : base(name)
        {
            _size = name.Length;
        }

        public override int GetSize()
        {
            int overallSize = base.GetSize();
            foreach (var component in _children)
            {
                overallSize += component.GetSize();
            }
            return overallSize;
        }

        public void Add(Component component)
        {
            this._children.Add(component);
        }

        public void Remove(Component component)
        {
            this._children.Remove(component);
        }

        public List<Component> getAllChildren()
        {
            return _children;
        }
        public Component getChild(string name)
        {
            return _children.First(c => c.name == name);
        }
        public TextFile getTextFile(string name)
        {
            return (TextFile)_children.First(c => c.name == name);
        }
    }
}
