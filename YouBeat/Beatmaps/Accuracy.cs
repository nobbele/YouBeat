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
        public static Accuracy FromPercent(double percent)
        {
            if      (percent < 0.2) return Accuracy.Perfect;
            else if (percent < 0.4) return Accuracy.Good;
            else if (percent < 0.6) return Accuracy.Okay;
            else                    return Accuracy.Bad;
        }
        public static double ToPercent(Accuracy acc)
        {
            switch (acc)
            {
                case Accuracy.Bad:
                    return 0.3;
                case Accuracy.Okay:
                    return 0.6;
                case Accuracy.Good:
                    return 0.8;
                case Accuracy.Perfect:
                    return 1;
            }
            return 0;
        }
    }
}
