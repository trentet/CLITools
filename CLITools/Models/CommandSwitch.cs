using System.Linq;
using System.Collections.Generic;

namespace CLITools.Models
{
    static class CommandSwitchList_Extensions
    {
        public static string ToString(this IEnumerable<CommandSwitch> commandOptions)
        {
            string toString = "";

            foreach (CommandSwitch commandOption in commandOptions)
            {
                toString += commandOption.ToString() + " ";
            }

            return toString.Trim();
        }
    }

    public class CommandSwitch
    {
        private string prefix;
        private string name;
        private List<string> arguments = null;

        public string Prefix { get => prefix; set => prefix = value; }
        public string Name { get => name; set => name = value; }
        public List<string>? Arguments { get => arguments; set => arguments = value; }
        public string? ArgumentsDelimiter { get; set; } = null;

        public CommandSwitch(string name, string argumentsDelimiter, params string[] arguments)
        {
            this.Prefix = null;
            this.Name = name;
            this.Arguments = arguments.ToList();
            this.ArgumentsDelimiter = argumentsDelimiter;
        }

        public CommandSwitch(string prefix, string name, string argumentsDelimiter, params string[] arguments)
        {
            this.Prefix = prefix;
            this.Name = name;
            this.Arguments = arguments.ToList();
            this.ArgumentsDelimiter = argumentsDelimiter;
        }

        public CommandSwitch(string prefix, string name)
        {
            this.Prefix = prefix;
            this.Name = name;
            this.Arguments = null;
            this.ArgumentsDelimiter = null;
        }

        public CommandSwitch(string argumentsDelimiter, params string[] arguments)
        {
            this.Prefix = null;
            this.Name = null;
            this.Arguments = arguments.ToList();
            this.ArgumentsDelimiter = argumentsDelimiter;
        }

        public CommandSwitch(string argument)
        {
            this.Prefix = null;
            this.Name = null;
            this.Arguments = new List<string> { argument };
            this.ArgumentsDelimiter = null;
        }

        public override string ToString()
        {
            string commandSwitchToString = "";
            if (Prefix != null) {
                commandSwitchToString += Prefix;
            }

            if (Name != null)
            {
                commandSwitchToString += Name;
            }

            if (Arguments != null)
            {
                if (Arguments.Count > 1)
                {
                    commandSwitchToString += string.Join(this.ArgumentsDelimiter, this.Arguments);
                }
                else if (Arguments.Count == 1)
                {
                    commandSwitchToString += this.Arguments[0];
                }
            }

            return commandSwitchToString;
        }
    }
}
