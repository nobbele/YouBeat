using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YouBeat.Audio;
using YouBeat.Beatmaps;

namespace YouBeat.Drawables
{
    public class BeatSquare : IDrawable, IUpdatable
    {
        public BeatmapNote Note { get; protected set; }
        public double SpawnTime { get; protected set; }
        public Vector2 Position { get; protected set; }
        public int MapIndex { get; protected set; }
        public double BeatTime => Note?.time ?? 0;
        public int Index => (int)(Position.Y * 3 + Position.X);
        public Keys Key => YouBeat.Instance.keys[Index];

        protected bool isLoaded;

        private readonly BeatmapDifficulty map;
        private readonly PlayResult playResult;

        Texture2D t;
        Color color = Color.White;

        public BeatSquare(BeatmapDifficulty map, Vector2 position, PlayResult playResult)
        {
            this.map = map;
            this.playResult = playResult;
            Position = position;

            t = new Texture2D(YouBeat.Instance.GraphicsDevice, 1, 1);
            t.SetData(new Color[] { Color.White });
        }

        public void LoadNote(BeatmapNote note, int mapIndex)
        {
            MapIndex = mapIndex;
            Note = note;
            SpawnTime = map.Track.GetPosition();
        }

        public void Update(GameTime gameTime)
        {
            if (Note == null)
            {
                color = Color.White;
                return;
            }

            double trackPosition = map.Track.GetPosition();

            if (map.HitWindow.IsInside(BeatTime, trackPosition) == 1)
                Note = null;

            double progress = (trackPosition - SpawnTime) / (BeatTime - SpawnTime);
            color = Color.Lerp(Color.Blue, Color.Red, (float)progress);

            if (Keyboard.GetState().IsKeyDown(Key) && map.HitWindow.IsInside(BeatTime, trackPosition, out double wrongPercentage) == 0)
            {
                color = Color.Black;
                double diff = Math.Abs(Note.position - trackPosition); 
                Note = null;
                playResult.Accuracies[MapIndex] = AccuracyHelper.FromPercent(wrongPercentage);
                Console.WriteLine("Received Scoring: " + AccuracyHelper.FromPercent(wrongPercentage));
            }
        }

        protected virtual int widthMultiplier => 1;

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(t, 
                             rect.PercentagePoint(1f / 3 * Position.X + 0.01f,
                                                  1f / 4 * Position.Y + 0.01f, 
                                                  (1f / 3 * widthMultiplier) - 0.02f, 
                                                  1f / 4 - 0.02f),
                             color);
        }
    }
}
