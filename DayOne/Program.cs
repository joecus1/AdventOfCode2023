using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

var assembly = Assembly.GetExecutingAssembly();
const string resourceName = "DayOne.Calibrations.txt";

string rx1 = @"\d";
string rx2 = @"\d|one|two|three|four|five|six|seven|eight|nine";


using (Stream stream = assembly.GetManifestResourceStream(resourceName))
using (StreamReader sr = new StreamReader(stream))
{
    var total = 0;
    var line = sr.ReadLine();
    while (line != null)
    {
        var left = Regex.Match(line, rx2);
        var right = 
            Regex.Match(line, rx2, RegexOptions.RightToLeft);
        total = total + Helpers.ParseMatch(left.Value) * 10 +
                Helpers.ParseMatch(right.Value);
        
        line = sr.ReadLine();
    }
    sr.Close();
    Console.WriteLine(total);
}

class Helpers
{
    public static int ParseMatch(string st) => st switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        var d => int.Parse(d)
    };
}
