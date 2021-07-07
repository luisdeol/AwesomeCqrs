namespace AwesomeCqrs.Samples.Commands
{
    public class UpdatePerson : ICommand<Void>
    {
        public string PhoneNumber { get; set; }
    }
}