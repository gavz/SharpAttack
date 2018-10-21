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
        string description;
        string adminCount;
        if (user.description != null)
        {
          description = user.description;
        }
        else
        {
          description = "[NO DESCRIPTION]";
        }

        if (user.admincount != null)
        {
          adminCount = user.admincount;
        }
        else
        {
          adminCount = "[NOT SET]";
        }
        Printing.TableHeader("Property", "Value");
        Printing.TableItem("SamAccountName", user.samaccountname);
        Printing.TableItem("Description", description);
        Printing.TableItem("DistinguishedName", user.distinguishedname);
        Printing.TableItem("AdminCount", adminCount);
        Printing.TableItem("MemberOf", user.memberof);
        Printing.TableItem("Password Last Set", user.pwdlastset.ToString());
        Printing.TableItem("Last Logon", user.lastlogon.ToString());
        Printing.TableItem("Bad Password Count", user.badpwdcount);
        Printing.TableItem("Last Bad Password", user.badpasswordtime.ToString());
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
