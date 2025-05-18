using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }
    }
}
