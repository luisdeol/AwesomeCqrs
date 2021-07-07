using System;
using System.Threading.Tasks;

namespace AwesomeCqrs.Samples.Commands.Handlers
{
    public class UpdatePersonHandler : ICommandHandler<UpdatePerson, Void>
    {
        public Task<Void> Handle(UpdatePerson command)
        {
            Console.WriteLine("Person updated!");
            
            return Task.FromResult(Void.Value);
        }
    }
}