using System.Collections.Generic;

namespace EndocPM.WebAPI
{
    public interface IELabService
    {
        PatientLabOrderTestModel AddupdatePatientLabOrder(PatientLabOrderTestModel patientLabOrderTestModel);
        List<PatientLabOrderTestModel> GetELabOrderTest();
        List<PatientLabOrderTestModel> GetELabOrderTestByPatientId(int PatientId);
        List<PatientLabOrderTestModel> GetELabOrderTestbyPatientLabOrderTestID(int patientLabOrderTestId);
        string GetEmdeonLabRequestPlacerOrderByPatientID(int patientID);
        LabRequestModel GetEmdeonLabRequestByID(LabRequestModel labrequest);
        LabRequestModel AddUpdateLabRequest(LabRequestModel labRequestModel);
        List<LabRequestModel> GetLabRequestList();
        List<LabRequestModel> GetLabRequestListbyLabRequestID(int LabRequestID);
        LabResponseHL7Model AddUpdateLabResponseHL7(LabResponseHL7Model labResponseHL7Model);
        LabResponseHL7Model GetLabResponseDataByID(int labrequestID);
        string GetLabReportReponseXml(int patientLabOrderTestID);
        List<LabResponseHL7Model> GetLabResponseHL7();
        List<LabResponseHL7Model> GetLabResponseHL7byLabResponseID(int LabResponseHLID);
        List<LabResponseHL7Model> GetLabResponseHL7byPatientLabOrderTestID(int PatientLabOrderTestID);
        List<EmdeonUserSetupModel> GetEmdeonUserSetups();
    }
}
