using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat.Beatmaps
{
    public class PlayResult
    {
        public Accuracy[] Accuracies;

        public PlayResult(int noteCount)
        {
            Accuracies = new Accuracy[noteCount];
        }
    }
}
