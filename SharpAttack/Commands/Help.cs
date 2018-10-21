using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpAttack.Utils;

namespace SharpAttack.Commands
{
  class Help : Command
  {
    public override void Run(Dictionary<String, Parameter> RunParams)
    {
      if (RunParams.TryGetValue("Command", out Parameter command))
      {
        Command cmd = null;
        try
        {
          cmd = SharpAttack.AvailableCommands[command.Value[0]];
          Printing.TableHeader(command.Value[0], cmd.Helptext, "Parameter", "Description");

          foreach (KeyValuePair<string, Parameter> parm in cmd.Parameters)
          {
            Printing.TableItem(parm.Key, parm.Value.HelpText);
          }
        }
        catch
        {
          Printing.Error($"No command found named: {command.Value[0]}");
        }
      }
      else
      {
        Printing.TableHeader("SharpAttack Commands", "Here are the commands available to you", "Command", "Description");
        foreach (KeyValuePair<string, Command> cmd in SharpAttack.AvailableCommands)
        {
          Printing.TableItem(cmd.Key, cmd.Value.Helptext);
        }
      }
    }

    public Help()
    {
      Name = "Help";
      Helptext = "Displays Help";
      Parameters.Add("Command", new Parameter("Command to get information about", 0));
      Register();
    }
  }
}
