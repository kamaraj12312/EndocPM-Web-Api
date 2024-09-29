using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNetCore.Http;

namespace EndocPM.WebAPI
{
    public class PatientAppointmentMap : EntityTypeConfiguration<PatientAppointment>
    {
        public readonly IHttpContextAccessor _iHttpContextAccessor;

        public PatientAppointmentMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientAppointmentMap()
        {

        }

        public void Configure(EntityTypeBuilder<PatientAppointment> builder)
        {

            builder.ToTable("PatientAppointment", "Tenant2");
            builder.HasKey(x => x.PatientAppointmentID);
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.FacilityID).HasColumnName("FacilityID");
            builder.Property(x => x.ProviderID).HasColumnName("ProviderID");
            builder.Property(x => x.VisitTypeID).HasColumnName("VisitTypeID");
            builder.Property(x => x.SlotNumber).HasColumnName("SlotNumber");

            builder.Property(x => x.AppointmentStatusCode).HasColumnName("AppointmentStatusCode").HasMaxLength(3);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(x => x.ParentAppointID).HasColumnName("ParentAppointID");
            
            builder.Property(x => x.RecurrenceRule).HasColumnName("RecurrenceRule").HasMaxLength(100);
            builder.Property(x => x.RecurrenceException).HasColumnName("RecurrenceException").HasMaxLength(500);
            builder.Property(x => x.StartTimezone).HasColumnName("StartTimezone").HasMaxLength(50);
            builder.Property(x => x.EndTimezone).HasColumnName("EndTimezone").HasMaxLength(50);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
            builder.Property(x => x.OtherAppointmentType).HasColumnName("OtherAppointmentType").HasMaxLength(500);
            builder.Property(x => x.PatientVisitID).HasColumnName("PatientVisitID");
            builder.Property(x => x.RemindBeforeDays).HasColumnName("RemindBeforeDays");
            builder.Property(x => x.RemindBeforeHours).HasColumnName("RemindBeforeHours");
            builder.Property(x => x.NumberOfMessagesToSendPerPatient).HasColumnName("NumberOfMessagesToSendPerPatient");
            builder.Property(x => x.IntervalPerMessage).HasColumnName("IntervalPerMessage");
            builder.Property(x => x.IntervalBetweenMessagesTypeId).HasColumnName("IntervalBetweenMessagesTypeId");


        }


       



    }
    
}