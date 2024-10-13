using AutoMapper;
using RFAuth.Entities;
using RFAuth.DTO;
using RFAuth.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RFService.DataLib;
using RFService.RepoLib;

namespace RFAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            logger.LogInformation("Recuperando ususarios");


            var list = await userService.GetListAsync(new GetOptions { Include = { { "Type", new GetOptions() } }});
            var res = list.Select(mapper.Map<User, UserResponse>);

            //var res = (await userService.GetListAsync()).Select(mapper.Map<User,UserResponse>);
            return Ok(new DataRowsResult(res));
        }
    }
}
