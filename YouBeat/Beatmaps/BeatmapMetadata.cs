using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouBeat.Parsers;

namespace YouBeat.Beatmaps
{
    public struct BeatmapMetadata
    {
        [InfoFileProperty]
        public string SongName { get; set; }

        public BeatmapMetadata(string songName) : this()
        {
            SongName = songName;
        }
    }
}
