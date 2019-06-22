using YouBeat.Audio;

namespace YouBeat.Beatmaps
{
    public class BeatmapDifficulty
    {
        public string Name;
        public BeatmapNote[] BeatmapNotes;
        public AudioTrack Track;
        public int AR;
        public int AD;
        public HitWindow HitWindow;

        public BeatmapDifficulty(string name, BeatmapNote[] beatmapNotes, AudioTrack track, int ar, int ad)
        {
            Name = name;
            BeatmapNotes = beatmapNotes;
            Track = track;
            AR = ar;
            AD = ad;
            HitWindow = new HitWindow(AdInMs());
        }

        public double ArInMs()
        {
            return (double)-AR * 75 + 1000; 
        }
        public double AdInMs()
        {
            return (double)-AD * 75 + 800;
        }
    }
}
