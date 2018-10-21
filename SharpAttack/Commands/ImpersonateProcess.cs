using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Credentials;
namespace SharpAttack.Commands
{
  class ImpersonateProcess : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      if (RunParams.TryGetValue("PID", out Parameter pid))
      {
        UInt32 id = Convert.ToUInt32(pid.Value[0]);
        Tokens tokens = new Tokens();
        if (tokens.ImpersonateProcess(id))
        {
          Printing.Success("Successfully impersonated process.");
        }
        else
        {
          Printing.Error("Failed to impersonate process");
        }
      }
      else
      {
        Printing.Error("No PID specified");
      }
    }

    public ImpersonateProcess()
    {
      Name = "ImpersonateProcess";
      Helptext = "Impresonates the user that owns a given process";
      Parameters.Add("PID", new Parameter("Process ID to take the token from. Required", 0));
      Register();
    }
  }
}
