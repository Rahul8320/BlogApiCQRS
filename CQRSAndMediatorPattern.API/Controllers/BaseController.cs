using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatorPattern.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{

}
