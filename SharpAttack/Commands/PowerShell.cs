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

    public override void Run()
    {
      if (this.Parameters.TryGetValue("Command", out Parameter command))
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

    public void Initialize()
    {
      this.Parameters.Add("Command", new Parameter("Command to Run"));
      this.Register("PowerShell");
    }
  }
}
