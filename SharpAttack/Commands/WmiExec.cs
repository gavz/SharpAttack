using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;

using SharpSploit.LateralMovement;

namespace SharpAttack.Commands
{
  class WmiExec : Command
  {
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      if (RunParams.TryGetValue("ComputerName", out Parameter computer))
      {
        if (RunParams.TryGetValue("Command", out Parameter command))
        {
          foreach (string cmd in command.Value)
          {
            WMI.WMIExecute(computer.Value, cmd, null, null);
          }
        }
        else
        {
          Printing.Error("No command specified");
        }
      }
    }

    public WmiExec()
    {
      Name = "WmiExec";
      Helptext = "Executes a command against a remote machine over WMI";
      Parameters.Add("ComputerName", new Parameter("Name of the Computer to execute the command on. Accepts a comma seperated list. Required.", 0));
      Parameters.Add("Command", new Parameter("Command to Run. Required.", 1));
      Register();
    }
  }
}
