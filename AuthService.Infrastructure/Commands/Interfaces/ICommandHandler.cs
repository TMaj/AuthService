using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Commands.Interfaces
{
    public interface ICommandHandler<TC> where TC : ICommand
    {
        Task<ContentResult> HandleAsync(TC command);
    }
}
