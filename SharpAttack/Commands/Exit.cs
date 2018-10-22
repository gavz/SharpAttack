using System;
using System.Collections.Generic;

namespace SharpAttack.Commands
{
  class Exit : Command
  {
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      Environment.Exit(0);
    }

    public Exit()
    {
      Name = "Exit";
      Helptext = "Quits SharpAttack";
      Register();
    }
  }
}
