using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using YouBeat.Beatmaps;

namespace YouBeat.Drawables
{
    class SpecialOneBeatSquare : BeatSquare
    {
        public SpecialOneBeatSquare(BeatmapDifficulty map, Vector2 position, PlayResult playResult) : base(map, position, playResult)
        {
        }

        protected override int widthMultiplier => 2;
    }
}
