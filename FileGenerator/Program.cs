// See https://aka.ms/new-console-template for more information

using Bogus;
using FileGenerator;

int size = 100; // Default size
if (args.Length >= 1)
{
    if (!int.TryParse(args[0], out size))
    {
        Console.WriteLine("Invalid argument. Using default size of 10.");
    }
}

string path = "Weather.txt"; // Default path

var generator = new WeatherGenerator(size, path, new Faker(), new ProgressIndicator(size));

generator.Execute();

Console.WriteLine("\n\nWeather file generated!");
