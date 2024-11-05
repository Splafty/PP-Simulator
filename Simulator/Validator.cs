namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min)
        {
            value = min;
        }

        else if (value > max)
        {
            value = max;
        }

        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        var shortened = value.Trim();

        if (shortened.Length > max)
        {
            shortened = shortened.Substring(0, max).TrimEnd();
        }

        if (shortened.Length < min)
        {
            shortened = shortened.PadRight(min, placeholder);
        }

        if (char.IsLower(shortened[0]))
        {
            shortened = char.ToUpper(shortened[0]) + shortened.Substring(1);
        }

        return value = shortened;
    }
}