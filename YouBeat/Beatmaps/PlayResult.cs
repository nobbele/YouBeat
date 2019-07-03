using System.Linq;

namespace YouBeat.Beatmaps
{
    public class PlayResult
    {
        public Accuracy[] Accuracies;
        public int NotesCalculated = 0;

        public float Percent {
            get {
                if (NotesCalculated == 0)
                    return 1;
                return Accuracies.Sum(acc => AccuracyHelper.ToPercent(acc)) / NotesCalculated;
            }
        }

        public PlayResult(int noteCount)
        {
            Accuracies = new Accuracy[noteCount];
        }
    }
}
