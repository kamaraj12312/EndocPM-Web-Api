using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Http;

namespace EndocPM.WebAPI
{
    public class PatientProblemListMap : IEntityTypeConfiguration<PatientProblemList>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public PatientProblemListMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientProblemListMap()
        {

        }

        public void Configure(EntityTypeBuilder<PatientProblemList> builder)
        {
            builder.ToTable("PatientProblemList", "Tenant2");
            builder.HasKey(x => x.PatientProblemListID);

            builder.Property(x => x.PatientProblemListID).HasColumnName("PatientProblemListID");
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.RecordedDate).HasColumnName("RecordedDate");
            builder.Property(x => x.StatusID).HasColumnName("StatusID");
            builder.Property(x => x.IsAdvancedDirective).HasColumnName("IsAdvancedDirective");
            builder.Property(x => x.DiagnosisCode).HasColumnName("DiagnosisCode").HasMaxLength(400);
            builder.Property(x => x.SourceName).HasColumnName("SourceName").HasMaxLength(200);
            builder.Property(x => x.DiagnosedDate).HasColumnName("DiagnosedDate");
            builder.Property(x => x.DocumentTypeID).HasColumnName("DocumentTypeID");
            builder.Property(x => x.ClinicalNotes).HasColumnName("ClinicalNotes").HasMaxLength(2000);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(2000);
            builder.Property(x => x.Notes).HasColumnName("Notes").HasMaxLength(2000);
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
        }
    }
}
