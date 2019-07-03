namespace YouBeat.Beatmaps
{
    public struct BeatmapNote
    {
        public readonly float time;
        public readonly int position;

        public BeatmapNote(float time, int position)
        {
            this.time = time;
            this.position = position;
        }
    }
}
