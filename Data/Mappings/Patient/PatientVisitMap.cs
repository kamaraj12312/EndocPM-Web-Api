using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{ 
    public class PatientVisitMap : EntityTypeConfiguration<PatientVisit>
    {
        public PatientVisitMap()
        {
            // Primary Key
            this.HasKey(t => t.PatientVisitID);

            // Properties
            this.Property(t => t.VisitNumber)
                .HasMaxLength(20);

            this.Property(t => t.VisitTime)
                .HasMaxLength(20);

            this.Property(t => t.ReferringProvider)
                .HasMaxLength(100);

            this.Property(t => t.ChiefComplaint)
                .HasMaxLength(1000);

            this.Property(t => t.InitialICDCode1)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode2)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode3)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode4)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode5)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode6)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode7)
               .HasMaxLength(10);
            this.Property(t => t.InitialICDCode8)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode9)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode10)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode11)
                .HasMaxLength(10);
            this.Property(t => t.InitialICDCode12)
                .HasMaxLength(10);


            this.Property(t => t.Notes)
                .HasMaxLength(2000);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(20);
            this.Property(t => t.ProcedureCode)
             .HasMaxLength(100);
            this.Property(t => t.ProviderToProviderCommunicationCode)
             .HasMaxLength(100);
            this.Property(t => t.ProviderToProviderRefusalReasonCode)
             .HasMaxLength(100);
            this.Property(t => t.PatientToProviderCommunicationCode)
             .HasMaxLength(100);
            this.Property(t => t.PatientToProviderRefusalReasonCode)
             .HasMaxLength(100);
            this.Property(t => t.ProviderToPatientCommunicationCode)
             .HasMaxLength(100);
            this.Property(t => t.ProviderToPatientRefusalReasonCode)
             .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PatientVisit");
            this.Property(t => t.PatientVisitID).HasColumnName("PatientVisitID");
            this.Property(t => t.PatientID).HasColumnName("PatientID");
            this.Property(t => t.ReferringProviderID).HasColumnName("ReferringProviderID");
            this.Property(t => t.FacilityID).HasColumnName("FacilityID");
            this.Property(t => t.PatientAppointmentID).HasColumnName("PatientAppointmentID");
            this.Property(t => t.VisitNumber).HasColumnName("VisitNumber");
            this.Property(t => t.VisitDate).HasColumnName("VisitDate");
            this.Property(t => t.VisitTime).HasColumnName("VisitTime");
            this.Property(t => t.VisitCategoryID).HasColumnName("VisitCategoryID");
            this.Property(t => t.ReferringProvider).HasColumnName("ReferringProvider");
            this.Property(t => t.ConsultingProviderID).HasColumnName("ConsultingProviderID");
            this.Property(t => t.ChiefComplaint).HasColumnName("ChiefComplaint");
            this.Property(t => t.InitialICDCode1).HasColumnName("InitialICDCode1");
            this.Property(t => t.InitialICDCode2).HasColumnName("InitialICDCode2");
            this.Property(t => t.InitialICDCode3).HasColumnName("InitialICDCode3");
            this.Property(t => t.InitialICDCode4).HasColumnName("InitialICDCode4");
            this.Property(t => t.InitialICDCode5).HasColumnName("InitialICDCode5");
            this.Property(t => t.InitialICDCode6).HasColumnName("InitialICDCode6");
            this.Property(t => t.InitialICDCode7).HasColumnName("InitialICDCode7");
            this.Property(t => t.InitialICDCode8).HasColumnName("InitialICDCode8");
            this.Property(t => t.InitialICDCode9).HasColumnName("InitialICDCode9");
            this.Property(t => t.InitialICDCode10).HasColumnName("InitialICDCode10");
            this.Property(t => t.InitialICDCode11).HasColumnName("InitialICDCode11");
            this.Property(t => t.InitialICDCode12).HasColumnName("InitialICDCode12");

            this.Property(t => t.VisitTypeID).HasColumnName("VisitTypeID");
            this.Property(t => t.PhysicalExamSnomedCTID1).HasColumnName("PhysicalExamSnomedCTID1");
            this.Property(t => t.PhysicalExamSnomedCTID2).HasColumnName("PhysicalExamSnomedCTID2");
            this.Property(t => t.PhysicalExamSnomedCTID3).HasColumnName("PhysicalExamSnomedCTID3");
            this.Property(t => t.PhysicalExamSnomedCTID4).HasColumnName("PhysicalExamSnomedCTID4");
            this.Property(t => t.PhysicalExamSnomedCTID5).HasColumnName("PhysicalExamSnomedCTID5");
            this.Property(t => t.PhysicalExamSnomedCTID6).HasColumnName("PhysicalExamSnomedCTID6");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ProcedureCode).HasColumnName("ProcedureCode");
            this.Property(t => t.DischargeDate).HasColumnName("DischargeDate");
            this.Property(t => t.PatientAdmissionID).HasColumnName("PatientAdmissionID");
            this.Property(t => t.ProviderToProviderCommunicationCode).HasColumnName("ProviderToProviderCommunicationCode");
            this.Property(t => t.ProviderToProviderRefusalReasonCode).HasColumnName("ProviderToProviderRefusalReasonCode");
            this.Property(t => t.PatientToProviderCommunicationCode).HasColumnName("PatientToProviderCommunicationCode");
            this.Property(t => t.PatientToProviderRefusalReasonCode).HasColumnName("PatientToProviderRefusalReasonCode");
            this.Property(t => t.ProviderToPatientCommunicationCode).HasColumnName("ProviderToPatientCommunicationCode");
            this.Property(t => t.ProviderToPatientRefusalReasonCode).HasColumnName("ProviderToPatientRefusalReasonCode");
            this.Property(t => t.CommunicationDate).HasColumnName("CommunicationDate");

            //// Relationships
            //this.HasRequired(t => t.Patient)
            //    .WithMany(t => t.PatientWorkHistories)
            //    .HasForeignKey(d => d.PatientID);

        }
    }
}