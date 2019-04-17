using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<ContentResult> DispatchAsync<T>(T command) where T : ICommand;
    }
}
