using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _iUserService;

        public UserController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpGet]
        public List<UserData> GetUserRecords()
        {
            return this._iUserService.GetUserRecords();
        }

        [HttpGet]
        public List<Tenants> GetTenantValues()
        {
            return this._iUserService.GetTenantValues();
        }

        [HttpGet]
        public UserDataModel GetUserdetailswithTenants(int UserId)
        {
            return this._iUserService.GetUserdetailswithTenants(UserId);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseModel> UserAuthenticate(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return await _iUserService.Authenticate(loginModel);
            }

            else
            {
                return new BaseModel();
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public UserDataModel AddUpdateUser(UserDataModel userRecord)
        {
            return this._iUserService.AddUpdateUserRecord(userRecord);
        }

        [HttpGet]
        public string SetupTenantsforUser(int UserId, string TenantIDs)
        {
            return this._iUserService.SetupTenantsforUser(UserId, TenantIDs);
        }

        [HttpGet]
        [AllowAnonymous]
        public List<string> VerifyOTP(string userMail, int OTPnumber)
        {
            List<string> responses = new List<string>();
            string response = this._iUserService.VerifyOTP(userMail, OTPnumber);

            responses.Add(response);
            return responses;
        }

        [HttpPost]
        public Task<UserData> GetCurrentUserDetails(LoginModel model)
        {
            return this._iUserService.GetCurrentUserDetails(model);
        }

        [HttpGet]
        public UserData GetCurrentUserRecord()
        {
            return this._iUserService.GetCurrentUserRecord();
        }


    }
}
