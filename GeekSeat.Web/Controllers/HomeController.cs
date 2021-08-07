using GeekSeat.Common.ViewModels;
using GeekSeat.Web.CQRS.Commands;
using GeekSeat.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeekSeat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateAverageDeaths([FromBody] CalculateAverageDeathsCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(BaseResponse.Factory.BuildSuccessResponse(result.ToString("N2")));
            }
            catch (Exception)
            {
                return Ok(BaseResponse.Factory.BuildFailedResponse("Oops! Something went wrong!"));
            }
        }
    }
}
