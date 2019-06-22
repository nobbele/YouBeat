using Microsoft.Xna.Framework;
using System;

namespace YouBeat
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Game game = new YouBeat()
            {
                IsFixedTimeStep = false
            })
            {
                game.Run();
            }
        }
    }
}
