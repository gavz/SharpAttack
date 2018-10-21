using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpAttack;

namespace SharpAttack.Commands
{
  public class Parameter
  {
    public string HelpText;
    public int Position;
    public List<string> Value = new List<string>();

    public Parameter() { }

    public Parameter(string HelpText, int Position = -1)
    {
      this.Position = Position;
      this.HelpText = HelpText;
    }
  }

  public abstract class Command
  {
    public string Name { get; set; }
    public string Author { get; set; }
    public string Url { get; set; }
    public string Helptext { get; set; }
    public Dictionary<String, Parameter> Parameters { get; set; }
    public abstract void Run(Dictionary<String, Parameter> RunParameters);

    public Command()
    {
      this.Parameters = new Dictionary<string, Parameter>(StringComparer.OrdinalIgnoreCase);
    }

    public void Register()
    {
      SharpAttack.AvailableCommands.Add(this.Name, this);
    }
  }
}
