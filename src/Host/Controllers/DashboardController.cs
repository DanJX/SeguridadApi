//using ApplicationCore.Commands.Users;
//using ApplicationCore.DTOs.User;
using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly IMediator _mediator;
        public DashboardController(IDashboardService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        // <summary>
        // Get de todos mis Usuarios
        // </summary>
        // <returns></returns>

        [Route("getData")]
        [HttpGet]

        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _service.GetData();
            return Ok(result);
        }

        /// <summary>
        /// create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]

        public async Task<ActionResult<Response<int>>> Create(CreateClienteCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
