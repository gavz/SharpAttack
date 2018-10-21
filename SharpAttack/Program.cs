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
      // Register Commands.

      new Help();

      new DcomExec();
      new DumpProcess();
      new FindLocalAdmin();
      new GetDomainComputer();
      new GetDomainGroup();
      new GetDomainUser();
      new GetLoggedOnUsers();
      new GetSystem();
      new ImpersonateProcess();
      new Kerberoast();
      new PowerShell();
      new RevToSelf();
      new WhoAmI();
      new WmiExec();

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
