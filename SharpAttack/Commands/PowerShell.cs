using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Execution;
namespace SharpAttack.Commands
{
  class PowerShell : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      if (RunParams.TryGetValue("Command", out Parameter command))
      {
        foreach (string cmd in command.Value)
        {
          Printing.CmdOutput(Shell.PowerShellExecute(cmd));
        }
      }
      else
      {
        Printing.Error("No command specified");
      }
    }

    public PowerShell()
    {
      Name = "PowerShell";
      Helptext = "Executes a PowerShell command without powershell.exe and attempts to evade logging.";
      Parameters.Add("Command", new Parameter("PowerShell command to run. Accepts a comma seperated list. Required.", 0));
      Register();
    }
  }
}
