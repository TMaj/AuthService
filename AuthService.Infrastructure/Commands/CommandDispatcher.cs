using AuthService.Infrastructure.Commands.Interfaces;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IComponentContext context;

        public CommandDispatcher(IComponentContext context)
        {
            this.context = context;
        }

        public async Task<ContentResult> DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' can not be null.");
            }

            try
            {
                var handler = this.context.Resolve<ICommandHandler<T>>();
                return await handler.HandleAsync(command);
            }
            catch (Exception ex)
            {
                var x = ex;
                throw ex;
            } 

            
        }
    }
}
