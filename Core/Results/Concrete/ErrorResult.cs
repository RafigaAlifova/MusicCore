
namespace Core.Results.Concrete
{
    public class ErrorResult : Result
    {
        //success yerine pramoy false yazdiq cunki error verecekse false nese var da demek kii
        public ErrorResult( string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}
