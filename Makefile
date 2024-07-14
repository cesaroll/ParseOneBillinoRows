generate:
	time ~/dotnet/ParseOneBillionRows/FileGenerator/bin/Release/net8.0/FileGenerator 1000
	echo ""
	wc -l Weather.txt

build:
	clear
	dotnet build -c Release

read:
	time ~/dotnet/ParseOneBillionRows/FileReader/bin/Release/net8.0/FileReader
