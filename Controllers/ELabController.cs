using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ELabController : ControllerBase
    {
        public readonly IELabService _iELabService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ELabController(IELabService iELabService, IWebHostEnvironment hostingEnvironment)
        {
            _iELabService = iELabService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public PatientLabOrderTestModel AddupdatePatientLabOrder(PatientLabOrderTestModel patientLabOrderTestModel)
        {
            return this._iELabService.AddupdatePatientLabOrder(patientLabOrderTestModel);
        }

        [HttpGet]
        public List<PatientLabOrderTestModel> GetELabOrderTest()
        {
            return this._iELabService.GetELabOrderTest();
        }

        [HttpGet]
        public List<PatientLabOrderTestModel> GetELabOrderTestByPatientId(int PatientId)
        {
            return this._iELabService.GetELabOrderTestByPatientId(PatientId);
        }

        [HttpGet]
        public List<PatientLabOrderTestModel> GetELabOrderTestbyPatientLabOrderTestID(int patientLabOrderTestId)
        {
            return this._iELabService.GetELabOrderTestbyPatientLabOrderTestID(patientLabOrderTestId);
        }

        [HttpGet]
        public List<string> GetEmdeonLabRequestPlacerOrderByPatientID(int patientID)
        {
          
            List<string> status = new List<string>();
            status.Add(this._iELabService.GetEmdeonLabRequestPlacerOrderByPatientID(patientID));
            return status;
        }

        [HttpPost]
        public LabRequestModel AddUpdateLabRequest(LabRequestModel labRequestModel)
        {
            return this._iELabService.AddUpdateLabRequest(labRequestModel);
        }

        [HttpGet]
        public List<LabRequestModel> GetLabRequestList()
        {
            return this._iELabService.GetLabRequestList();
        }

        [HttpGet]
        public List<LabRequestModel> GetLabRequestListbyLabRequestID(int LabRequestID)
        {
            return this._iELabService.GetLabRequestListbyLabRequestID(LabRequestID);
        }

        [HttpPost]
        public LabRequestModel GetEmdeonLabRequestByID(LabRequestModel labrequest)
        {
            return this._iELabService.GetEmdeonLabRequestByID(labrequest);
        }

        [HttpPost]
        public LabResponseHL7Model AddUpdateLabResponseHL7(LabResponseHL7Model labResponseHL7Model)
        {
            return this._iELabService.AddUpdateLabResponseHL7(labResponseHL7Model);
        }


        [HttpGet]
        public LabResponseHL7Model GetLabResponseDataByID(int labrequestID)
        {
            return this._iELabService.GetLabResponseDataByID(labrequestID);
        }

        [HttpGet]
        public List<string> GetLabReportReponseXml(int patientLabOrderTestID)
        {
            List<string> status = new List<string>();
            status.Add(this._iELabService.GetLabReportReponseXml(patientLabOrderTestID));
            return status;
        }

        [HttpGet]
        public List<LabResponseHL7Model> GetLabResponseHL7()
        {
            return this._iELabService.GetLabResponseHL7();
        }

        [HttpGet]
        public List<LabResponseHL7Model> GetLabResponseHL7byLabResponseID(int LabResponseHLID)
        {
            return this._iELabService.GetLabResponseHL7byLabResponseID(LabResponseHLID);
        }

        [HttpGet]
        public List<LabResponseHL7Model> GetLabResponseHL7byPatientLabOrderTestID(int PatientLabOrderTestID)
        {
            return this._iELabService.GetLabResponseHL7byPatientLabOrderTestID(PatientLabOrderTestID);
        }

        [HttpGet]
        public List<EmdeonUserSetupModel> GetEmdeonUserSetups()
        {
            return this._iELabService.GetEmdeonUserSetups();
        }

    }
}
