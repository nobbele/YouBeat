﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat
{
    public interface ILoadable
    {
        void Load();
        void Unload();
        bool IsLoaded();
    }
}
