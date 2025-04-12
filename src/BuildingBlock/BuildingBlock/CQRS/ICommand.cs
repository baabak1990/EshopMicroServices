using MediatR;

namespace BuildingBlock.CQRS;

//We can use both Generic or nonGeneric Version To handle All of our Commands in Whole Project
//Generic version can return some result and NonGeneric version can be void 
public interface ICommand : IRequest<Unit>
{

}
public interface ICommand<out TResponse>:IRequest<TResponse>
{
    
}