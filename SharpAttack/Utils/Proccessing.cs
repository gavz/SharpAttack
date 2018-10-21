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
    // TODO: Need to process arguments with spaces in them. May be as simple as check if first character
    // is a ", then add everything up until the last character is a ".
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

        if (arguments.Count > 0)
        {
          string parameterName = null;
          Parameter parameterValue = new Parameter();

          int argIndex = 0;
          foreach (string arg in arguments)
          {
            // As we loop through our arguments we need to work to identify
            // 1. What parameter we're dealing with
            // 2. What the value for the above parameter is

            // First we check to see if the argument has a leading dash. This is obviously a parameter name
            if (arg.StartsWith("-"))
            {
              // If parameterName is already defined, then we've hit a new parameter, so add the 
              // current param name and the defined value to the dictionary, then create a new 
              // parameter name
              if (parameterName != null)
              {
                paramDictionary.Add(parameterName, parameterValue);
                // Clear everything out
                parameterValue = new Parameter();
              }
              parameterName = arg.TrimStart('-');
            }


            // If the argument does not have a leading dash AND we don't have a parameter name 
            // defined, we can assume that this is a positional value. Here we try to find the 
            // parameter based on the position of the argument.
            else if (parameterName == null)
            {
              foreach (KeyValuePair<string, Parameter> param in value.Parameters)
              {
                if (param.Value.Position == argIndex)
                {
                  parameterName = param.Key;
                  argIndex++;
                  break;
                }
              }
            }


            // If we reach this point and don't have a parameterName defined, error out. We need 
            // a parameter name to assign a value
            if (parameterName == null)
            {
              Printing.Error($"There doesn't seem to be a parameter name for these values: {arg}");
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
          // we've reached the end of our for loop, if we have anything defined here, lets add it the dictionary.
          if (parameterName != null)
          {
            paramDictionary.Add(parameterName, parameterValue);
          } 
        }
        SharpAttack.AvailableCommands[command].Run(paramDictionary);
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
