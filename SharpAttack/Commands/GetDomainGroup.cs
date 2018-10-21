using System;
using System.Collections.Generic;

using SharpAttack.Utils;
using SharpSploit.Enumeration;

namespace SharpAttack.Commands
{
  class GetDomainGroup : Command
  {

    public override void Run(Dictionary<String, Parameter> RunParams)
    {

      Domain.DomainSearcher domainSearcher = new Domain.DomainSearcher();
      List<string> Groups = null;

      if (RunParams.TryGetValue("GroupName", out Parameter groupname))
      {
        Groups = groupname.Value;
      }

      List<Domain.DomainObject> domainGroups = domainSearcher.GetDomainGroups(Groups);
      foreach (Domain.DomainObject domainGroup in domainGroups)
      {
        Printing.CmdOutput(domainGroup.ToString());
      }
    }

    public GetDomainGroup()
    {
      Name = "GetDomainGroup";
      Helptext = "Returns information about a domain group.";
      Parameters.Add("GroupName", new Parameter("The group name to lookup. Accepts a comma seperated list. If not specified, returns all groups", 0));
      Register();
    }
  }
}
