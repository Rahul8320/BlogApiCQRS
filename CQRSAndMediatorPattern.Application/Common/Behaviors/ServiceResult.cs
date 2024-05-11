using System.Net;

namespace CQRSAndMediatorPattern.Application.Common.Behaviors;

public class ServiceResult
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string Message { get; set; } = string.Empty;
}

public class ServiceResult<T> : ServiceResult
{
    public T Data { get; set; } = default!;
}
