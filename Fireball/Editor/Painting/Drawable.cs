using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Fireball.Editor.Painting
{
    abstract class Drawable
    {
        public abstract void Draw(Graphics gfx, Point offset); 
    }
}
