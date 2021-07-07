using System.Threading.Tasks;

namespace AwesomeCqrs
{
    public interface ICommandHandler<TCommand, TResponse> where TCommand: ICommand<TResponse> 
    {
         Task<TResponse> Handle(TCommand command);
    }
}