namespace YouBeat.Beatmaps
{
    public enum Accuracy
    {
        None = 0,
        Bad,
        Okay,
        Good,
        Perfect
    }

    public static class AccuracyHelper
    {
        public static Accuracy FromPercent(float percent)
        {
            if      (percent < 0.2f) return Accuracy.Perfect;
            else if (percent < 0.4f) return Accuracy.Good;
            else if (percent < 0.6f) return Accuracy.Okay;
            else                     return Accuracy.Bad;
        }
        public static float ToPercent(Accuracy acc)
        {
            switch (acc)
            {
                case Accuracy.Bad:
                    return 0.3f;
                case Accuracy.Okay:
                    return 0.6f;
                case Accuracy.Good:
                    return 0.8f;
                case Accuracy.Perfect:
                    return 1f;
            }
            return 0f;
        }
    }
}
