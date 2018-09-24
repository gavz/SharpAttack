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
    public static Dictionary<string, Command> AvailableCommands = new Dictionary<string, Command>();

    

    static void Main(string[] args)
    {
      // Register Commands. Probably a better way to do this.
      new FindLocalAdmin().Initialize();
      

      // Start Processing
      if (args.Length > 0)
      {
        Proccessing.UserInput(args);
      }
      else
      {
        Printing.StartUp();
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
