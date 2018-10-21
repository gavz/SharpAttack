using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpAttack.Utils
{
  public class Printing
  {

    /// <summary>
    /// Takes a string and returns and splits it into an array of strings
    /// </summary>
    /// <remarks>
    /// Adapted from: http://c-sharp-tutorials-4-0.blogspot.com/2013/02/c-split-strings-by-length.html
    /// </remarks>
    static List<string> SplitStringsByLength(int len, string str)
    {
      List<string> strings = new List<string>();
      while (!String.IsNullOrEmpty(str))
      {
        try
        {
          strings.Add(str.Substring(0, len));
          str = str.Remove(0, len);
        }
        catch
        {
          strings.Add(str);
          break;
        }
      }
      return strings;
    }

    /// <summary>
    /// Prints out green text with [S] prepended
    /// </summary>
    public static void Success(string message)
    {
      ConsoleColor originalColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("[S] ");
      Console.ForegroundColor = originalColor;
      Console.WriteLine(message);
    }

    /// <summary>
    /// Prints out regular colored text with [i] prepended
    /// </summary>
    public static void Informational(string message)
    {
      Console.WriteLine($"[i] {message}");
    }

    /// <summary>
    /// Prints out red text with [!] prepended
    /// </summary>
    public static void Error(string message)
    {
      ConsoleColor originalColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine($"[!] {message}");
      Console.ForegroundColor = originalColor;
    }

    /// <summary>
    /// Prints out unformatted text preceeded with a newline
    /// </summary>
    public static void CmdOutput(string message)
    {
      Console.WriteLine();
      Console.WriteLine($"{message}");
    }

    /// <summary>
    /// Prints out dark blue text surrounded by "===";
    /// </summary>
    public static void CmdOutputHeading(string message)
    {
      ConsoleColor originalColor = Console.BackgroundColor;
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.WriteLine($"=== {message} ===");
      Console.BackgroundColor = originalColor;
    }

    /// <summary>
    /// Prints out blue text with * prepended
    /// </summary>
    public static void CmdOutputItem(string message)
    {
      ConsoleColor originalFgColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write(" * ");
      Console.ForegroundColor = originalFgColor;
      Console.WriteLine($"{message}");
    }

    public static void TableHeader(string heading, string description, string key, string value, int gap = 30)
    {
      int keyLength = key.Length;
      int valueLength = value.Length;
      string keyLine = new string('-', keyLength);
      string valueLine = new string('-', valueLength);

      int offset = gap - key.Length;
      string offsetString = new string(' ', offset);
      string header = String.Format(@"

  {0}

  {1}

  {2}{3}{4}
  {5}{6}{7}", heading, description, key, offsetString, value, keyLine, offsetString, valueLine);

      Console.WriteLine(header);
    }

    public static void TableItem(string key, string value, int gap = 30)
    {
      int offset = gap - key.Length;
      string offsetString = new string(' ', offset);
      Console.Write($"  {key}{offsetString}");
      List<string> valueStrings = SplitStringsByLength(75, value);
      Console.WriteLine(valueStrings[0]);

      if (valueStrings.Count > 0)
      {
        string gapString = new string(' ', gap + 2);
        foreach (String str in valueStrings.GetRange(1, valueStrings.Count - 1))
        {
          value = str;
          if (str.StartsWith(" "))
          {
            value = str.Substring(1, str.Length - 1);
          }
          Console.WriteLine($"{gapString}{value}");
        }
      }
    }

    /// <summary>
    /// Prints the SharpAttack Prompt
    /// </summary>
    public static void Prompt()
    {
      Console.WriteLine();
      Console.Write("Atk!> ");
    }

    /// <summary>
    /// Prints the SharpAttack startup text
    /// </summary>
    public static void StartUp()
    {
      Console.WriteLine(@"
SharpAttack v20181020
https://www.github.com/jaredhaight/SharpAttack
");
    }
  }
}
