using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  class GetDomainUser : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {

      Domain.DomainSearcher domainSearcher = new Domain.DomainSearcher();
      List<string> usernames = null;

      if (RunParams.TryGetValue("UserName", out Parameter username))
      {
        usernames = username.Value;
      }

      List<Domain.DomainObject> domainUsers = domainSearcher.GetDomainUsers(usernames);
      foreach (Domain.DomainObject user in domainUsers)
      {
        Printing.CmdOutput(user.ToString());
      }
    }

    public GetDomainUser()
    {
      Name = "GetDomainUser";
      Helptext = "Returns information about a domain user.";
      Parameters.Add("UserName", new Parameter("The username to lookup. Accepts a comma seperated list. If not specified, returns all users in the domain.", 0));
      Register();
    }
  }
}
