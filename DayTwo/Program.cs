using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
const string resourceName = "DayTwo.Input2.txt";

using var stream = assembly.GetManifestResourceStream(resourceName);
using var sr = new StreamReader(stream);

var line = sr.ReadLine();
var gameNum = 1;
var total = 0;

while (line != null)
{
    if (Helpers.ValidGame(line))
    {
        Console.WriteLine(line);
        total += gameNum;
    }
    line = sr.ReadLine();
    gameNum++;
}

Console.WriteLine(total);

class Helpers
{
    public static bool ValidGame(string line)
    {
        int i = line.IndexOf(':') + 1;
        int maxRed = 0;
        int maxBlue = 0;
        int maxGreen = 0;
        int numCubes = 0;
        int totalCubes = 0;
        int maxTotalCubes = 0;
        while (i < line.Length)
        {
            char c = line[i];
            switch (c)
            {
                case 'r':
                    maxRed = Math.Max(maxRed, numCubes);
                    i += "red".Length;
                    break;
                case 'b':
                    maxBlue = Math.Max(maxBlue, numCubes);
                    i += "blue".Length;
                    break;
                case 'g' :
                    maxGreen = Math.Max(maxGreen, numCubes);
                    i += "green".Length;
                    break;
                case ' ' :
                    i++;
                    break;
                case ',':
                    totalCubes += numCubes;
                    numCubes = 0;
                    i++;
                    break; 
                case ';':
                    totalCubes += numCubes;
                    numCubes = 0;
                    maxTotalCubes = Math.Max(totalCubes, maxTotalCubes);
                    totalCubes = 0;
                    i++;
                    break;
                default:
                    numCubes = (numCubes * 10) + (c - '0');
                    i++;
                    break;
            }
        }

        maxTotalCubes = Math.Max(totalCubes, maxTotalCubes);
        
        return maxRed <= 12 && maxGreen <= 13 && maxBlue <= 14 &&
               maxTotalCubes <= 39;
    }
}