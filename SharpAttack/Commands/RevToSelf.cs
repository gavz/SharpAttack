using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Credentials;

namespace SharpAttack.Commands
{
  class RevToSelf : Command
  {
    Tokens tokens = new Tokens();
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      if (tokens.RevertToSelf())
      {
        Printing.Success("Successfully reverted to self");
      }
      else
      {
        Printing.Error("Failed to revert to self. We're stuck forever.");
      }
    }
 

    public RevToSelf()
    {
      Name = "RevToSelf";
      Helptext = "Reverts back to the original token for this process";
      Register();
    }
  }
}
