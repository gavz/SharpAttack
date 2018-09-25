using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpAttack.Commands;
using SharpAttack.Utils;

namespace SharpAttack
{
  class SharpAttack
  {
    public static Dictionary<string, Command> AvailableCommands = new Dictionary<string, Command>(StringComparer.OrdinalIgnoreCase);

    

    static void Main(string[] args)
    {
      // Register Commands. Probably a better way to do this.
      new FindLocalAdmin().Initialize();
      new GetLoggedOnUsers().Initialize();
      new PowerShell().Initialize();
      new WmiExec().Initialize();

      Printing.StartUp();

      // Start Processing
      if (args.Length > 0)
      {
        Proccessing.UserInput(args);
      }
      else
      {
        while (true)
        {
          Printing.Prompt();
          string input = Console.ReadLine();
          Proccessing.UserInput(input.Split(' '));
        }
      }

    }
  }
}
