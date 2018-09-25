using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpAttack.Utils
{
  public class Printing
  {
    public static void Success(string message)
    {
      ConsoleColor originalColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("[S] ");
      Console.ForegroundColor = originalColor;
      Console.WriteLine(message);
    }

    public static void Informational(string message)
    {
      Console.WriteLine($"[i] {message}");
    }

    public static void Error(string message)
    {
      ConsoleColor originalColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine($"[!] {message}");
      Console.ForegroundColor = originalColor;
    }

    public static void CmdOutput(string message)
    {
      Console.WriteLine();
      Console.WriteLine($"{message}");
    }

    public static void CmdOutputHeading(string message)
    {
      ConsoleColor originalColor = Console.BackgroundColor;
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.WriteLine($"=== {message} ===");
      Console.BackgroundColor = originalColor;
    }

    public static void CmdOutputItem(string message)
    {
      ConsoleColor originalFgColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write(" * ");
      Console.ForegroundColor = originalFgColor;
      Console.WriteLine($"{message}");
    }

    public static void Prompt()
    {
      Console.WriteLine();
      Console.Write("Atk!> ");
    }

    public static void StartUp()
    {
      Console.WriteLine(@"
SharpAttack v0.0.1 
Super Special WAAD Edition
https://www.github.com/jaredhaight/SharpAttack
");
    }
  }
}
