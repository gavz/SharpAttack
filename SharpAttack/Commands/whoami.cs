using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Credentials;
namespace SharpAttack.Commands
{
  class WhoAmI : Command
  {
    Tokens tokens = new Tokens();
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      Printing.CmdOutput(tokens.WhoAmI());
    }

    public WhoAmI()
    {
      Name = "whoami";
      Helptext = "Answers some really deep questions";
      Register();
    }
  }
}
