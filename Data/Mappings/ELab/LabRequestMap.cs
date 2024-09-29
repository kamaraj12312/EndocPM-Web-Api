using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EndocPM.WebAPI
{
    public class LabRequestMap : IEntityTypeConfiguration<LabRequest>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public LabRequestMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public LabRequestMap()
        {

        }

        public void Configure(EntityTypeBuilder<LabRequest> builder)
        {
            builder.ToTable("LabRequest", "Tenant2");
            builder.HasKey(x => x.LabRequestID);

            builder.Property(x => x.LabRequestID).HasColumnName("LabRequestID");
            builder.Property(x => x.PlacerOrderNumber).HasColumnName("PlacerOrderNumber").HasMaxLength(20);
            builder.Property(x => x.OrderNumber).HasColumnName("OrderNumber").HasMaxLength(20);
            builder.Property(x => x.OrderStatus).HasColumnName("OrderStatus").HasMaxLength(5);
            builder.Property(x => x.OrderType).HasColumnName("OrderType").HasMaxLength(20);
            builder.Property(x => x.LabID).HasColumnName("LabID").HasMaxLength(20);
            builder.Property(x => x.LabName).HasColumnName("LabName").HasMaxLength(200);
            builder.Property(x => x.RequestDate).HasColumnName("RequestDate");
            builder.Property(x => x.CollectionDate).HasColumnName("CollectionDate");
            builder.Property(x => x.RespondedDate).HasColumnName("RespondedDate");
            builder.Property(x => x.OrderingOrganizationID).HasColumnName("OrderingOrganizationID").HasMaxLength(20);
            builder.Property(x => x.OrderedUser).HasColumnName("OrderedUser").HasMaxLength(50);
            builder.Property(x => x.ProviderID).HasColumnName("ProviderID");
            builder.Property(x => x.ReferringCareGiver).HasColumnName("ReferringCareGiver").HasMaxLength(20);
            builder.Property(x => x.ReferringCareGiverUPIN).HasColumnName("ReferringCareGiverUPIN").HasMaxLength(20);
            builder.Property(x => x.ReferringCareGiverNameLast).HasColumnName("ReferringCareGiverNameLast").HasMaxLength(50);
            builder.Property(x => x.ReferringCareGiverNameFirst).HasColumnName("ReferringCareGiverNameFirst").HasMaxLength(50);
            builder.Property(x => x.ReferringCareGiverID).HasColumnName("ReferringCareGiverID").HasMaxLength(20);
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.PersonHSI).HasColumnName("PersonHSI").HasMaxLength(20);
            builder.Property(x => x.PersonID).HasColumnName("PersonID").HasMaxLength(20);
            builder.Property(x => x.PatientNameLast).HasColumnName("PatientNameLast").HasMaxLength(50);
            builder.Property(x => x.PatientNameFirst).HasColumnName("PatientNameFirst").HasMaxLength(50);
            builder.Property(x => x.PatientNameMiddle).HasColumnName("PatientNameMiddle").HasMaxLength(50);
            builder.Property(x => x.IsResponseDownloaded).HasColumnName("IsResponseDownloaded");
            builder.Property(x => x.IsResponseImportedIntoSystem).HasColumnName("IsResponseImportedIntoSystem");
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
            builder.Property(x => x.PatientVisitID).HasColumnName("PatientVisitID");
            builder.Property(x => x.UniversalServiceIdentifier).HasColumnName("UniversalServiceIdentifier").HasMaxLength(200);
            builder.Property(x => x.UniversalServiceIdentifierText).HasColumnName("UniversalServiceIdentifierText").HasMaxLength(2000);


        }
    }
}
