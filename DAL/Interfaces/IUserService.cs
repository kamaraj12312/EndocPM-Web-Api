using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public interface IUserService
    {   
        List<UserData> GetUserRecords();
        List<Tenants> GetTenantValues();
        UserDataModel GetUserdetailswithTenants(int UserId);
        Task<BaseModel> Authenticate(LoginModel loginModel);
        UserDataModel AddUpdateUserRecord(UserDataModel userRecord);
        string SetupTenantsforUser(int UserId, string TenantIDs);
        string VerifyOTP(string userMail, int OTPnumber);
        Task<UserData> GetCurrentUserDetails(LoginModel model);
        UserData GetCurrentUserRecord();

    }

}
