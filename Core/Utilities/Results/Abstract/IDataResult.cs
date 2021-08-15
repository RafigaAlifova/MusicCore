
namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
      T Data { get; }
    }
}
