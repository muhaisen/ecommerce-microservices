using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RolesEngine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RbacController : ControllerBase
    {
        private readonly IRbacRepository _rbac_repository;
        private readonly IRolesEngineRepository _rolesEngineRepository;
        private readonly ILogger<CatalogController> _logger;

        public RbacController(ILogger<CatalogController> logger, IRbacRepository rbac_repository, IRolesEngineRepository rolesEngineRepository)
        {
            _rbac_repository = rbac_repository ?? throw new ArgumentNullException(nameof(rbac_repository));
            _rolesEngineRepository = rolesEngineRepository ?? throw new ArgumentNullException(nameof(rolesEngineRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Principal), (int)HttpStatusCode.OK)]
        [Authorize]
        public async Task<ActionResult<Principal>> GetPrincipal(string id)
        {
            var Principal = await _rbac_repository.GetRole(id);
            return Ok(Principal);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Principal), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Principal>> CreatePrincipal([FromBody] Principal principal)
        {
           return Ok(await _rolesEngineRepository.UpdateRole(principal.Id, principal.Permissions));
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(Principal), (int)HttpStatusCode.Created)]
        //public async Task<ActionResult<Principal>> CreatePrincipal()
        //{
        //    var permissionsList = new List<string> { "Reader", "Writer" };
        //    var userId = Guid.NewGuid().ToString("N");
        //    return Ok(await _rolesEngineRepository.UpdateRole(userId, permissionsList));
        //}

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _rbac_repository.DeleteRole(id));
        }
    }
}