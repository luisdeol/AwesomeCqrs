using System.Threading.Tasks;

namespace AwesomeCqrs
{
    public interface IQueryHandler<in TQuery, TResponse> where TQuery: IQuery<TResponse>
    {
         Task<TResponse> Dispatch(TQuery query);
    }
}