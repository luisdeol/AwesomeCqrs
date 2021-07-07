using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeCqrs
{
    public class AwesomeMediator : IMediator
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public AwesomeMediator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command) where TCommand: class, ICommand<TResponse>
        {
            var scope = _serviceScopeFactory.CreateScope();
            var handler = scope.ServiceProvider.GetService<ICommandHandler<TCommand, TResponse>>();

            return await handler.Handle(command);
        }

        public Task<TResponse> Dispatch<TResponse>(IQuery<TResponse> query)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));

            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            return await (Task<TResponse>) handlerType
                .GetMethod(nameof(ICommandHandler<ICommand<TResponse>, TResponse>.Handle))?
                .Invoke(handler, new object[] { command });
        }
    }
}