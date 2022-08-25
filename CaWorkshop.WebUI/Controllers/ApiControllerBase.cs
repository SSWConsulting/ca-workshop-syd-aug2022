using CaWorkshop.WebUI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaWorkshop.WebUI.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private IMediator _mediator = null!;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
