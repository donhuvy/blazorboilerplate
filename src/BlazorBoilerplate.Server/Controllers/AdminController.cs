﻿
using BlazorBoilerplate.Server.Managers;
using BlazorBoilerplate.Shared.Dto.Admin;
using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.AuthorizationDefinitions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Controllers
{
    /// <summary>
    /// This controller is the entry API for the platform administration.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminManager _adminManager;

        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        [HttpGet("Users")]
        [Authorize]
        public async Task<ApiResponse> GetUsers([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 0)
            => await _adminManager.GetUsers(pageSize, pageNumber);

        [HttpGet("Permissions")]
        [Authorize]
        public ApiResponse GetPermissions()
            => _adminManager.GetPermissions();

        #region Roles
        [HttpGet("Roles")]
        [Authorize(Permissions.Role.Read)]
        public async Task<ApiResponse> GetRoles([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 0)
            => await _adminManager.GetRolesAsync(pageSize, pageNumber);

        [HttpGet("Role/{name}")]
        [Authorize]
        public async Task<ApiResponse> GetRoleAsync(string name)
            => await _adminManager.GetRoleAsync(name);

        
        [HttpPost("Role")]
        [Authorize(Permissions.Role.Create)]
        public async Task<ApiResponse> CreateRoleAsync([FromBody] RoleDto roleDto)
            => await _adminManager.CreateRoleAsync(roleDto);

        
        [HttpPut("Role")]
        [Authorize(Permissions.Role.Update)]
        public async Task<ApiResponse> UpdateRoleAsync([FromBody] RoleDto roleDto)
            => await _adminManager.UpdateRoleAsync(roleDto);

        
        [HttpDelete("Role/{name}")]
        [Authorize(Permissions.Role.Delete)]
        public async Task<ApiResponse> DeleteRoleAsync(string name)
            => await _adminManager.DeleteRoleAsync(name);
        #endregion

        #region Clients
        [HttpGet("Clients")]
        [Authorize(Permissions.Client.Read)]
        public async Task<ApiResponse> GetClients([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 0)
            => await _adminManager.GetClientsAsync(pageSize, pageNumber);

        [HttpGet("Client/{clientId}")]
        [Authorize]
        public async Task<ApiResponse> GetClientAsync(string clientId)
            => await _adminManager.GetClientAsync(clientId);

        
        [HttpPost("Client")]
        [Authorize(Permissions.Client.Create)]
        public async Task<ApiResponse> CreateClientAsync([FromBody] ClientDto clientDto)
            => await _adminManager.CreateClientAsync(clientDto);

        
        [HttpPut("Client")]
        [Authorize(Permissions.Client.Update)]
        public async Task<ApiResponse> UpdateClientAsync([FromBody] ClientDto clientDto)
            => await _adminManager.UpdateClientAsync(clientDto);

        
        [HttpDelete("Client/{clientId}")]
        [Authorize(Permissions.Client.Delete)]
        public async Task<ApiResponse> DeleteClientAsync(string clientId)
            => await _adminManager.DeleteClientAsync(clientId);
        #endregion

        #region ApiResources
        [HttpGet("ApiResources")]
        [Authorize(Permissions.ApiResource.Read)]
        public async Task<ApiResponse> GetApiResources([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 0)
            => await _adminManager.GetApiResourcesAsync(pageSize, pageNumber);

        [HttpGet("ApiResource/{name}")]
        [Authorize]
        public async Task<ApiResponse> GetApiResourceAsync(string name)
            => await _adminManager.GetApiResourceAsync(name);

        
        [HttpPost("ApiResource")]
        [Authorize(Permissions.ApiResource.Create)]
        public async Task<ApiResponse> CreateApiResourceAsync([FromBody] ApiResourceDto apiResourceDto)
            => await _adminManager.CreateApiResourceAsync(apiResourceDto);

        
        [HttpPut("ApiResource")]
        [Authorize(Permissions.ApiResource.Update)]
        public async Task<ApiResponse> UpdateApiResourceAsync([FromBody] ApiResourceDto apiResourceDto)
            => await _adminManager.UpdateApiResourceAsync(apiResourceDto);

        
        [HttpDelete("ApiResource/{name}")]
        [Authorize(Permissions.ApiResource.Delete)]
        public async Task<ApiResponse> DeleteApiResourceAsync(string name)
            => await _adminManager.DeleteApiResourceAsync(name);
        #endregion

        #region IdentityResources
        [HttpGet("IdentityResources")]
        [Authorize(Permissions.IdentityResource.Read)]
        public async Task<ApiResponse> GetIdentityResources([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 0)
            => await _adminManager.GetIdentityResourcesAsync(pageSize, pageNumber);

        [HttpGet("IdentityResource/{name}")]
        [Authorize]
        public async Task<ApiResponse> GetIdentityResourceAsync(string name)
            => await _adminManager.GetIdentityResourceAsync(name);

        
        [HttpPost("IdentityResource")]
        [Authorize(Permissions.IdentityResource.Create)]
        public async Task<ApiResponse> CreateIdentityResourceAsync([FromBody] IdentityResourceDto identityResourceDto)
            => await _adminManager.CreateIdentityResourceAsync(identityResourceDto);

        
        [HttpPut("IdentityResource")]
        [Authorize(Permissions.IdentityResource.Update)]
        public async Task<ApiResponse> UpdateIdentityResourceAsync([FromBody] IdentityResourceDto identityResourceDto)
            => await _adminManager.UpdateIdentityResourceAsync(identityResourceDto);

        
        [HttpDelete("IdentityResource/{name}")]
        [Authorize(Permissions.IdentityResource.Delete)]
        public async Task<ApiResponse> DeleteIdentityResourceAsync(string name)
            => await _adminManager.DeleteIdentityResourceAsync(name);
        #endregion
    }
}
