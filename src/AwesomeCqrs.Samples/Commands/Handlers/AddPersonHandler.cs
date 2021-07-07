using System;
using System.Threading.Tasks;
using AwesomeCqrs;

namespace AwesomeCqrs.Samples.Commands.Handlers
{
    public class AddPersonHandler : ICommandHandler<AddPerson, Guid>
    {
        public Task<Guid> Handle(AddPerson command)
        {
            Console.WriteLine("Person added.");

            return Task.FromResult(Guid.NewGuid());
        }
    }
}