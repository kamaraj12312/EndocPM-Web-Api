using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EndocPM.WebAPI
{
    public class ClaimService : IClaimService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IMasterService _MasterService;

        public ClaimService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService masterService)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _MasterService = masterService;
        }






    }
}
