using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using YouBeat.Beatmaps;
using YouBeat.Parsers;

namespace YouBeat.Store
{
    public class BeatmapStore : ILoadable
    {
        public readonly string RootDirectory;
        public bool IsLoaded { get; set; }

        protected List<BeatmapStoreInfo> m_beatmaps = new List<BeatmapStoreInfo>();

        public BeatmapStore(string rootDirectory)
        {
            RootDirectory = rootDirectory;

            if (!Directory.Exists(RootDirectory))
                Directory.CreateDirectory(RootDirectory);
        }

        public void Load()
        {
            foreach(string dir in Directory.EnumerateDirectories(RootDirectory))
            {
                if(IsValidBeatmap(dir))
                {
                    string metadataPath = Path.Combine(dir, "metadata.if");
                    BeatmapMetadata metadata = InfoFileParser.Deserialize<BeatmapMetadata>(metadataPath);
                    m_beatmaps.Add(new BeatmapStoreInfoFile(metadata, dir));
                }
            }
        }

        public void Add(BeatmapStoreInfo beatmap)
        {
            m_beatmaps.Add(beatmap);
        } 

        private bool IsValidBeatmap(string path)
        {
            IEnumerable<string> files = Directory.GetFiles(path);
            return files.Any(file => file.EndsWith("ybm")) && files.Where(file => file.EndsWith("metadata.if")).Count() == 1;
        }

        public void Unload()
        {
            m_beatmaps.Clear();
        }
    }
}
