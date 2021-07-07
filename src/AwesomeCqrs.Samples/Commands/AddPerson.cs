using System;
using AwesomeCqrs;

namespace AwesomeCqrs.Samples.Commands
{
    public class AddPerson : ICommand<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}