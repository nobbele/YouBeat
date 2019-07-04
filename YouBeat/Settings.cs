using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat
{
    public class Settings
    {
        public Keys[] BeatSquareKeys = new Keys[]
        {
            Keys.NumPad7, Keys.NumPad8, Keys.NumPad9,
            Keys.NumPad4, Keys.NumPad5, Keys.NumPad6,
            Keys.NumPad1, Keys.NumPad2, Keys.NumPad3,
            Keys.NumPad0, Keys.None,    Keys.Decimal,
        };
    }
}
