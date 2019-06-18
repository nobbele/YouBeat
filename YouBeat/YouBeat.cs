using ManagedBass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using YouBeat.Audio;
using YouBeat.Beatmaps;
using YouBeat.Screens;

namespace YouBeat
{
    public class YouBeat : Game
    {
        public static YouBeat Instance;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Rectangle ViewportBounds => graphics.GraphicsDevice.Viewport.Bounds;

        public YouBeat()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Instance = this;
        }

        IScreen currentScreen;

        public T LoadScreen<T>(T screen) where T : class, IScreen
        {
            currentScreen = screen;
            screen.Load();
            return screen;
        }

        readonly BeatmapDifficulty currentDifficulty = new BeatmapDifficulty("Harumodoki", new BeatmapNote[] {
            new BeatmapNote(940, 0),
            new BeatmapNote(2319, 1),
            new BeatmapNote(3698, 2),
            new BeatmapNote(5077, 3),
            new BeatmapNote(6457, 4),
            new BeatmapNote(7664, 5),
        }, new AudioTrack("yanaginagi - Harumodoki.mp3"), 3, 10);

        public Keys[] keys = new Keys[]
        {
            Keys.NumPad7, Keys.NumPad8, Keys.NumPad9,
            Keys.NumPad4, Keys.NumPad5, Keys.NumPad6,
            Keys.NumPad1, Keys.NumPad2, Keys.NumPad3,
            Keys.NumPad0, Keys.None,    Keys.Decimal,
        };

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AudioTrack.EngineInit();
            AudioTrack.GlobalVolume = 0.5;

            LoadScreen(new PlayingScreen(currentDifficulty));
        }

        protected override void UnloadContent()
        {
            Bass.Free();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            currentScreen.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            currentScreen.Draw(ViewportBounds, spriteBatch, gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
