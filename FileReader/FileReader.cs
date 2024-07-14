using System.Globalization;
using FileReader.Progress;
using FileReader.Services;

namespace FileReader;

public class FileReader
{
    private string _path;
    private readonly IWeatherReaderService _weatherReaderService;
    private readonly IProgressindicator _progressindicator;

    public FileReader(string path, IWeatherReaderService weatherReaderService, IProgressindicator progressindicator)
    {
        _path = path;
        _weatherReaderService = weatherReaderService;
        _progressindicator = progressindicator;
    }

    public void Read()
    {
        using StreamReader reader = new StreamReader(_path);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var (stationName, temperature) = GetMeasurement(line);
            var station = _weatherReaderService.AddMeasurement(stationName, temperature);
        }
        
    }
    
    private static (string StationName, float Temperature) GetMeasurement(string line)
    {
        var parts = line.Split(';');
        return (
            parts[0], 
            float.Parse(parts[1], CultureInfo.InvariantCulture) 
        );
    }
}