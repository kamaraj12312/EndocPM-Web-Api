using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace EndocPM.WebAPI
{
    public class PatientAppointmentHistoryMap : EntityTypeConfiguration<PatientAppointmentHistory>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public PatientAppointmentHistoryMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientAppointmentHistoryMap()
        {

        }


        public void Configure(EntityTypeBuilder<PatientAppointmentHistory> builder)
        {
            builder.ToTable("PatientAppointmentHistory", "Tenant2");
            builder.HasKey(x => x.PatientAppointmentHistoryID);
            builder.Property(x => x.AppointmentStatusCode).HasColumnName("AppointmentStatusCode").HasMaxLength(3);
            builder.Property(x => x.Comments).HasColumnName("Comments").HasMaxLength(1000);
            builder.Property(x => x.ChangedBy).HasColumnName("ChangedBy").HasMaxLength(20);






        }



       
      
    
        
        
    }
}
