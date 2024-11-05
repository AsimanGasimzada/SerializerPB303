using Serializer.Exceptions.Common;

namespace Serializer.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not found") : base(message)
    {

    }
    public int StatusCode { get; set; } = 404;
}
