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
    public class PatientMap : EntityTypeConfiguration<Patient>
    {

        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public PatientMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientMap()
        {

        }

        public void Configure(EntityTypeBuilder<Patient> builder)
        {

            builder.ToTable("Patient", "Tenant2");
            builder.HasKey(x => x.PatientID);
            builder.Property(x => x.PatientSSN).HasColumnName("PatientSSN").HasMaxLength(15);
            builder.Property(x => x.NameLast).HasColumnName("NameLast").HasMaxLength(100);
            builder.Property(x => x.NameFirst).HasColumnName("NameFirst").HasMaxLength(55);
            builder.Property(x => x.NameMiddle).HasColumnName("NameMiddle").HasMaxLength(25);
            builder.Property(x => x.NamePrefix).HasColumnName("NamePrefix").HasMaxLength(25);
            builder.Property(x => x.NameSuffix).HasColumnName("NameSuffix").HasMaxLength(25);
            builder.Property(x => x.GenderID).HasColumnName("GenderID");
            builder.Property(x => x.MaritalStatusID).HasColumnName("MaritalStatusID");
            builder.Property(x => x.RaceID).HasColumnName("RaceID").HasMaxLength(50);




        }
          

        
    }
}
