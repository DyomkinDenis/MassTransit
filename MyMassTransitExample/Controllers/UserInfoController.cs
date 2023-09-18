using MassTransit;
using MassTransitContracts;
using Microsoft.AspNetCore.Mvc;

namespace MyMassTransitExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IRequestClient<IUserInfoRequest> _requestClient;
        private readonly IPublishEndpoint _puplish;

        public UserInfoController(IRequestClient<IUserInfoRequest> requestClient, IPublishEndpoint publish)
        {
            _requestClient = requestClient;
            _puplish = publish;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var request = new UserInfoRequest()
            {
                Id = Guid.Empty,
            };


            try
            {
                var response = await _requestClient.GetResponse<IUserInfoResponse>(request);
                return Ok(response.Message);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {

            var userInfo = new CreateUser()
            {
                Id = Guid.NewGuid(),
                Name = "Name from publisher"
            };

            await _puplish.Publish<ICreateUser>(userInfo);

            return Ok(userInfo);
        }
    }
}
