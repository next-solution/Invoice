using System.Threading.Tasks;

namespace Invoice.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}