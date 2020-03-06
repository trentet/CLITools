using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLITools.Models
{
    public class CLIProgram
    {

        private string fileNameWithExtension;
        private string shortFileName;
        private string fullFileName;

        public string FileNameWithExtension
        {
            get => fileNameWithExtension;
            set
            {
                fileNameWithExtension = value;
                FileNameWithExtension_OnPropertyChanged();
            }
        }

        private void FileNameWithExtension_OnPropertyChanged()
        {
            this.ShortFileName = Path.GetFileNameWithoutExtension(this.fileNameWithExtension);
        }

        public string ShortFileName
        {
            get => shortFileName;
            set
            {
                shortFileName = value;
                ShortFileName_OnPropertyChanged();
            }
        }

        private void ShortFileName_OnPropertyChanged()
        {
            if (
                !Path.GetFileNameWithoutExtension(this.FullFileName)
                    .Equals(this.shortFileName, StringComparison.OrdinalIgnoreCase)
              )
            {
                this.fullFileName = null;
            }

            if (
                !Path.GetFileNameWithoutExtension(this.fileNameWithExtension)
                    .Equals(this.shortFileName, StringComparison.OrdinalIgnoreCase)
              )
            {
                this.fileNameWithExtension = null;
            }
        }

        public string FullFileName
        {
            get => fullFileName;
            set
            {
                fullFileName = Path.GetFullPath(value);
                FullFileName_OnPropertyChanged();
            }
        }

        private void FullFileName_OnPropertyChanged()
        {
            this.FileNameWithExtension = Path.GetFileName(this.fullFileName);
        }

        public string FriendlyName { get; set; }
        public List<CLICommand> Commands { get; set; }

        public CLIProgram()
        {

        }

        public CLIProgram(string fullProgramPath)
        {
            this.FullFileName = fullProgramPath;
        }

        public CLIProgram(string fullProgramPath, string friendlyName)
        {
            this.FullFileName = fullProgramPath;
            this.FriendlyName = friendlyName;
        }

        public CLIProgram(string fullProgramPath, string friendlyName, CLICommand command)
        {
            this.FullFileName = fullProgramPath;
            this.FriendlyName = friendlyName;
            this.Commands = new List<CLICommand>() { command };
        }

        public CLIProgram(string fullProgramPath, string friendlyName, List<CLICommand> commands)
        {
            this.FullFileName = fullProgramPath;
            this.FriendlyName = friendlyName;
            this.Commands = commands;
        }
    }
}
