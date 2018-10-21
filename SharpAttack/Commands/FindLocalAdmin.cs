using System;
using System.Collections.Generic;
using System.ServiceProcess;

using SharpAttack.Utils;
using SharpSploit.Generic;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  public class FindLocalAdmin : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      List<string> targets = Proccessing.GetTargets(RunParams);

      if (targets.Count > 0)
      {

        SharpSploitResultList<Network.PortScanResult> scan = Network.PortScan(targets, 445, true);
        foreach (Network.PortScanResult scanResult in scan)
        {
          if (scanResult.IsOpen)
          {
            ServiceController serviceController = new ServiceController("Spooler", scanResult.ComputerName); try
            {
              serviceController.ServiceHandle.Close();
              Printing.Success($"Admin access to {scanResult.ComputerName}");
            }
            catch
            {
              Printing.Error($"No access to {scanResult.ComputerName}");
            }
          }
          else
          {
            Printing.Error($"Port {scanResult.Port} is not open on {scanResult.ComputerName}");
          }
        }
      }
      else
      {
        Printing.Error("Need to specify a ComputerName or IPAddress");
      }
    }

    public FindLocalAdmin()
    {
      Name = "FindLocalAdmin";
      Helptext = "Checks a list of computers to see if the current account has administrative access to the endpoint";
      Parameters.Add("ComputerName", new Parameter("Computer names to check. Accepts a comma seperated list.", 0));
      Parameters.Add("IPAddress", new Parameter("IP Address to check. Accepts a comma seperated list."));
      Register();
    }
  }
}
