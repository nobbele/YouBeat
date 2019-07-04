using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Beatmaps
{
    class BeatmapStoreInfoFile : BeatmapStoreInfo
    {
        protected readonly string beatmapPath;

        public BeatmapStoreInfoFile(BeatmapMetadata metadata, string beatmapPath) : base(metadata)
        {
            this.beatmapPath = beatmapPath;
        }

        public override Beatmap LoadBeatmap()
        {
            throw new NotImplementedException();
        }
    }
}
