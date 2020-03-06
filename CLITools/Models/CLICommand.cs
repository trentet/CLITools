using System.Collections.Generic;
using System.Linq;

namespace CLITools.Models
{
    public class CLICommand
    {
        public CLIProgram ParentProgram { get; set; }
        public string Name { get; set; }
        public List<string> Arguments { get; }
        public List<CommandSwitch> Switches { get; }
        
        public CLICommand()
        {
            this.ParentProgram = null;
            this.Name = "";
            this.Arguments = new List<string>();
            this.Switches = new List<CommandSwitch>();
        }

        public CLICommand(CLIProgram parentProgram)
        {
            this.ParentProgram = parentProgram;
            this.Name = "";
            this.Arguments = new List<string>();
            this.Switches = new List<CommandSwitch>();
        }

        public CLICommand(CLIProgram parentProgram, string name)
        {
            this.ParentProgram = parentProgram;
            this.Name = name;
            this.Arguments = new List<string>();
            this.Switches = new List<CommandSwitch>();
        }

        public CLICommand(
            CLIProgram parentProgram,
            string name,
            IEnumerable<CommandSwitch> options)
        {
            this.ParentProgram = parentProgram;
            this.Name = name;
            this.Arguments = new List<string>();
            this.Switches = options.ToList();
        }

        public CLICommand(
            CLIProgram parentProgram,
            string name,
            params string[] arguments)
        {
            this.ParentProgram = parentProgram;
            this.Name = name;
            this.Arguments = arguments.ToList();
            this.Switches = new List<CommandSwitch>();
        }

        public CLICommand(
            CLIProgram parentProgram,
            string name,
            IEnumerable<CommandSwitch> options,
            params string[] arguments)
        {
            this.ParentProgram = parentProgram;
            this.Name = name;
            this.Arguments = arguments.ToList();
            this.Switches = options.ToList();
        }

        public CLICommand(
            CLIProgram parentProgram, 
            IEnumerable<CommandSwitch> options)
        {
            this.ParentProgram = parentProgram;
            this.Name = "";
            this.Arguments = new List<string>();
            this.Switches = options.ToList();
        }

        public CLICommand(
            CLIProgram parentProgram, 
            params string[] arguments)
        {
            this.ParentProgram = parentProgram;
            this.Name = "";
            this.Arguments = arguments.ToList();
            this.Switches = new List<CommandSwitch>();
        }

        public CLICommand(
            CLIProgram parentProgram, 
            IEnumerable<CommandSwitch> options, 
            params string[] arguments)
        {
            this.ParentProgram = parentProgram;
            this.Name = "";
            this.Arguments = arguments.ToList();
            this.Switches = options.ToList();
        }

        public override string ToString()
        {
            string commandText = "";// ParentProgram;

            if (Switches != null)
            {
                foreach (CommandSwitch commandSwitch in Switches)
                {
                    if (commandSwitch.Prefix.Length > 0)
                    {
                        commandText += " " + commandSwitch.Prefix;
                    }

                    if (commandSwitch.Prefix.Length > 0)
                    {
                        commandText += " " + commandSwitch.Name;
                    }

                    foreach (string arg in commandSwitch.Arguments)
                    {
                        commandText += " " + arg;
                    }
                }
            }

            return commandText.Trim();
        }
    }
}
