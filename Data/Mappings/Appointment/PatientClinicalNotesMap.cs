using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class PatientClinicalNotesMap : EntityTypeConfiguration<PatientClinicalNotes>
    {

        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public PatientClinicalNotesMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientClinicalNotesMap()
        {

        }

        public void Configure(EntityTypeBuilder<PatientClinicalNotes> builder)
        {
            builder.ToTable("PatientClinicalNotes", "Tenant2");
            builder.HasKey(x => x.PatientClinicalNotesID);
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.PatientAppointmentID).HasColumnName("PatientAppointmentID");
            builder.Property(x => x.PatientVisitID).HasColumnName("PatientVisitID");
            builder.Property(x => x.AssessmentNotes).HasColumnName("AssessmentNotes").HasMaxLength(2000);
            builder.Property(x => x.ProcedureNotes).HasColumnName("ProcedureNotes").HasMaxLength(2000);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
            builder.Property(x => x.AssessmentSnomedCT).HasColumnName("AssessmentSnomedCT").HasMaxLength(500);
            builder.Property(x => x.ProcedureSnomedCT).HasColumnName("ProcedureSnomedCT").HasMaxLength(500);
            builder.Property(x => x.SubstanceSnomedCT).HasColumnName("SubstanceSnomedCT").HasMaxLength(100);
            builder.Property(x => x.SubstanceDescription).HasColumnName("SubstanceDescription").HasMaxLength(2000);



        }

          
    }
}
