﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat
{
    public interface ISize
    {
        Vector2 GetSize(Rectangle view);
    }
}
