namespace YouBeat.Beatmaps
{
    public class Beatmap
    {
        public BeatmapDifficulty[] Difficulties;
        public BeatmapMetadata Metadata;

        public Beatmap(BeatmapDifficulty[] difficulties, BeatmapMetadata metadata)
        {
            Difficulties = difficulties;
            Metadata = metadata;
        }
    }
}
