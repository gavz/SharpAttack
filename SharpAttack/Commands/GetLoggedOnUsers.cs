using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  class GetLoggedOnUsers : Command
  {
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      List<string> targets = Proccessing.GetTargets(RunParams);
      if (targets.Count > 0)
      {
        foreach (string computer in targets)
        {
          try
          {
            List<string> printedUsers = new List<string>();
            List<Net.LoggedOnUser> users = Net.GetNetLoggedOnUsers(computer);
            Printing.CmdOutputHeading($"Logged on users for {computer}");
            foreach (Net.LoggedOnUser user in users)
            {
              if (!user.UserName.EndsWith("$") && !printedUsers.Contains(user.UserName))
              {
                Printing.CmdOutputItem($"User {user.UserName} is logged in from {user.ComputerName}");
                printedUsers.Add(user.UserName);
              }
            }
          }
          catch
          {
            Printing.Error($"Could not get logged on users for {computer}");
          }
        }
      }
    }
    public GetLoggedOnUsers()
    {
      Name = "GetLoggedOnUsers";
      Helptext = "Returns a list of users logged into a machine";
      Parameters.Add("ComputerName", new Parameter("List of computers to get logged on users for. Accepts a comma seperated list. Required.", 0));
      Register();
    }
  }
}
