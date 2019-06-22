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
