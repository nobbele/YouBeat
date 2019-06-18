using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Beatmaps
{
    public class BeatmapNote
    {
        public double time;
        public int position;

        public BeatmapNote(double time, int position)
        {
            this.time = time;
            this.position = position;
        }
    }
}
