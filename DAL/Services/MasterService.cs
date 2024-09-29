using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.StaticFiles;

namespace EndocPM.WebAPI
{
    public class MasterService : IMasterService
    {
        public readonly IUnitOfWork _uow;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        private IWebHostEnvironment _hostingEnvironment;


        public MasterService()
        {

        }


        public MasterService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public DateTime GetLocalTime(DateTime dateTime)
        {
            int offSet = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Headers["offSet"]) * -1;
            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime.ToUniversalTime().AddMinutes(offSet);
            }
            else
            {
                return dateTime.AddMinutes(offSet);
            }
        }
        public List<CountryCode> GetCountryCodes()
        {
            var CounCodes = (from coun in this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Deleted != true)
                             select new
                             {
                                 coun.CountryCodeID,
                                 coun.Code,
                                 coun.CreatedDate

                             }).AsEnumerable().Select(CC => new CountryCode
                             {
                                 CountryCodeID = CC.CountryCodeID,
                                 Code = CC.Code,
                                 CreatedDate = CC.CreatedDate

                             }).ToList();
            return CounCodes;
        }
        public void AddorUpdateCountryCode(CountryCode code)
        {

            CountryCode coCode = (from c in this._uow.GenericRepository<CountryCode>().Table().Where(x => x.Code == code.Code & x.Deleted != true) select c).OrderByDescending(x => x.CountryCodeID).FirstOrDefault();

            coCode.Deleted = true;
            coCode.ModifiedDate = DateTime.Now;
            coCode.ModifiedBy = "User";

            this._uow.GenericRepository<CountryCode>().Update(coCode);
            this._uow.Save();

        }
        public List<StateCode> GetStateCodes()
        {
            var stateCodes = (from sCode in this._uow.GenericRepository<StateCode>().Table().Where(x => x.Deleted != true)
                              select new
                              {
                                  sCode.StateCodeID,
                                  sCode.Code,
                                  sCode.StateName

                              }).AsEnumerable().Select(SC => new StateCode
                              {
                                  StateCodeID = SC.StateCodeID,
                                  Code = SC.Code,
                                  StateName = SC.StateName

                              }).ToList();
            return stateCodes;
        }
        public List<PostalCode> GetPostalCodes()
        {
            var postalCodes = (from pCode in this._uow.GenericRepository<PostalCode>().Table().Where(x => x.Deleted != true)
                               select new
                               {
                                   pCode.PostalCodeID,
                                   pCode.City,
                                   pCode.County,
                                   pCode.State,
                                   pCode.ZIP

                               }).AsEnumerable().Select(PC => new PostalCode
                               {
                                   PostalCodeID = PC.PostalCodeID,
                                   City = PC.City,
                                   County = PC.County,
                                   State = PC.State,
                                   ZIP = PC.ZIP

                               }).ToList();
            return postalCodes;
        }
        public List<UserType> GetUserTypes()
        {
            var userTypes = (from uType in this._uow.GenericRepository<UserType>().Table().Where(x => x.Deleted != true)
                             select new
                             {
                                 uType.UserTypeId,
                                 uType.UserTypeCode,
                                 uType.UserTypeDescription

                             }).AsEnumerable().Select(UT => new UserType
                             {
                                 UserTypeId = UT.UserTypeId,
                                 UserTypeCode = UT.UserTypeCode,
                                 UserTypeDescription = UT.UserTypeDescription

                             }).ToList();
            return userTypes;
        }
        public List<CommonMasterModel> GetAllCommonMasterList()
        {
            var query = (from cm in this._uow.GenericRepository<CommonMaster>().Table()
                         where (!cm.Deleted)
                         orderby cm.Category, cm.Description
                         select new
                         {
                             CommonMasterID = cm.CommonMasterID,
                             Category = cm.Category,
                             Code = cm.Code,
                             Description = cm.Description,
                             HIPAACode = cm.HIPAACode,
                             DisplayOrder = cm.DisplayOrder,
                             Notes = cm.Notes,
                             Deleted = cm.Deleted,
                             CreatedDate = cm.CreatedDate,
                             CreatedBy = cm.CreatedBy,
                             ModifiedDate = cm.ModifiedDate,
                             ModifiedBy = cm.ModifiedBy
                         }).AsEnumerable().Select(x => new CommonMasterModel
                         {

                             CommonMasterID = x.CommonMasterID,
                             Category = x.Category,
                             Code = x.Code,
                             Description = x.Description,
                             HIPAACode = x.HIPAACode,
                             DisplayOrder = x.DisplayOrder,
                             Notes = x.Notes,
                             Deleted = x.Deleted,
                             CreatedDate = x.CreatedDate,
                             CreatedBy = x.CreatedBy,
                             ModifiedDate = x.ModifiedDate,
                             ModifiedBy = x.ModifiedBy
                         });

            var commonMasterList = query.ToList();
            return commonMasterList;
        }
        public List<CommonMasterModel> GetMasterListByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<CommonMasterModel>();
            var query = (from cm in this._uow.GenericRepository<CommonMaster>().Table().Where(
                cm => (!cm.Deleted) && (cm.Category.ToLower().Trim() == category.ToLower().Trim()))

                         orderby cm.DisplayOrder
                         select new
                         {
                             CommonMasterID = cm.CommonMasterID,
                             Category = cm.Category,
                             Code = cm.Code,
                             Description = cm.Description,
                             HIPAACode = cm.HIPAACode,
                             DisplayOrder = cm.DisplayOrder,
                             Notes = cm.Notes,
                             Deleted = cm.Deleted,
                             CreatedDate = cm.CreatedDate,
                             CreatedBy = cm.CreatedBy,
                             ModifiedDate = cm.ModifiedDate,
                             ModifiedBy = cm.ModifiedBy
                         }).AsEnumerable().Select(x => new CommonMasterModel
                         {
                             CommonMasterID = x.CommonMasterID,
                             Category = x.Category,
                             Code = x.Code,
                             Description = x.Description,
                             HIPAACode = x.HIPAACode,
                             DisplayOrder = x.DisplayOrder,
                             Notes = x.Notes,
                             Deleted = x.Deleted,
                             CreatedDate = x.CreatedDate,
                             CreatedBy = x.CreatedBy,
                             ModifiedDate = x.ModifiedDate,
                             ModifiedBy = x.ModifiedBy
                         });
            var commonMasterList = query.ToList();
            return commonMasterList;
        }
        #region  GetIntervalMessageType
        public List<CommonMasterModel> GetIntervalMessageType()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "intervalmessagetype"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var getmessage = query.ToList();
            return getmessage;
        }
        #endregion
        public List<ImmunizationRoute> GetImmunizationRouteList()
        {
            var immunizationRouteList = this._uow.GenericRepository<ImmunizationRoute>().Table().Where(x => !x.Deleted).ToList();
            return immunizationRouteList;
        }
        public List<PublicityCode> GetPublicityCodeList()
        {
            var query = this._uow.GenericRepository<PublicityCode>().Table().Where(x => !x.Deleted).ToList();
            return query;
        }
        #region GetInsuranceCategoryDescriptionByID
        public string GetInsuranceCategoryDescriptionByID(int insuranceCategoryID)
        {
            //  int incatid = Convert.ToInt32(insuranceCategoryID);

            if (insuranceCategoryID == 0)
                return "";
            var query = from ica in this._uow.GenericRepository<InsuranceCategory>().Table()
                        where (!ica.Deleted) && (ica.InsuranceCategoryID == insuranceCategoryID)
                        orderby ica.Description ascending
                        select ica.Description;
            var result = query.FirstOrDefault();
            return result;
        }
        #endregion
        #region GetFacilityDescriptionByID
        public string GetFacilityDescriptionByID(int facilityID)
        {



            if (facilityID == 0)
                return "";
            var query = from fa in this._uow.GenericRepository<Facility>().Table()
                        where (!fa.Deleted) && (fa.FacilityID == facilityID)
                        orderby fa.FacilityName ascending
                        select fa.FacilityName;
            var result = query.FirstOrDefault();
            return result;
        }
        #endregion
        #region PostalCodeModel & country
        public PostalCodeModel GetCityStateCountyByZipCode(string zipCode)
        {


            var query = from pc in this._uow.GenericRepository<PostalCode>().Table()
                        join c in this._uow.GenericRepository<CountryCode>().Table() on pc.PostalCodeID equals c.CountryCodeID
                        where (!pc.Deleted)  // && (pc.ZIP == zipCode.Trim())
                        select new PostalCodeModel()
                        {
                            PostalCodeID = pc.PostalCodeID,
                            ZIP = pc.ZIP,
                            City = pc.City,
                            State = pc.State,
                            County = pc.County,
                            Country = c.CountryName
                        };

            var cityStateCounty = query.FirstOrDefault();
            return cityStateCounty;

        }
        #endregion
        #region GetFeeSchedules
        public List<FeeScheduleModel> GetFeeSchedules()
        {
            var feeSchedule = (from fs in this._uow.GenericRepository<FeeSchedule>().Table()
                               orderby fs.FeeScheduleNO ascending
                               where (!fs.Deleted)
                               select new
                               {

                                   FeeScheduleID = fs.FeeScheduleID,
                                   FeeScheduleNO = fs.FeeScheduleNO,
                                   CodeQualifier = fs.CodeQualifier,
                                   FeeScheduleStatus = fs.FeeScheduleStatus,
                                   EffectiveDate = fs.EffectiveDate,
                                   TerminationDate = fs.TerminationDate
                               }).AsEnumerable().Select(fs => new FeeScheduleModel
                               {
                                   FeeScheduleID = fs.FeeScheduleID,
                                   FeeScheduleNO = fs.FeeScheduleNO,
                                   CodeQualifier = fs.CodeQualifier,
                                   FeeScheduleStatus = fs.FeeScheduleStatus,
                                   EffectiveDate = fs.EffectiveDate,
                                   TerminationDate = fs.TerminationDate
                               }).ToList();
            var feeSchedules = feeSchedule.Distinct().ToList();
            return feeSchedules;
        }
        #endregion
        #region GetTypeOfPayment
        public List<CommonMasterModel> GetTypeOfPayment()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "paymenttype"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };
            var typeOfPayment = query.ToList();
            return typeOfPayment;
        }
        #endregion
        #region Email With Otp
        public string SendEmail(string recipientEmail, string recipientFirstName)
        {
            var userOTPRecord = this._uow.GenericRepository<UserOTPDetails>().Table().Where(x => x.UserEmail.ToLower().Trim() == recipientEmail.ToLower().Trim()).FirstOrDefault();

            Random rnd = new Random();
            int otp = rnd.Next(10000, 99999);
            if (userOTPRecord != null && userOTPRecord.OTP != null && userOTPRecord.OTP.Value > 0)
            {
                otp = userOTPRecord.OTP.Value;
            }
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_configuration["EmailConfiguration:From"]));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "OTP for EndocPM User Registration";
            message.Body = new TextPart("plain")
            {
                Text = "Hi " + recipientFirstName + ", " + otp + " is your OTP for Endoc Provider portal Registration."
            };

            var client = new SmtpClient();

            try
            {
                client.Connect(_configuration["EmailConfiguration:SmtpServer"], Convert.ToInt32(_configuration["EmailConfiguration:Port"]), true);
                client.Authenticate(new NetworkCredential(_configuration["EmailConfiguration:Username"], _configuration["EmailConfiguration:Password"]));
                client.Send(message);
                client.Disconnect(true);

                if (userOTPRecord == null)
                {
                    userOTPRecord = new UserOTPDetails();

                    userOTPRecord.UserEmail = recipientEmail;
                    userOTPRecord.OTP = otp;

                    this._uow.GenericRepository<UserOTPDetails>().Insert(userOTPRecord);
                }
                this._uow.Save();

                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }
        #endregion
        #region Upload File
        public void UploadFile(List<IFormFile> files, string subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;
            var target = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);

            Directory.CreateDirectory(target);

            files.ForEach(file =>
            {
                if (file.Length <= 0) return;
                var filePath = Path.Combine(target, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            });
        }
        #endregion
        #region
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
        #endregion
        #region Size Converter
        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
        #endregion

        public void WriteMultipleFiles(List<IFormFile> Files, string curHostedPath)
        {
            try
            {
                if (Files.Count() > 0)
                {
                    foreach (var file in Files)
                    {
                        if (!Directory.Exists(curHostedPath))
                        {
                            Directory.CreateDirectory(curHostedPath);
                        }


                        var path = Path.Combine(curHostedPath, file.FileName);


                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mess = e.Message;
            }


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

        public List<string> DeleteFile(string path, string fileName)
        {
            List<string> filestatus = new List<string>();

            string status;
            if (Directory.Exists(path))
            {
                if (File.Exists(Path.Combine(path, fileName)))
                {
                    File.Delete(Path.Combine(path, fileName));
                }

                status = "File deleted";
            }
            else
            {
                status = "File does not exist";
            }
            filestatus.Add(path);
            filestatus.Add(status);

            return filestatus;
        }

        #region getbyStatus medication
        public List<CommonMaster> GetBystatusMedication()
        {
            var medication = (from a in this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true)
                              select
                              new
                              {
                                  a.Category,
                                  a.Description,
                              }).AsEnumerable().Select(x => new CommonMaster
                              {
                                  Category = x.Category,
                                  Description = x.Description,
                              }).ToList();
            return medication;
        }
        public List<StatusModel> GetStatusValues()
        {
            List<StatusModel> statuses = (from a in this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true &
                                          x.Category.ToLower().Trim() == "medicalhistorystatus")
                                          select
                                          new
                                          {
                                              a.CommonMasterID,
                                              a.Category,
                                              a.Description,
                                          }).AsEnumerable().Select(x => new StatusModel
                                          {
                                              StatusID = x.CommonMasterID,
                                              Category = x.Category,
                                              StatusDescritpion = x.Description,
                                          }).ToList();
            return statuses;
        }
        #endregion

        public IList<Product> GetProducts()
        {
            var productList = (from p in this._uow.GenericRepository<Product>().Table().Where(x => x.Deleted != true)
                               select
                               new
                               {
                                   p.ProductID,
                                   p.ProductName,
                                   p.Discount,
                                   p.NoOfProvider,
                                   p.DiscountRate,
                                   p.Rate
                               }).AsEnumerable().Select(pp => new Product
                               {
                                   ProductID = pp.ProductID,
                                   ProductName = pp.ProductName,
                                   Discount = pp.Discount,
                                   NoOfMember = pp.NoOfProvider,
                                   DiscountRate = pp.DiscountRate,
                                   Rate = pp.Rate
                               }).ToList();
            return productList;
        }
        public List<HumanBodySite> GetHumanBodySite()
        {
            var humanBody = this._uow.GenericRepository<HumanBodySite>().Table().Where(x => x.Deleted != true).ToList();

            return humanBody;
        }
        #region GetAllergyseverity
        public List<CommonMasterModel> GetAllergyseverity()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "allergyseverity"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var getRep = query.ToList();
            return getRep;
        }
        #endregion
        #region GetAllergyOnset
        public List<CommonMasterModel> GetAllergyOnset()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "allergyonset"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var geton = query.ToList();
            return geton;
        }
        #endregion
        #region GetTobaccouse(Smoking Category)
        public List<CommonMasterModel> GetTobaccouse()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "smokingcategory"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var smoke = query.ToList();
            return smoke;

        }
        #endregion
        # region   GetAlcoholuse(Drinking Status)
        public List<CommonMasterModel> GetAlcoholuse()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "drinkingstatus"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var smoke = query.ToList();
            return smoke;

        }
        #endregion
        public List<CommonMasterModel> GetGender()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "gender"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var getgender = query.ToList();
            return getgender;
        }  
        public List<DocumentType> GetDocumentTypeList()
        {
            var document = (from a in this._uow.GenericRepository<DocumentType>().Table().Where(x => x.Deleted != true)
                            select new DocumentType
                            {
                                DocumentTypeID = a.DocumentTypeID,
                                Description = a.Description,
                                DocumentTypeCode = a.DocumentTypeCode
                            }).ToList();


            return document;
        }
        public List<CommonMasterModel> GetMaritalStatus()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "maritalstatus"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var getmarital = query.ToList();
            return getmarital;
        }
        public List<PatientRelation> GetRelationship()
        {
            var Relation = this._uow.GenericRepository<PatientRelation>().Table().Where(x => x.Deleted != true).ToList();

            return Relation;
        }
        public List<CommonMaster> GetByallAllergies()
        {
            List<CommonMaster> allergies = this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.Category.ToLower().Trim() == "allergytype").ToList();

            return allergies;
        }
        public List<CountryCode> GetCountryCodesbysearchkey(string Searchkey)
        {
            List<CountryCode> codes = (from c in this._uow.GenericRepository<CountryCode>().Table()
                                       where (Searchkey == null || (c.Code.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || c.CountryName.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                                       select c).Take(50).ToList();
            return codes;
        }      
        public List<DiagnosisCode> GetAlldiagnosisCodes(string searchKey)
        {
            var diagnosisCodes = (from diag in this._uow.GenericRepository<DiagnosisCode>().Table()
                                  where (searchKey == null || (diag.ICDCode.ToLower().Trim().Contains(searchKey.ToLower().Trim()) ||
                                  diag.ShortDescription.ToLower().Trim().Contains(searchKey.ToLower().Trim()) || diag.LongDescription.ToLower().Trim().Contains(searchKey.ToLower().Trim()) ||
                                  diag.Description.ToLower().Trim().Contains(searchKey.ToLower().Trim())))
                                  select diag).Take(50).ToList();

            return diagnosisCodes;
        }
        public List<PostalCode> GetCityStateCountyByZipCodebysearchkey(string Searchkey)
        {
            List<PostalCode> post = (from c in this._uow.GenericRepository<PostalCode>().Table()
                                     where (Searchkey == null || (c.ZIP.Contains(Searchkey.ToLower().Trim())))
                                     select c).Take(50).ToList();

            return post;
        }
        public List<RefusalReasonCode> GetRefusalReasonCodeModels()
        {
            var refual = (from a in this._uow.GenericRepository<RefusalReasonCode>().Table().Where(x => x.Deleted != true)
                          select
                          new
                          RefusalReasonCode
                          {
                              RefusalReasonCodeID = a.RefusalReasonCodeID,
                              Code = a.Code,
                              Description = a.Description
                          }).ToList();


            return refual;
        }
        public List<VFCFinancialClass> GetVFCFinancialClassModels()
        {
            var vfcfinancialClass = (from a in this._uow.GenericRepository<VFCFinancialClass>().Table().Where(x => x.Deleted != true)
                                     select
                                     new VFCFinancialClass
                                     {
                                         VFCFinancialClassID = a.VFCFinancialClassID,
                                         Code = a.Code,
                                         Description = a.Description
                                     }).ToList();
            return vfcfinancialClass;
        }
        public List<ImmunizationInformationSource> GetImmunizationInformationSourceModels()
        {
            var Immunization = (from a in this._uow.GenericRepository<ImmunizationInformationSource>().Table().Where(x => x.Deleted != true)
                                select a).ToList();
            return Immunization;
        }
        public List<ImmunizationRegistryStatus> GetImmunizationRegistryStatuses()
        {
            List<ImmunizationRegistryStatus> RegistryStatus = this._uow.GenericRepository<ImmunizationRegistryStatus>().Table().Where(x => x.Deleted != true).ToList();

            return RegistryStatus;
        }
        public List<DosageForm> GetDosageFormModelsbysearchkey(string Searchkey)
        {
            var dosageform = (from a in this._uow.GenericRepository<DosageForm>().Table()
                              where (Searchkey == null || (a.Code.Contains(Searchkey.ToLower().Trim())) || a.Description.Contains(Searchkey.ToLower().Trim()))
                              select a).Take(50).ToList();
            return dosageform;
        }
        public List<InsuranceCategory> insuranceCategories()
        {
            var insuranceCategory = (from a in this._uow.GenericRepository<InsuranceCategory>().Table().Where(x => x.Deleted != true)
                                     select a).ToList();

            return insuranceCategory;
        }
        public List<DrugCode> GetDrugCodeSearchkeys(string Searchkey)
        {
            var drugcodename = (from a in this._uow.GenericRepository<DrugCode>().Table()
                                where (Searchkey == null || (a.NDCCode.Contains(Searchkey.ToLower().Trim())) || a.Description.Contains(Searchkey.ToLower().Trim()))
                                select a).Take(50).ToList();
            return drugcodename;


        }
        public List<DispenseForm> GetDispenseFormDatabysearchKey(string searchKey)
        {
            var dispenseData = (from dis in this._uow.GenericRepository<DispenseForm>().Table()
                                where (searchKey == null || (dis.Code.ToLower().Trim().Contains(searchKey.ToLower().Trim()) || dis.Description.ToLower().Trim().Contains(searchKey.ToLower().Trim())))
                                select dis).Take(50).ToList();

            return dispenseData;
        }
        public List<CommonMaster> Typeofpayment()
        {
            List<CommonMaster> typeofpayment = this._uow.GenericRepository<CommonMaster>().Table().Where(x => x.Deleted != true & x.Category.ToLower().Trim() == "PaymentType").ToList();

            return typeofpayment;
        }
        public List<Facility> GetFacilityname()
        {
            var facility = (from a in this._uow.GenericRepository<Facility>().Table().Where(x => x.Deleted != true)
                            select
                            new Facility
                            {
                                FacilityID = a.FacilityID,
                                FacilityName = a.FacilityName
                            }).ToList();

            return facility;
        }
        public List<FeeSchedule> GetFeeScheduless()
        {
            var feeSchedule = (from a in this._uow.GenericRepository<FeeSchedule>().Table().Where(x => x.Deleted != true)
                               select
                               new FeeSchedule
                               {
                                   FeeScheduleID = a.FeeScheduleID,
                                   FeeScheduleStatus = a.FeeScheduleStatus,
                               }).ToList();
            return feeSchedule;
        }
        public List<CommonMasterModel> GetRepeat()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "repeat"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var getrepeat = query.ToList();
            return getrepeat;
        }
        public List<AppointmentType> GetAppointmenttype()
        {
            var query = (from a in this._uow.GenericRepository<AppointmentType>().Table()
                         select a).ToList();

            return query;



        }
        public List<InsuranceCompany> GetInsuranceCompanysearchkey(string SearchKey)
        {
            var insurances = (from dis in this._uow.GenericRepository<InsuranceCompany>().Table()
                              where (SearchKey == null || (dis.OrganizationID.ToLower().Trim().Contains(SearchKey.ToLower().Trim()) || dis.OrganizationName.ToLower().Trim().Contains(SearchKey.ToLower().Trim())))
                              select dis).Take(100).ToList();

            return insurances;
        }
        public List<Speciality> GetTaxonomyCode(string Searchkey)
        {
            var speciality = (from a in this._uow.GenericRepository<Speciality>().Table()
                              where (Searchkey == null || (a.SpecialityCode.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.SpecialityDescription.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                              select new Speciality
                              {
                                  SpecialityCode = a.SpecialityCode,
                                  SpecialityDescription = a.SpecialityDescription,
                                  SpecialityID = a.SpecialityID,
                              });
            var specialitylist = speciality.ToList();

            var subspeciality = (from a in this._uow.GenericRepository<SubSpeciality>().Table()
                                 where (Searchkey == null || (a.SpecialityCode.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.SubSpecialityDescription.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                                 select new SubSpeciality
                                 {
                                     SpecialityCode = a.SpecialityCode,
                                     SubSpecialityDescription = a.SubSpecialityDescription,
                                     SpecialityID = a.SpecialityID

                                 });
            var subspecialitylist = specialitylist.ToList();

            var addvalues = specialitylist.Concat(subspecialitylist).ToList();

            return addvalues;


        }
        public List<RegionalLanguage> GetRegionalLanguages(string Searchkey)
        {
            var reginal = (from a in this._uow.GenericRepository<RegionalLanguage>().Table()
                           where (Searchkey == null || (a.Code.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.Description.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                           select new RegionalLanguage
                           {
                               Code = a.Code,
                               Description = a.Description,
                               RegionalLanguageID = a.RegionalLanguageID
                           }).ToList();

            return reginal;
        }
        public List<PharmacyModel> PharmacyListSearch(PharmacyModel pharmacyModel)
        {
            var query = (from ph in this._uow.GenericRepository<Pharmacy>().Table().Where(x=> x.Deleted !=true)
                         select new
                         {
                             PharmacyID = ph.PharmacyID,
                             NPI = ph.NPI,
                             PharmacyName = ph.PharmacyName,
                             Address = ph.AddressLine1 + " " + ph.AddressLine2,
                             Country = ph.Country,
                             Zip = ph.ZIP,
                             County = ph.County,
                             City = ph.City,
                             State = ph.State,
                             Telephone = ph.Telephone,
                             CreatedDate = ph.CreatedDate,
                             CreatedBy = ph.CreatedBy,
                             ModifiedDate = ph.ModifiedDate,
                             ModifiedBy = ph.ModifiedBy,
                             Email =ph.Email,
                             
                             
                         }).AsEnumerable().Select(PH => new PharmacyModel
                         {
                             PharmacyID = PH.PharmacyID,
                             NPI = PH.NPI,
                             PharmacyName = PH.PharmacyName,
                             Address = PH.Address,
                             ZIP = PH.Zip,
                             Country = PH.Country,
                             City = PH.City,
                             County = PH.County,
                             State = PH.State,
                             Telephone = PH.Telephone,
                             CreatedDate = PH.CreatedDate,
                             CreatedBy = PH.CreatedBy,
                             ModifiedDate = PH.ModifiedDate,
                             ModifiedBy = PH.ModifiedBy,
                             Email =PH.Email
                         }).ToList();


            query = (from PHM in query
                     where ((pharmacyModel.PharmacyName != null && PHM.PharmacyName.ToLower().Trim() == pharmacyModel.PharmacyName.ToLower().Trim())&&
                            (pharmacyModel.Address != null || PHM.Address.ToLower().Trim() == pharmacyModel.Address.ToLower().Trim())&&
                           (pharmacyModel.City != null || PHM.City.ToLower().Trim() == pharmacyModel.City.ToLower().Trim()) &&
                           (pharmacyModel.State != null || PHM.State.ToLower().Trim() == pharmacyModel.State.ToLower().Trim()) &&
                           (pharmacyModel.ZIP != null || PHM.ZIP.ToLower().Trim() == pharmacyModel.ZIP.ToLower().Trim())
                           )
                     select PHM).Take(50).ToList();


            return query;

            
            //((pharmacyModel.City.ToLower().Trim()) == null || (phm.City == pharmacyModel.City.ToLower().Trim())) &&
            //((pharmacyModel.State.ToLower().Trim()) == null || (phm.State == pharmacyModel.State.ToLower().Trim())) &&
            //((pharmacyModel.ZIP.ToLower().Trim()) == null || (phm.ZIP == pharmacyModel.ZIP.ToLower().Trim()))


            //where ((pharmacyModel == null ||(phm.PharmacyName.ToLower().Trim().Contains(pharmacyModel.PharmacyName.ToLower().Trim()))||(phm.Email.ToLower().Trim().Contains(pharmacyModel.Email.ToLower().Trim())))
            //|| (phm.ZIP.ToLower().Trim().Contains(pharmacyModel.ZIP.ToLower().Trim()) || (phm.Address.ToLower().Trim().Contains(pharmacyModel.Address.ToLower().Trim())))
            //|| (phm.Telephone.ToLower().Trim().Contains(pharmacyModel.Telephone.ToLower().Trim()) || (phm.AlternatePhone.ToLower().Trim().Contains(pharmacyModel.AlternatePhone.ToLower().Trim())))
            //|| (phm.City.ToLower().Trim().Contains(pharmacyModel.City.ToLower().Trim()) || (phm.State.ToLower().Trim().Contains(pharmacyModel.State.ToLower().Trim())))
            //|| (phm.NPI.ToLower().Trim().Contains(pharmacyModel.NPI.ToLower().Trim()))


        }
        public List<Pharmacy> GetPharmacies(string Searchkey)
        {
            var pharmacy = (from a in this._uow.GenericRepository<Pharmacy>().Table()
                            where (Searchkey == null || (a.ZIP.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.PharmacyName.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                            select new Pharmacy
                            {
                                NPI = a.NPI,
                                PharmacyName = a.PharmacyName,
                                PharmacyID = a.PharmacyID,
                                ZIP = a.ZIP
                            }).Take(100).ToList();
            return pharmacy;

        }
        public List<CommonMasterModel> GetConsultationType()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "consultationtype"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Description = cp.Description
                        };

            var getcon = query.ToList();
            return getcon;
        }
        public List<CommonMasterModel> GetDuration()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "duration"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Code = cp.Code,
                            Description = cp.Description
                        };

            var getdur = query.ToList();
            return getdur;
        }
        public List<CommonMasterModel> GetSexualOrientation()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "sexualorientation"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Code = cp.Code,
                            Description = cp.Description
                        };

            var getsot = query.ToList();
            return getsot;
        }
        public List<CommonMasterModel> GetOrderType()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "ordertype"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Code = cp.Code,
                            Description = cp.Description
                        };

            var getsot = query.ToList();
            return getsot;
        }
        public List<Lonic> GetLonic()
        {
           
            var Lon = (from a in this._uow.GenericRepository<Lonic>().Table().Where(x => x.Deleted != true)
                          select
                          new
                          Lonic
                          {
                            LonicID = a.LonicID,
                            Code = a.Code,
                            ShortName = a.ShortName,
                            LongName  = a.LongName,
                            Component =a.Component,
                            Status = a.Status,
                            System = a.System,
                            UnitsAndRange = a.UnitsAndRange,
                            HL7FieldSubFieldID = a.HL7FieldSubFieldID,
                            HL7AttachmentStructure = a.HL7AttachmentStructure,
                            DateLastChanged = a.DateLastChanged,
                            DefinitionDescription = a.DefinitionDescription,
                            RelatedName2 = a.RelatedName2

                         }).Take(100).ToList();


            return Lon;
        }
        public List<EmdeonLab> GetEmdeonLab()
        {
            var lab = this._uow.GenericRepository<EmdeonLab>().Table().Where(x => x.Deleted != true).ToList();

            return lab;
        }
        public List<EmdeonLab> GetEmdeonLabbySearchKey(string SearchKey)
        {
            var emdlab = (from a in this._uow.GenericRepository<EmdeonLab>().Table()
                          where (SearchKey == null || (a.EmdeonLabName.ToLower().Trim().Contains(SearchKey.ToLower().Trim())))
                       select new EmdeonLab
                       {
                           EmdeonLabID = a.EmdeonLabID,
                           EmdeonLabName = a.EmdeonLabName,

                       }).ToList();

            return emdlab;
        }
        public List<Race> GetRace()
        {
            var races = this._uow.GenericRepository<Race>().Table().Where(x => x.Deleted != true).ToList();
        

            return races;
        }

        public List<SigCode> GetSigCodesSearchkey(string Searchkey)
        {
            var sig = (from a in this._uow.GenericRepository<SigCode>().Table()
                       where (Searchkey == null || (a.Code.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.Description.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                       select new SigCode
                       {
                           Code = a.Code,
                           Description = a.Description,
                           SigCodeID = a.SigCodeID
                       }).ToList();
            return sig;
        }

        public List<RegionalLanguage> GetRegionalLanguages()
        {
            var Lan = this._uow.GenericRepository<RegionalLanguage>().Table().Where(x => x.Deleted != true).ToList();

            return Lan;
        }

        public List<Ethnicity> GetEthnicity()
        {
            var eth = this._uow.GenericRepository<Ethnicity>().Table().Where(x => x.Deleted != true).ToList();
        
            return eth;
        }
        public List<InsuranceFeeSchedule> GetInsuranceFeeSchedules()
        {
            var fee = this._uow.GenericRepository<InsuranceFeeSchedule>().Table().Where(x => x.Deleted != true).ToList();
            return fee;
        }
        public List<InsuranceFeeSchedule> GetInsuranceFeeSchedulebySearchkey(string Searchkey)
        {
            var pharmacy = (from a in this._uow.GenericRepository<InsuranceFeeSchedule>().Table()
                            where (Searchkey == null || (a.InsuranceCode.ToLower().Trim().Contains(Searchkey.ToLower().Trim()) || a.ProcedureCode.ToLower().Trim().Contains(Searchkey.ToLower().Trim())))
                            select new InsuranceFeeSchedule
                            {
                                InsuranceCode = a.InsuranceCode,
                                ProcedureCode = a.ProcedureCode,
                                
                            }).Take(100).ToList();
            return pharmacy;


        }

        public List<CommonMasterModel> GetFees()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "feescheduletouse"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Code = cp.Code,
                            Category = cp.Category,
                            Description = cp.Description
                        };

            var getsot = query.ToList();
            return getsot;
        }

        public List<CommonMasterModel> GetElabBillType()
        {
            var query = from cp in this._uow.GenericRepository<CommonMaster>().Table()
                        where (cp.Deleted != true
                        && (cp.Category.ToLower().Trim() == "elabbilltype"))
                        select new CommonMasterModel
                        {
                            CommonMasterID = cp.CommonMasterID,
                            Code = cp.Code,
                            Category = cp.Category,
                            Description = cp.Description
                        };

            var getcon = query.ToList();
            return getcon;
        }


    }


}
