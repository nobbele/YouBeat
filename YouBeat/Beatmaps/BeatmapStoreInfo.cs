using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Beatmaps
{
    public abstract class BeatmapStoreInfo
    {
        public readonly BeatmapMetadata Metadata;

        public BeatmapStoreInfo(BeatmapMetadata metadata)
        {
            Metadata = metadata;
        }

        public abstract Beatmap LoadBeatmap();
    }
}
