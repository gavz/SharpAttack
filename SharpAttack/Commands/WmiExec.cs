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
    public override void Run()
    {
      if (this.Parameters.TryGetValue("ComputerName", out Parameter computer))
      {
        if (this.Parameters.TryGetValue("Command", out Parameter command))
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

    public void Initialize()
    {
      this.Parameters.Add("ComputerName", new Parameter("Name of the Computer to execute the command on"));
      this.Parameters.Add("Command", new Parameter("Command to Run"));
      this.Register("WmiExec");
    }
  }
}
