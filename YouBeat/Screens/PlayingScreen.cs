using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YouBeat.Beatmaps;
using YouBeat.Drawables;

namespace YouBeat.Screens
{
    public class PlayingScreen : IScreen
    {
        public BeatmapDifficulty Map;
        public PlayResult playResult;

        public PlayingScreen(BeatmapDifficulty map)
        {
            Map = map;
            playResult = new PlayResult(map.BeatmapNotes.Length);
        }

        DrawableContainer<BeatSquare> beatSquares = new DrawableContainer<BeatSquare>();

        public void Load()
        {
            for(int i = 0; i < 9; i++)
            {
                int x = i % 3;
                int y = i / 3;

                beatSquares.Children.Add(new BeatSquare(Map, new Vector2(x, y), playResult));
            }
            beatSquares.Children.Add(new SpecialOneBeatSquare(Map, new Vector2(0, 3), playResult));
            beatSquares.Children.Add(new BeatSquare(Map, new Vector2(2, 3), playResult));

            Map.Track.Load();
            Map.Track.Play();
        }

        bool numlockWarning = false;

        public void Update(GameTime gameTime)
        {
            if(!Keyboard.GetState().NumLock && !numlockWarning)
            {
                numlockWarning = true;
                Map.Track.Pause();
            }
            else if (Keyboard.GetState().NumLock && numlockWarning)
            {
                numlockWarning = false;
                Map.Track.Play();
            }

            double trackPosition = Map.Track.GetPosition();
            IEnumerable<BeatmapNote> notesToShow = Map.BeatmapNotes.Where(note => trackPosition > (note.time - Map.ArInMs()) && trackPosition < (Map.HitWindow.Max(note.time)));
            foreach(BeatmapNote note in notesToShow)
            {
                int index = note.position;
                int mapIndex = Array.IndexOf(Map.BeatmapNotes, note);
                BeatSquare bs = beatSquares.Children[index];
                if (bs.Note == null && playResult.Accuracies[mapIndex] == Accuracy.None)
                    bs.LoadNote(note, mapIndex);
            }

            beatSquares.Update(gameTime);
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            beatSquares.Draw(rect.PercentagePoint(0.25f, 0.25f, 0.5f, 0.5f), spriteBatch, gameTime);
        }

         
        public void Unload()
        {
            Map.Track.Stop();
            Map.Track.Unload();
        }
    }
}
