using System;
using YouBeat.Audio;

namespace YouBeat.Beatmaps
{
    public class BeatmapDifficulty
    {
        public string Name;
        public BeatmapNote[] BeatmapNotes;
        public LazyLoadable<AudioTrack> Track;
        public int AR;
        public int AD;
        public HitWindow HitWindow;

        public BeatmapDifficulty(string name, BeatmapNote[] beatmapNotes, AudioTrack track, int ar, int ad)
        {
            Name = name;
            BeatmapNotes = beatmapNotes;
            Track = new LazyLoadable<AudioTrack>(track);
            AR = ar;
            AD = ad;
            HitWindow = new HitWindow(AdInMs());
        }

        public float ArInMs()
        {
            return (float)-AR * 80 + 1000; 
        }
        public float AdInMs()
        {
            return (float)-AD * 75 + 800;
        }
    }
}
