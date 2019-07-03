namespace YouBeat.Beatmaps
{
    public struct HitWindow
    {
        public readonly float Window;
        public float Min(float time) => time - Window;
        public float Max(float time) => time + Window;

        public HitWindow(float window)
        {
            Window = window;
        }

        /// <summary>
        /// Returns an int depending on whether the time is before, during or after the expected time
        /// </summary>
        /// <param name="expectedTime">The value that <paramref name="time"/> is supposed to match, aka middle of hit window</param>
        /// <param name="time">The time to check</param>
        /// <param name="wrongPercentage">
        /// Set to how far off it was from <paramref name="expectedTime"/>.
        /// If <code>Min(<paramref name="expectedTime"/>)</code> = 500, <paramref name="time"/> = 750 and <paramref name="expectedTime"/> = 1000. 
        /// Then the variable would be set to 0.5
        /// </param>
        /// <returns>-1 if before, 0 if inside, 1 if after</returns>
        public int IsInside(float expectedTime, float time, out float wrongPercentage)
        {
            int isInside = IsInside(expectedTime, time);

            float diff = expectedTime - time;
            wrongPercentage = diff / Window;

            return isInside;
        }

        /// <summary>
        /// Returns an int depending on whether the time is before, during or after the expected time
        /// </summary>
        /// <param name="expectedTime">The value that <paramref name="time"/> is supposed to match, aka middle of hit window</param>
        /// <param name="time">The time to check</param>
        /// <returns>-1 if before, 0 if inside, 1 if after</returns>
        public int IsInside(float expectedTime, float time)
        {
            if (time < Min(expectedTime)) return -1;
            if (time > Max(expectedTime)) return  1;
            else                          return  0;
        }
    }
}
