using System.Diagnostics;
using Newtonsoft.Json;

class OpenFromFile
{
    private static String[] messages = [
      "OFF 1.0\n(c) 2024, William Larsson/TheWilley\nOpen the containing folder of a specified file path\n\nUsage:\nOFF path*\n\npath*          - The path to a file\n\nExample: off C:\\Users\\TheWilley\\Videos\\example.mp4",
      "Error: File path does not exist",
      "Error: Could not open explorer"
    ];


    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            // Prints help menu
            SendMessage(0);
        }
        else
        {
            string path = args[0];
            if (!File.Exists(path))
            {
                // Prints path error
                SendMessage(1);
            }
            else
            {
                try
                {
                    Process.Start("explorer.exe", Path.GetDirectoryName(path));
                }
                catch
                {
                    // Prints explorer error
                    SendMessage(2);
                }
            }
        }
    }

    public static void SendMessage(int index)
    {
        Console.WriteLine(messages[index]);
    }
}
