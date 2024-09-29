using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        public readonly IClaimService _iclaimService;

        public ClaimController (IClaimService iclaimService)
        {
            _iclaimService = iclaimService;
        }




    }
}
