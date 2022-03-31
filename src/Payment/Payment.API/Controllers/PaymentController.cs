using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.API.Entities;
using RolesEngine.Entities;
using RolesEngine.Repositories.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IRolesEngineRepository _rolesEngineRepository;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger, IRolesEngineRepository rolesEngineRepository)
        {
            _rolesEngineRepository = rolesEngineRepository ?? throw new ArgumentNullException(nameof(rolesEngineRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //[HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        //[Authorize]
        //public async Task<ActionResult<Order>> GetOrders()
        //{
        //    var Principal = await _rolesEngineRepository.GetRole(id);
        //    return Ok(new Order() { Id=Principal.Id});
        //}
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Principal), (int)HttpStatusCode.OK)]
        [Authorize]
        public async Task<ActionResult<Principal>> GetPrincipal(string id)
        {
            var Principal = await _rolesEngineRepository.GetRole(id);
            return Ok(Principal);
        }
    }
}
