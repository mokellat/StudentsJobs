using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsJobs.Controllers.Utility
{
    /// <summary>
    /// Signature du constructeur
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Médiateur
        /// </summary>
        private IMediator _mediator;

        /// <summary>
        /// Récupération du médiateur
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
