
public static class MoodFactory
{
    public static Mood GetMood(int points)
    {
        if (points < -5) return new Angry();
        if (points >= -5 && points <= 0) return new Sad();
        if (points >= 1 && points <= 15) return new Happy();
        return new JavaScript();

    }
}
