using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Beatmaps
{
    public class Beatmap
    {
        public BeatmapDifficulty[] Difficulties;
        public string SongName;

        public Beatmap(BeatmapDifficulty[] difficulties, string songName)
        {
            Difficulties = difficulties;
            SongName = songName;
        }
    }
}
