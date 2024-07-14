namespace FileGenerator;

public interface IProgressIndicator
{
    void PintInitialProgressBar();
    void PrintProgress(int doneCount);
}

public class ProgressIndicator : IProgressIndicator
{
    private readonly int _modVal;
    private int _currPerc;
    private int _emojiIndex;
    private int _cursorPosition;
    private int _percCursor;

    public ProgressIndicator(int size)
    {
        _modVal = Math.Max(1, size / 100);
    }

    public void PintInitialProgressBar()
    {
        Console.Write($"\n   0% ");
        _percCursor = Console.CursorLeft - 5;
        _cursorPosition = Console.CursorLeft;
    }
    
    public void PrintProgress(int doneCount)
    {
        if (_modVal != 0 && doneCount % _modVal == 0)
        {
            _currPerc++;
            
            _cursorPosition = Console.CursorLeft;

            if (_currPerc % 2 == 0)
            {
                Console.Write(GetEmoji());
                _cursorPosition = Console.CursorLeft;
            }
        
            Console.SetCursorPosition(_percCursor, Console.CursorTop);
            Console.Write($"{_currPerc, 3}%");
        
            Console.SetCursorPosition(_cursorPosition, Console.CursorTop);
        }
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