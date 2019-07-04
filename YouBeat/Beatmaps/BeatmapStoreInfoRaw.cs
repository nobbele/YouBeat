using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Beatmaps
{
    class BeatmapStoreInfoRaw : BeatmapStoreInfo
    {
        protected Beatmap beatmap;

        public BeatmapStoreInfoRaw(BeatmapMetadata metadata, Beatmap beatmap) : base(metadata)
        {
            this.beatmap = beatmap;
        }

        public override Beatmap LoadBeatmap() => beatmap;
    }
}
