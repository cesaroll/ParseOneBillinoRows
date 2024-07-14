// See https://aka.ms/new-console-template for more information

using FileReader;
using FileReader.Models;
using FileReader.Progress;
using FileReader.Services;

string path = "Weather.txt";
var progressIndicator = new Progressindicator();
var weatherService = new WeatherReaderService(new WeatherStations(), progressIndicator);

var reader = new FileReader.FileReader(
    path, 
    weatherService,
    progressIndicator);

reader.Read();