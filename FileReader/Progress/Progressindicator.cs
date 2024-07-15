using FileReader.Models;

namespace FileReader.Progress;

public interface IProgressindicator
{
    void ReportProgressForOneStation(WeatherStation station);
    void InitProgress();
    void ReportProgress();
}

public class Progressindicator : IProgressindicator
{
    private int _emojiIndex;
    private volatile int _count;
    private int _cursorPosition;

    public void ReportProgressForOneStation(WeatherStation station)
    {
        Console.WriteLine($"{station.Name} Mean temperature: {station.Mean:F2}");
    }

    public void InitProgress()
    {
        Console.WriteLine("\nProgress:\n");
        _cursorPosition = Console.CursorLeft;
    }

    public void ReportProgress()
    {
        _count++;

        if (_count % 10_000_000 != 0)
            return;

        Console.SetCursorPosition(_cursorPosition, Console.CursorTop);
        Console.Write($"Count: {_count:N0} {GetEmoji()}");
    }

    string GetEmoji()
    {
        if (_emojiIndex >= emojis.Length)
            _emojiIndex = 0;

        return emojis[_emojiIndex++];
    }

    private string[] emojis = new string[]
    {
        "\U0001F600", // Smiley face emoji
        "\U0001F603", // Big smile emoji
        "\U0001F604", // Laughing face emoji
        "\U0001F60A", // Blushing face emoji
        "\U0001F60D", // Heart eyes emoji
        "\U0001F618", // Kissing face with heart emoji
        "\U0001F61C", // Face with stuck-out tongue and winking eye emoji
        "\U0001F61D", // Squinting face with tongue emoji
        "\U0001F61E", // Disappointed face emoji
        "\U0001F620", // Angry face emoji
    };
}
