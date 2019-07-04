using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YouBeat.Beatmaps;
using YouBeat.DependencyInjection;
using YouBeat.Store;

namespace YouBeat.Objects
{
    public class BeatSquare : DependencyInjectedObject, IDrawable, IUpdateable
    {
        [DependencyInjectedProperty]
        protected Settings settings { get; set; }
        [DependencyInjectedProperty]
        protected TextureStore textureStore { get; set; }

        public BeatmapNote? Note { get; protected set; }
        public float SpawnTime { get; protected set; }
        public Vector2 Position { get; protected set; }
        public int MapIndex { get; protected set; }
        public float BeatTime => Note?.time ?? 0;
        public int Index => (int)(Position.Y * 3 + Position.X);
        public Keys Key => settings.BeatSquareKeys[Index];

        private readonly BeatmapDifficulty map;
        private readonly PlayResult playResult;

        Color color = Color.White;

        public BeatSquare(BeatmapDifficulty map, Vector2 position, PlayResult playResult) : base()
        {
            this.map = map;
            this.playResult = playResult;
            Position = position;
        }

        public void SetNoteData(BeatmapNote note, int mapIndex)
        {
            MapIndex = mapIndex;
            Note = note;
            SpawnTime = map.Track.GetPosition();
        }

        public void Update(GameTime gameTime)
        {
            if (!Note.HasValue)
            {
                color = Color.White;
                return;
            }

            float trackPosition = map.Track.GetPosition();

            if (map.HitWindow.IsInside(BeatTime, trackPosition) == 1)
            {
                Note = null;
                playResult.Accuracies[MapIndex] = Accuracy.None;
                playResult.NotesCalculated++;
                Console.WriteLine("Received Scoring: " + Accuracy.None);
                return;
            }

            float progress = ((trackPosition - SpawnTime) / (BeatTime - SpawnTime));
            color = Color.Lerp(Color.Blue, Color.Red, progress);

            if (Keyboard.GetState().IsKeyDown(Key) && map.HitWindow.IsInside(BeatTime, trackPosition, out float wrongPercentage) == 0)
            {
                color = Color.Black;
                float diff = Math.Abs(Note.Value.position - trackPosition); 
                Note = null;
                playResult.Accuracies[MapIndex] = AccuracyHelper.FromPercent(wrongPercentage);
                playResult.NotesCalculated++;
                Console.WriteLine("Received Scoring: " + AccuracyHelper.FromPercent(wrongPercentage));
            }
        }

        protected virtual int widthMultiplier => 1;

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(textureStore["BeatSquareTexture"], 
                             rect.PercentagePoint(1f / 3 * Position.X + 0.01f,
                                                  1f / 4 * Position.Y + 0.01f, 
                                                  1f / 3 * widthMultiplier - 0.02f, 
                                                  1f / 4 - 0.02f),
                             color);
        }
    }
}
