namespace YouBeat.Beatmaps
{
    public class PlayResult
    {
        public Accuracy[] Accuracies;
        public int NotesClicked = 0;

        public PlayResult(int noteCount)
        {
            Accuracies = new Accuracy[noteCount];
        }
    }
}
