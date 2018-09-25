using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using SharpAttack.Utils;
using SharpAttack.Commands;

namespace SharpAttack.Utils
{
  class Proccessing
  {
    public static void UserInput(string[] input)
    {
      string command = input[0];
      if (!SharpAttack.AvailableCommands.TryGetValue(command, out Command value))
      {
        Printing.Error($"Could not find command: {command}");
      }
      else
      {

        List<string> arguments;
        Dictionary<string, Parameter> paramDictionary = new Dictionary<string, Parameter>();

        try
        {
          arguments = input.ToList().GetRange(1, input.Length - 1);
        }
        catch
        {
          arguments = null;
        }

        if (arguments != null)
        {
          string parameterName = null;
          Parameter parameterValue = new Parameter();

          foreach (string arg in arguments)
          {
            if (arg.StartsWith("-"))
            {
              if (parameterName != null)
              {
                // We've hit a new parameter, so add the current param name and value to the dictionary
                paramDictionary.Add(parameterName, parameterValue);

                // Clear everything out
                parameterValue = new Parameter();
              }
              parameterName = arg.TrimStart('-');              
            }
            else
            {
              if (parameterName == null)
              {
                Printing.Error($"This value doesn't seem to parameter name for these values: {arg}");
                break;
              }
              else
              {
                if (arg.IndexOf(',') > -1)
                {
                  parameterValue.Value.AddRange(arg.Split(','));
                }
                else
                {
                  parameterValue.Value.Add(arg);
                }
              }
            }
          }
          // add parameter name and value to dict
          paramDictionary.Add(parameterName, parameterValue);        
        }
        SharpAttack.AvailableCommands[command].Parameters = paramDictionary;
        SharpAttack.AvailableCommands[command].Run();

        //try
        //{
        //  SharpAttack.AvailableCommands[command].Parameters = paramDictionary;
        //  SharpAttack.AvailableCommands[command].Run();
        //}
        //catch
        //{
        //  string errorText = $"Could not run {command}.";
        //  if (paramDictionary.Count > 0)
        //  {
        //    errorText += " Tried with the following params:\n";
        //    foreach (KeyValuePair<string, Parameter> kvp in paramDictionary)
        //    {
        //      errorText += $"{kvp.Key}: {kvp.Value.Value}\n";
        //    }
        //  }
        //  else
        //  {
        //    errorText += " (no parameters provided)";
        //  }
        //  Printing.Error(errorText);
        //}
      }
    }

    public static List<string> GetTargets(Dictionary<string, Parameter> parameters)
    {
      List<string> targets = new List<string>();
      if (parameters.TryGetValue("ComputerName", out Parameter computernames))
      {
        foreach (string computer in computernames.Value)
        {
          try
          {
            Printing.Informational($"Trying to resolve name: {computer}");
            Dns.GetHostEntry(computer);
            targets.Add(computer);
          }
          catch
          {
            Printing.Error($"Could not resolve name: {computer}");
          }
        }
      }
      if (parameters.TryGetValue("IPAddress", out Parameter ipaddresses))
      {
        targets.AddRange(ipaddresses.Value);
      }

      if (targets.Count == 0)
      {
        Printing.Error("You need to use either the ComputerName or IPAddress parameter with this command");
      }
      return targets;
    }
  } 
}
