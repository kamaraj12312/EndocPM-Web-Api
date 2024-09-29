using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace EndocPM.WebAPI
{
    public class UserService : IUserService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _webhostingEnvironment;
        public readonly IMasterService _iMasterService;
        private IWebHostEnvironment _hostingEnvironment;

        //public UserManager<UserData> _userManager { get; } // UserManager is a class and it is used to manage the users 
        //public SignInManager<UserData> _signInManager { get; } // SignInManager is a class and it is used to handle the user's SignIn & SignOut
        //public RoleManager<IdentityRole> _roleManager { get; }

        public UserService(
            // UserManager<UserData> userManager, SignInManager<UserData> signInManager, RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment webHostEnvironment, IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMasterService iMasterService, IWebHostEnvironment hostingEnvironment)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _webhostingEnvironment = webHostEnvironment;
            _iMasterService = iMasterService;
            _hostingEnvironment = hostingEnvironment;
            //_userManager = userManager;
            //_signInManager = signInManager;
            //_roleManager = roleManager;
        }

        public List<UserData> GetUserRecords()
        {
            var userRecords = this._uow.GenericRepository<UserData>().Table()
                //.Where(x => x.IsActive != false)
                .ToList();

            return userRecords;
        }

        public List<Tenants> GetTenantValues()
        {
            var tenantList = this._uow.GenericRepository<Tenants>().Table().Where(x => x.Deleted != true).ToList();

            return tenantList;
        }

        public UserDataModel GetUserdetailswithTenants(int UserId)
        {
            UserDataModel userDetails = (from user in this._uow.GenericRepository<UserData>().Table().Where(x => x.UserID == UserId)
                                         join userTenant in this._uow.GenericRepository<UserTenantSetup>().Table()
                                         on user.UserID equals userTenant.UserID

                                         select new
                                         {
                                             user.UserID,
                                             user.UserName,
                                             user.Password,
                                             user.Title,
                                             user.NPIID,
                                             user.SSNID,
                                             user.NameLast,
                                             user.NameFirst,
                                             user.NameMiddle,
                                             user.DateOfBirth,
                                             user.Sex,
                                             user.Credential,
                                             user.NamePrefix,
                                             user.NameSuffix,
                                             user.AddressLine1,
                                             user.AddressLine2,
                                             user.City,
                                             user.State,
                                             user.County,
                                             user.ZIP,
                                             user.Country,
                                             user.Telephone,
                                             user.Fax,
                                             user.AlternatePhone,
                                             user.Email,
                                             user.EmailConfirmed,
                                             user.UserTypeID,
                                             user.PhoneNumber,
                                             user.PhoneNumberConfirmed,
                                             user.IsActive,
                                             user.CreatedDate,
                                             user.CreatedBy,
                                             user.ModifiedDate,
                                             user.ModifiedBy,
                                             userTenant.UserTenantID,
                                             userTenant.TenantIDs

                                         }).AsEnumerable().Select(UDM => new UserDataModel
                                         {
                                             UserID = UDM.UserID,
                                             UserName = UDM.UserName,
                                             Password = UDM.Password,
                                             Title = UDM.Title,
                                             NPIID = UDM.NPIID,
                                             SSNID = UDM.SSNID,
                                             NameLast = UDM.NameLast,
                                             NameFirst = UDM.NameFirst,
                                             NameMiddle = UDM.NameMiddle,
                                             DateOfBirth = UDM.DateOfBirth,
                                             Sex = UDM.Sex,
                                             Credential = UDM.Credential,
                                             NamePrefix = UDM.NamePrefix,
                                             NameSuffix = UDM.NameSuffix,
                                             AddressLine1 = UDM.AddressLine1,
                                             AddressLine2 = UDM.AddressLine2,
                                             City = UDM.City,
                                             State = UDM.State,
                                             County = UDM.County,
                                             ZIP = UDM.ZIP,
                                             Country = UDM.Country,
                                             Telephone = UDM.Telephone,
                                             Fax = UDM.Fax,
                                             AlternatePhone = UDM.AlternatePhone,
                                             Email = UDM.Email,
                                             EmailConfirmed = UDM.EmailConfirmed,
                                             UserTypeID = UDM.UserTypeID,
                                             PhoneNumber = UDM.PhoneNumber,
                                             PhoneNumberConfirmed = UDM.PhoneNumberConfirmed,
                                             IsActive = UDM.IsActive,
                                             CreatedDate = UDM.CreatedDate,
                                             CreatedBy = UDM.CreatedBy,
                                             ModifiedDate = UDM.ModifiedDate,
                                             ModifiedBy = UDM.ModifiedBy,
                                             //Tenantnames = this.GetTenantNames(UDM.TenantIDs),
                                             //TenantIdArray = this.GetTenantArray(UDM.TenantIDs),
                                             files = this._iMasterService.GetFile("3", "user"),
                                             fileCollect = this.GetfileCollection(this._iMasterService.GetFile("3", "user"))

                                         }).FirstOrDefault();

            return userDetails;
        }

        List<string[]> GetfileCollection(List<clsViewFile> files)
        {
            List<string[]> collection = new List<string[]>();

            foreach (clsViewFile file in files)
            {
                string[] collect = new string[2];

                collect[0] = file.ActualFile;
                collect[1] = file.FileUrl;

                collection.Add(collect);
            }

            return collection;
        }


        public string GetTenantNames(string TenantIds)
        {
            string tenantNames = "";
            string[] tenantIds = TenantIds != null ? TenantIds.Split(",") : null;

            if (tenantIds != null && tenantIds.Count() > 0)
            {
                for (int i = 0; i < tenantIds.Count(); i++)
                {
                    if (tenantIds[i] != "" && tenantIds[i] != null && tenantIds[i].Trim() != "" && Convert.ToInt32(tenantIds[i]) != 0)
                    {
                        var tenantData = this._uow.GenericRepository<Tenants>().Table().Where(x => x.TenantID == Convert.ToInt32(tenantIds[i])).FirstOrDefault();
                        if (i < tenantIds.Count() - 1)
                        {
                            tenantNames += tenantData.TenantDescription + ", ";
                        }
                        else
                        {
                            tenantNames += tenantData.TenantDescription;
                        }
                    }
                }
            }
            //this.AddTenantsforUser();
            return tenantNames;
        }

        public List<int> GetTenantArray(string TenantIds)
        {
            List<int> tenantArray = new List<int>();
            string[] tenantIds = TenantIds != null ? TenantIds.Split(",") : null;

            if (tenantIds != null && tenantIds.Count() > 0)
            {
                for (int i = 0; i < tenantIds.Count(); i++)
                {
                    if (tenantIds[i] != "" && tenantIds[i] != null && tenantIds[i].Trim() != "" && Convert.ToInt32(tenantIds[i]) != 0)
                    {
                        var tenantData = this._uow.GenericRepository<Tenants>().Table().Where(x => x.TenantID == Convert.ToInt32(tenantIds[i])).FirstOrDefault();

                        tenantArray.Add(tenantData.TenantID);
                    }
                }
            }
            //this.AddTenantsforUser();
            return tenantArray;
        }

        public async Task<BaseModel> Authenticate(LoginModel loginModel)
        {
            UserData userRecord = new UserData();
            BaseModel result = new BaseModel();
            userRecord = await GetCurrentUserDetails(loginModel);

            if (userRecord != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.UserName)
            };

                string tokenKey = _configuration["Tokens:Key"];
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                  _configuration["Tokens:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: creds);

                result.Status = 0;
                result.StatusMessage = "Successfull";
                result.Result = new { token = new JwtSecurityTokenHandler().WriteToken(token) };
            }
            else
            {
                result.Status = 2;
                result.StatusMessage = "Failed";
            }

            return result;
        }

        public Task<UserData> GetCurrentUserDetails(LoginModel model)
        {
            UserData user = new UserData();
            if (model.UserName != "" && model.Password != "")
            {
                user = this._uow.GenericRepository<UserData>().Table().SingleOrDefault(u => u.UserName.ToLower().Trim() == model.UserName.ToLower().Trim() &&
                        u.Password.ToLower().Trim() == model.Password.ToLower().Trim());
            }

            return Task.FromResult(user);
        }

        public UserData GetCurrentUserRecord()
        {
            var currentUser = this._httpContextAccessor.HttpContext.User.Identity.Name;
            var userCheck = this._uow.GenericRepository<UserData>().Table().Where(a => a.UserName.ToLower().Trim() == currentUser.ToLower().Trim()).FirstOrDefault();

            return userCheck;
        }

        public UserDataModel AddUpdateUserRecord(UserDataModel userRecord)
        {
            var userCheck = this._uow.GenericRepository<UserData>().Table().Where(a => a.UserName.ToLower().Trim() == userRecord.UserName.ToLower().Trim()
                                                                    //& a.Password.ToLower().Trim() == userRecord.Password.ToLower().Trim()
                                                                    //& a.IsActive == true
                                                                    ).FirstOrDefault();
            if (userCheck == null)
            {
                userCheck = new UserData();

                userCheck.UserName = userRecord.UserName;
                userCheck.Password = userRecord.Password;
                userCheck.Title = userRecord.Title;
                userCheck.NPIID = userRecord.NPIID;
                userCheck.SSNID = userRecord.SSNID;
                userCheck.NameLast = userRecord.NameLast;
                userCheck.NameFirst = userRecord.NameFirst;
                userCheck.NameMiddle = userRecord.NameMiddle;
                userCheck.DateOfBirth = userRecord.DateOfBirth;
                userCheck.Sex = userRecord.Sex;
                userCheck.Credential = userRecord.Credential;
                userCheck.NamePrefix = userRecord.NamePrefix;
                userCheck.NameSuffix = userRecord.NameSuffix;
                userCheck.AddressLine1 = userRecord.AddressLine1;
                userCheck.AddressLine2 = userRecord.AddressLine2;
                userCheck.City = userRecord.City;
                userCheck.State = userRecord.State;
                userCheck.County = userRecord.County;
                userCheck.ZIP = userRecord.ZIP;
                userCheck.Country = userRecord.Country;
                userCheck.Telephone = userRecord.Telephone;
                userCheck.Fax = userRecord.Fax;
                userCheck.AlternatePhone = userRecord.AlternatePhone;
                userCheck.Email = userRecord.Email;
                userCheck.EmailConfirmed = userRecord.EmailConfirmed;
                userCheck.UserTypeID = userRecord.UserTypeID;
                userCheck.PhoneNumber = userRecord.PhoneNumber;
                userCheck.PhoneNumberConfirmed = userRecord.PhoneNumberConfirmed;
                userCheck.IsActive = false;
                userCheck.CreatedDate = DateTime.Now;
                userCheck.CreatedBy = "User";

                this._uow.GenericRepository<UserData>().Insert(userCheck);
            }
            else
            {
                userCheck.Title = userRecord.Title;
                userCheck.NPIID = userRecord.NPIID;
                userCheck.SSNID = userRecord.SSNID;
                userCheck.NameLast = userRecord.NameLast;
                userCheck.NameFirst = userRecord.NameFirst;
                userCheck.NameMiddle = userRecord.NameMiddle;
                userCheck.DateOfBirth = userRecord.DateOfBirth;
                userCheck.Sex = userRecord.Sex;
                userCheck.Credential = userRecord.Credential;
                userCheck.NamePrefix = userRecord.NamePrefix;
                userCheck.NameSuffix = userRecord.NameSuffix;
                userCheck.AddressLine1 = userRecord.AddressLine1;
                userCheck.AddressLine2 = userRecord.AddressLine2;
                userCheck.City = userRecord.City;
                userCheck.State = userRecord.State;
                userCheck.County = userRecord.County;
                userCheck.ZIP = userRecord.ZIP;
                userCheck.Country = userRecord.Country;
                userCheck.Telephone = userRecord.Telephone;
                userCheck.Fax = userRecord.Fax;
                userCheck.AlternatePhone = userRecord.AlternatePhone;
                userCheck.Email = userRecord.Email;
                userCheck.EmailConfirmed = userRecord.EmailConfirmed;
                userCheck.UserTypeID = userRecord.UserTypeID;
                userCheck.PhoneNumber = userRecord.PhoneNumber;
                userCheck.PhoneNumberConfirmed = userRecord.PhoneNumberConfirmed;
                userCheck.IsActive = true;
                userCheck.ModifiedDate = DateTime.Now;
                userCheck.ModifiedBy = "User";

                this._uow.GenericRepository<UserData>().Update(userCheck);
            }

            this._uow.Save();
            userRecord.UserID = userCheck.UserID;
            //if(userCheck.Email != "" && userCheck.Email != null)
            //{
            //    //this._iMasterService.SendEmail(userCheck.Email, userCheck.NameFirst);
            //}
            var provider = this._uow.GenericRepository<Provider>().Table().Where(x => x.UserID == userCheck.UserID).FirstOrDefault();
            var userType = this._uow.GenericRepository<UserType>().Table().Where(x => x.UserTypeDescription.ToLower().Trim() == "provider").FirstOrDefault();

            if (userType != null && userType.UserTypeId == userCheck.UserTypeID)
            {
                if (provider == null)
                {
                    provider = new Provider();

                    provider.NPI = userCheck.NPIID.ToString();
                    provider.UserID = userCheck.UserID;
                    provider.NameLast = userCheck.NameLast;
                    provider.NameMiddle = userCheck.NameMiddle;
                    provider.NameFirst = userCheck.NameFirst;
                    provider.NamePrefix = userCheck.NamePrefix;
                    provider.NameSuffix = userCheck.NameSuffix;
                    provider.Credential = userCheck.Credential;
                    provider.Title = userCheck.Title;
                    provider.BirthDate = userCheck.DateOfBirth;
                    provider.GenderID = this._uow.GenericRepository<CommonMaster>().Table().
                                    Where(x => x.Description.ToLower().Trim() == userCheck.Sex.ToLower().Trim() ||
                                          x.Code.ToLower().Trim() == userCheck.Sex.ToLower().Trim()).FirstOrDefault().CommonMasterID;
                    provider.AddressLine1 = userCheck.AddressLine1;
                    provider.AddressLine2 = userCheck.AddressLine2;
                    provider.City = userCheck.City;
                    provider.State = userCheck.State;
                    provider.County = userCheck.County;
                    provider.ZIP = userCheck.ZIP;
                    provider.Phone = userCheck.PhoneNumber;
                    provider.AlternatePhone = userCheck.AlternatePhone;
                    provider.Fax = userCheck.Fax;
                    provider.Email = userCheck.Email;
                    provider.IsActive = true;
                    provider.Deleted = false;
                    provider.CreatedDate = DateTime.Now;
                    provider.CreatedBy = "User";

                    this._uow.GenericRepository<Provider>().Insert(provider);
                }
                else
                {
                    provider.NPI = userCheck.NPIID.ToString();
                    provider.UserID = userCheck.UserID;
                    provider.NameLast = userCheck.NameLast;
                    provider.NameMiddle = userCheck.NameMiddle;
                    provider.NameFirst = userCheck.NameFirst;
                    provider.NamePrefix = userCheck.NamePrefix;
                    provider.NameSuffix = userCheck.NameSuffix;
                    provider.Credential = userCheck.Credential;
                    provider.Title = userCheck.Title;
                    provider.BirthDate = userCheck.DateOfBirth;
                    provider.GenderID = this._uow.GenericRepository<CommonMaster>().Table().
                                    Where(x => x.Description.ToLower().Trim() == userCheck.Sex.ToLower().Trim() ||
                                          x.Code.ToLower().Trim() == userCheck.Sex.ToLower().Trim()).FirstOrDefault().CommonMasterID;
                    provider.AddressLine1 = userCheck.AddressLine1;
                    provider.AddressLine2 = userCheck.AddressLine2;
                    provider.City = userCheck.City;
                    provider.State = userCheck.State;
                    provider.County = userCheck.County;
                    provider.ZIP = userCheck.ZIP;
                    provider.Phone = userCheck.PhoneNumber;
                    provider.AlternatePhone = userCheck.AlternatePhone;
                    provider.Fax = userCheck.Fax;
                    provider.Email = userCheck.Email;
                    provider.IsActive = true;
                    provider.Deleted = false;
                    provider.ModifiedDate = DateTime.Now;
                    provider.ModifiedBy = "User";

                    this._uow.GenericRepository<Provider>().Update(provider);
                }
                this._uow.Save();
            }
            

            return userRecord;
        }

        public string SetupTenantsforUser(int UserId, string TenantIDs)
        {
            string Value = "";
            var currentUser = this._httpContextAccessor.HttpContext.User.Identity.Name;
            var userTobeAdded = this._uow.GenericRepository<UserTenantSetup>().Table().Where(x => x.UserID == UserId).FirstOrDefault();
            var CurrentUserData = this._uow.GenericRepository<UserData>().Table().Where(x => x.UserName.ToLower().Trim() == currentUser.ToLower().Trim()).FirstOrDefault();

            if (userTobeAdded != null && (CurrentUserData.UserTypeID == 1 || CurrentUserData.UserTypeID == 2))
            {
                if (TenantIDs != null && TenantIDs != "")
                {
                    userTobeAdded.TenantIDs = TenantIDs.Trim();

                    this._uow.GenericRepository<UserTenantSetup>().Update(userTobeAdded);
                    this._uow.Save();
                    Value = "Tenant Setup is completed for the selected User";
                }
                else
                {
                    Value = "Invalid selection";
                }

            }
            else
            {
                Value = "The current user does not have permission to Setup the Tenants or selected User does not exist";
            }

            return Value;
        }

        public string VerifyOTP(string userMail, int OTPnumber)
        {
            string status = "";
            var userOTPRecord = this._uow.GenericRepository<UserOTPDetails>().Table().Where(x => x.UserEmail.ToLower().Trim() == userMail.ToLower().Trim()).FirstOrDefault();

            if (userOTPRecord == null)
            {
                status = "No record exists for this user";
            }
            else
            {
                if (userOTPRecord != null && userOTPRecord.OTP == OTPnumber)
                {
                    status = "Verification success";
                }
                else
                {
                    status = "OTP number not matched";
                }
            }
            return status;
        }

        #region User File Upload
        public List<clsViewFile> GetFile(string Id, string screen)
        {
            string moduleName = "";
            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            //if (hostingEnvironment.WebRootPath != null)
            moduleName = _hostingEnvironment.WebRootPath + "\\Documents\\" + screen + "\\" + Id;

            var fileLoc = this.GetFiles(moduleName);

            return fileLoc;
        }
        public List<clsViewFile> GetFiles(string modulePath)
        {
            List<clsViewFile> viewLst = new List<clsViewFile>();
            try
            {
                const string DefaultContentType = "application/octet-stream";
                if (Directory.Exists(modulePath))
                {
                    string[] fileEntries = Directory.GetFiles(modulePath);

                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        clsViewFile vwFile = new clsViewFile();
                        FileInfo file = new FileInfo(fileEntries[i]);
                        FileStream reader = new FileStream(fileEntries[i], FileMode.Open, FileAccess.Read);

                        var provider = new FileExtensionContentTypeProvider();
                        if (!provider.TryGetContentType(fileEntries[i], out string contentType))
                        {
                            contentType = DefaultContentType;
                        }

                        vwFile.FileUrl = fileEntries[i].Replace("\\", "/");
                        vwFile.FileName = Path.GetFileName(fileEntries[i]);
                        vwFile.FileType = contentType;
                        vwFile.FileSize = Convert.ToString(file.Length / 1024) + " KB";

                        byte[] buffer = new byte[reader.Length];
                        reader.Read(buffer, 0, (int)reader.Length);
                        reader.ReadByte();
                        var b = Convert.ToBase64String(buffer);
                        vwFile.ActualFile = b;
                        viewLst.Add(vwFile);
                        reader.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return viewLst;
        }
        #endregion

    }
}
