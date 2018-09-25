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
    public override void Run()
    {
      List<string> targets = Proccessing.GetTargets(this.Parameters);
      List<Domain.DomainObject> computers = new List<Domain.DomainObject>();
      if (targets.Count > 0)
      {
        //try
        //{
          //Domain.DomainSearcher searcher = new Domain.DomainSearcher();
          //Printing.Informational("Getting computer objects from AD");
          //computers = searcher.GetDomainComputers(targets);
        //}
        //catch
        //{
        //  Printing.Error("There was an issue getting the comptuers from AD");
        //}

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
    public void Initialize()
    {
      this.Parameters.Add("ComputerName", new Parameter("List of computers to check"));
      this.Register("GetLoggedOnUsers");
    }
  }
}
