using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using YouBeat.Beatmaps;
using YouBeat.Objects;

namespace YouBeat.Screens
{
    public class PlayingScreen : IScreen
    {
        bool IsLoaded = false;
        bool ILoadable.IsLoaded() => IsLoaded;

        public BeatmapDifficulty Map;
        public PlayResult playResult;

        public PlayingScreen(BeatmapDifficulty map)
        {
            Map = map;
            playResult = new PlayResult(map.BeatmapNotes.Length);
            accuracyDisplay = new AccuracyDisplay(playResult);
        }

        DrawableContainer<BeatSquare> beatSquares = new DrawableContainer<BeatSquare>();
        AccuracyDisplay accuracyDisplay;

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

            Map.Track.Value.Play();

            IsLoaded = true;
        }

        bool numlockWarning = false;

        public void Update(GameTime gameTime)
        {
            if(!Keyboard.GetState().NumLock && !numlockWarning)
            {
                numlockWarning = true;
                Map.Track.Value.Pause();
            }
            else if (Keyboard.GetState().NumLock && numlockWarning)
            {
                numlockWarning = false;
                Map.Track.Value.Play();
            }

            float trackPosition = Map.Track.Value.GetPosition();
            IEnumerable<BeatmapNote> notesToShow = Map.BeatmapNotes.Where(note => trackPosition > (note.time - Map.ArInMs()) && trackPosition < (Map.HitWindow.Max(note.time)));
            foreach(BeatmapNote note in notesToShow)
            {
                int index = note.position;
                int mapIndex = Array.IndexOf(Map.BeatmapNotes, note);
                BeatSquare bs = beatSquares.Children[index];
                if (bs.Note == null && playResult.Accuracies[mapIndex] == Accuracy.None)
                    bs.SetNoteData(note, mapIndex);
            }

            beatSquares.Update(gameTime);
            accuracyDisplay.Update(gameTime);
        }

        public void Draw(Rectangle rect, SpriteBatch spriteBatch, GameTime gameTime)
        {
            beatSquares.Draw(rect.PercentagePoint(0.25f, 0.25f, 0.5f, 0.5f), spriteBatch, gameTime);
            accuracyDisplay.Draw(rect.PercentagePoint(0.5f, 0.1f, 0.1f, 0.1f), spriteBatch, gameTime);
        }

         
        public void Unload()
        {
            Map.Track.Value.Stop();
            Map.Track.Value.Unload();

            IsLoaded = false;
        }
    }
}
