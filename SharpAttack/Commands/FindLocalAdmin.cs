using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using SharpAttack.Utils;
using SharpSploit.Generic;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  public class FindLocalAdmin : Command
  {

    public override void Run()
    {
      List<string> targets = Proccessing.GetTargets(this.Parameters);

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

    public void Initialize()
    {
      this.Parameters.Add("ComputerName", new Parameter("List of computers to check"));
      this.Parameters.Add("IPAddress", new Parameter("IP Address to check"));
      this.Register("FindLocalAdmin");
    }
  }
}
