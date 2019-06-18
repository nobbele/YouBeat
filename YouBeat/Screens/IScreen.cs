using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouBeat.Drawables;

namespace YouBeat.Screens
{
    public interface IScreen : ILoadable, Drawables.IDrawable, IUpdatable
    {

    }
}
