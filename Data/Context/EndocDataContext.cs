using System;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EndocPM.WebAPI;

namespace EndocPM.WebAPI
{
    public class EndocDataContext : DbContext //IdentityDbContext<UserData>
    {
        public static string ConnectionString { get; set; }

        public EndocDataContext(DbContextOptions<EndocDataContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbbuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                dbbuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CountryCodeMap());
            modelBuilder.ApplyConfiguration(new UserTenantSetupMap());
            modelBuilder.ApplyConfiguration(new TenantsMap());
            modelBuilder.ApplyConfiguration(new UserOTPDetailsMap());
            // modelBuilder.ApplyConfiguration(new FeeScheduleMap());
            modelBuilder.ApplyConfiguration(new PatientROSMap());
            modelBuilder.ApplyConfiguration(new PatientProblemListMap());

            modelBuilder.Entity<UserData>().ToTable("UserData", "BMSUsers");
            //modelBuilder.Entity<UserData>().ToTable("UserData", "EndocUsers");
            modelBuilder.Entity<Product>().ToTable("Product", "BMSUsers");
           // modelBuilder.Entity<Product>().ToTable("Product", "EndocUsers");

            // modelBuilder.Entity<CountryCode>().ToTable("CountryCode", "Master");
            modelBuilder.Entity<DiagnosisCode>().ToTable("DiagnosisCode", "Master");
            modelBuilder.Entity<PostalCode>().ToTable("PostalCode", "Master");
            modelBuilder.Entity<StateCode>().ToTable("StateCode", "Master");
            modelBuilder.Entity<UserType>().ToTable("UserType", "Master");
            modelBuilder.Entity<CountryCode>().ToTable("CountryCode", "Master");
            modelBuilder.Entity<FeeSchedule>().ToTable("FeeSchedule", "Master");
            modelBuilder.Entity<Gender>().ToTable("Gender", "Master");
            modelBuilder.Entity<InsuranceCategory>().ToTable("InsuranceCategory", "Master");
            modelBuilder.Entity<PublicityCode>().ToTable("PublicityCode", "Master");
            modelBuilder.Entity<ImmunizationRoute>().ToTable("ImmunizationRoute", "Master");
            modelBuilder.Entity<InsuranceType>().ToTable("InsuranceType", "Master");
            modelBuilder.Entity<HumanBodySite>().ToTable("HumanBodySite", "Master");
            modelBuilder.Entity<AppointmentStatus>().ToTable("AppointmentStatus", "Master");
            modelBuilder.Entity<RefusalReasonCode>().ToTable("RefusalReasonCode", "Master");
            modelBuilder.Entity<VFCFinancialClass>().ToTable("VFCFinancialClass", "Master");
            modelBuilder.Entity<ImmunizationInformationSource>().ToTable("ImmunizationInformationSource", "Master");
            modelBuilder.Entity<ImmunizationRegistryStatus>().ToTable("ImmunizationRegistryStatus", "Master");
            modelBuilder.Entity<DrugCode>().ToTable("DrugCode", "Master");
            modelBuilder.Entity<DosageForm>().ToTable("DosageForm", "Master");
            modelBuilder.Entity<DispenseForm>().ToTable("DispenseForm", "Master");
            modelBuilder.Entity<Speciality>().ToTable("Speciality", "Master");
            modelBuilder.Entity<SubSpeciality>().ToTable("SubSpeciality", "Master");
            modelBuilder.Entity<RegionalLanguage>().ToTable("RegionalLanguage", "Master");
            modelBuilder.Entity<AppointmentType>().ToTable("AppointmentType", "Master");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentType", "Master");
            modelBuilder.Entity<Category>().ToTable("Category", "Master");
            modelBuilder.Entity<SigCode>().ToTable("SigCode", "Master");
            modelBuilder.Entity<CommonMaster>().ToTable("CommonMaster", "Master");
            modelBuilder.Entity<Lonic>().ToTable("Lonic", "Master");
            modelBuilder.Entity<EmdeonLab>().ToTable("EmdeonLab", "Master");
            modelBuilder.Entity<Race>().ToTable("Race", "Master");
            modelBuilder.Entity<RegionalLanguage>().ToTable("RegionalLanguage", "Master");
            modelBuilder.Entity<Ethnicity>().ToTable("Ethnicity", "Master");


