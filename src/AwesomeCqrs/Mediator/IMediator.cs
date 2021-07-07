using System.Threading.Tasks;

namespace AwesomeCqrs
{
    public interface IMediator
    {
        Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command) where TCommand: class, ICommand<TResponse>;
        Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command);
        Task<TResponse> Dispatch<TResponse>(IQuery<TResponse> query);
    }
}