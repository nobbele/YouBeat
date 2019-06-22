using Microsoft.Xna.Framework;
using YouBeat.Beatmaps;

namespace YouBeat.Objects
{
    class SpecialOneBeatSquare : BeatSquare
    {
        public SpecialOneBeatSquare(BeatmapDifficulty map, Vector2 position, PlayResult playResult) : base(map, position, playResult)
        {
        }

        protected override int widthMultiplier => 2;
    }
}
