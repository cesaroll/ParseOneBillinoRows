// See https://aka.ms/new-console-template for more information

using FileReader.Progress;
using FileReader.Services;


string path = "Weather.txt";
var progressIndicator = new Progressindicator();
var weatherService = new WeatherReaderService(progressIndicator);

var reader = new FileReader.FileReader(
    path,
    weatherService,
    progressIndicator);

Console.WriteLine("Starting to read file...\n");

reader.Read();

void Usage()
{
    Console.WriteLine("Usage: FileReader [threadCount] [lineCount]");
}
