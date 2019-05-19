using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FlightsReservationApp.API.DTO_s;
using FlightsReservationApp.API.Filters;
using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlightsReservationApp.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _repo;

        public ApplicationUserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IUsersRepository repo)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _configuration = configuration;
            _repo = repo;
        }

        [HttpPost]
        [ApiValidationFilter]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<IActionResult> Register([FromBody] User_DTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return Created("User created", result);

                if (_userManager.FindByEmailAsync(model.Email) != null)
                    return BadRequest("User already exists!");

                return BadRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}