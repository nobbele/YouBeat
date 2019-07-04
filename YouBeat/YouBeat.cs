using ManagedBass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using YouBeat.Audio;
using YouBeat.Beatmaps;
using YouBeat.DependencyInjection;
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

        readonly BeatmapDifficulty testDifficulty = new BeatmapDifficulty("Harumodoki", new BeatmapNote[] {
            new BeatmapNote(940, 0),
            new BeatmapNote(1284, 3),

            new BeatmapNote(1629, 1),
            new BeatmapNote(1974, 4),

            new BeatmapNote(2319, 2),
            new BeatmapNote(2664, 5),
            new BeatmapNote(3008, 8),
            new BeatmapNote(3353, 6),

            new BeatmapNote(4043, 7),
            new BeatmapNote(4388, 4),
            new BeatmapNote(4733, 1),

            new BeatmapNote(5077, 9),

            new BeatmapNote(5422, 3),
            new BeatmapNote(5767, 4),
            new BeatmapNote(6112, 5),

            new BeatmapNote(6457, 6),
            new BeatmapNote(6543, 3),
            new BeatmapNote(6629, 6),
            new BeatmapNote(6715, 3),
            new BeatmapNote(6802, 6),
            new BeatmapNote(6888, 3),
            new BeatmapNote(6974, 6),

            new BeatmapNote(7146, 1),
            new BeatmapNote(7233, 2),
            new BeatmapNote(7319, 1),
            new BeatmapNote(7405, 2),
            new BeatmapNote(7491, 1),
            new BeatmapNote(7664, 9),
        }, new AudioTrack("yanaginagi - Harumodoki.mp3"), ar: 9, ad: 8);

        public FontStore fontStore;
        public Settings settings;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            fontStore = new FontStore(new ContentManager(Content.ServiceProvider, Path.Combine(Content.RootDirectory, "Fonts")));
            fontStore.Add("Arial");

            settings = new Settings();

            DependencyInjectedObject.AddDependency(fontStore);
            DependencyInjectedObject.AddDependency(settings);

            AudioTrack.EngineInit();
            AudioTrack.GlobalVolume = 0.5f;

            LoadScreen(new PlayingScreen(testDifficulty));
        }

        protected override void UnloadContent()
        {
            Bass.Free();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

#if DEBUG_RELEASE
            updateErrorMessages.Clear();

            try
            {
#endif
            currentScreen.Update(gameTime);
#if DEBUG_RELEASE
            }
            catch (Exception e)
            {
                updateErrorMessages.Add(e);
            }
#endif

        }

        private readonly List<Exception> updateErrorMessages = new List<Exception>();
        private readonly List<Exception> drawErrorMessages = new List<Exception>();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

#if DEBUG_RELEASE
            drawErrorMessages.Clear();

            try
            {
#endif
                currentScreen.Draw(ViewportBounds, spriteBatch, gameTime);

#if DEBUG_RELEASE
            }
            catch (Exception e)
            {
                drawErrorMessages.Add(e);
            }

            foreach (Exception error in updateErrorMessages)
            {
                spriteBatch.DrawString(fontStore["Arial"], $"Update Error '{error}'", ViewportBounds.PercentagePoint(0, 0), Color.Red);
            }
            foreach (Exception error in drawErrorMessages)
            {
                spriteBatch.DrawString(fontStore["Arial"], $"Draw Error '{error}'", ViewportBounds.PercentagePoint(0, 0), Color.Red);
            }
#endif

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