            modelBuilder.Entity<InsuranceFeeSchedule>().ToTable("InsuranceFeeSchedule", "Tenant2");
            modelBuilder.Entity<PatientRelation>().ToTable("PatientRelation", "Tenant2");
            modelBuilder.Entity<Provider>().ToTable("Provider", "Tenant2");
            modelBuilder.Entity<ProviderLocation>().ToTable("ProviderLocation", "Tenant2");
            modelBuilder.Entity<SchedulerSetup>().ToTable("SchedulerSetup", "Tenant2");
            modelBuilder.Entity<ProviderVacation>().ToTable("ProviderVacation", "Tenant2");
            modelBuilder.Entity<ProviderStateLicense>().ToTable("ProviderStateLicense", "Tenant2");
            modelBuilder.Entity<ProviderInsurance>().ToTable("ProviderInsurance", "Tenant2");
            modelBuilder.Entity<ProviderAwardsAndRecognition>().ToTable("ProviderAwardsAndRecognition","Tenant2");
            modelBuilder.Entity<Patient>().ToTable("Patient", "Tenant2");
            modelBuilder.Entity<PatientAppointment>().ToTable("PatientAppointment", "Tenant2");
            modelBuilder.Entity<PatientAppointmentHistory>().ToTable("PatientAppointmentHistory", "Tenant2");
            modelBuilder.Entity<TreatmentCode>().ToTable("TreatmentCode", "Tenant2");
            modelBuilder.Entity<VisitType>().ToTable("VisitType", "Tenant2");           
            modelBuilder.Entity<Facility>().ToTable("Facility", "Tenant2");
            modelBuilder.Entity<FacilityDiagnosisCode>().ToTable("FacilityDiagnosisCode", "Tenant2");
            modelBuilder.Entity<FacilityTreatmentCode>().ToTable("FacilityTreatmentCode", "Tenant2");
            modelBuilder.Entity<PatientVisit>().ToTable("PatientVisit", "Tenant2");
            modelBuilder.Entity<PatientClinicalNotes>().ToTable("PatientClinicalNotes", "Tenant2");
            modelBuilder.Entity<ProviderLocationTiming>().ToTable("ProviderLocationTiming", "Tenant2");

            /// Patient Services Entity
            modelBuilder.Entity<InsuranceCompany>().ToTable("InsuranceCompany", "Tenant2");
            modelBuilder.Entity<VitalSign>().ToTable("VitalSign", "Tenant2");
            modelBuilder.Entity<PatientMedication>().ToTable("PatientMedication", "Tenant2");
            modelBuilder.Entity<PatientAllergy>().ToTable("PatientAllergy", "Tenant2");
            modelBuilder.Entity<PatientWorkHistory>().ToTable("PatientWorkHistory", "Tenant2");
            modelBuilder.Entity<FamilyHealthHistory>().ToTable("FamilyHealthHistory", "Tenant2");
            modelBuilder.Entity<PatientImmunization>().ToTable("PatientImmunization", "Tenant2");
            modelBuilder.Entity<PatientDiagnosticList>().ToTable("PatientDiagnosticList", "Tenant2");
            modelBuilder.Entity<PatientInsurance>().ToTable("PatientInsurance", "Tenant2");
            modelBuilder.Entity<PatientLabOrderTest>().ToTable("PatientLabOrderTest", "Tenant2");
            modelBuilder.Entity<PatientTobaccoAlcoholHistory>().ToTable("PatientTobaccoAlcoholHistory", "Tenant2");
            modelBuilder.Entity<PatientFamily>().ToTable("PatientFamily", "Tenant2");
            modelBuilder.Entity<PatientFamilyAddress>().ToTable("PatientFamilyAddress", "Tenant2");
            modelBuilder.Entity<LabResponseHL7>().ToTable("LabResponseHL7", "Tenant2");
            modelBuilder.Entity<PhysicalExam>().ToTable("PhysicalExam", "Tenant2");

            //EPrescription Services Entity 
            modelBuilder.Entity<Pharmacy>().ToTable("Pharmacy", "Master");
            modelBuilder.Entity<RxImportHistory>().ToTable("RxImportHistory", "Tenant2");
            modelBuilder.Entity<EPrescription>().ToTable("EPrescription", "Tenant2");
            modelBuilder.Entity<EPrescriptionDetail>().ToTable("EPrescriptionDetail", "Tenant2");
            modelBuilder.Entity<PrescriptionStatus>().ToTable("PrescriptionStatus", "Tenant2");


            //Elab Services Entity
            modelBuilder.Entity<LabRequest>().ToTable("LabRequest", "Tenant2");
            modelBuilder.Entity<LabResponseHL7>().ToTable("LabResponseHL7", "Tenant2");
            modelBuilder.Entity<LabRxAuditReport>().ToTable("LabRxAuditReport", "Tenant2");
            modelBuilder.Entity<EmdeonUserSetup>().ToTable("EmdeonUserSetup" , "Tenant6");



        }
    }
}