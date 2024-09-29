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
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {

        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public ProviderMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public ProviderMap()
        {

        }

        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Provider", "Tenant2");
            builder.HasKey(x => x.ProviderID);
            builder.Property(x => x.NPI).HasColumnName("NPI").HasMaxLength(15);
            builder.Property(x => x.TaxID).HasColumnName("TaxID").HasMaxLength(20);
            builder.Property(x => x.NameLast).HasColumnName("NameLast").HasMaxLength(100);
            builder.Property(x => x.NameFirst).HasColumnName("NameFirst").HasMaxLength(55);
            builder.Property(x => x.NameMiddle).HasColumnName("NameMiddle").HasMaxLength(15);
            builder.Property(x => x.NamePrefix).HasColumnName("NamePrefix").HasMaxLength(25);
            builder.Property(x => x.NameSuffix).HasColumnName("NameSuffix").HasMaxLength(25);
            builder.Property(x => x.Credential).HasColumnName("Credential").HasMaxLength(50);
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(50);
            builder.Property(x => x.GenderID).HasColumnName("GenderID");
            builder.Property(x => x.MedicareID).HasColumnName("MedicareID").HasMaxLength(20);
            builder.Property(x => x.UPIN).HasColumnName("UPIN").HasMaxLength(20);
            builder.Property(x => x.AddressLine1).HasColumnName("AddressLine1").HasMaxLength(100);
            builder.Property(x => x.AddressLine2).HasColumnName("AddressLine2").HasMaxLength(100);
            builder.Property(x => x.City).HasColumnName("City").HasMaxLength(50);
            builder.Property(x => x.State).HasColumnName("State").HasMaxLength(50);
            builder.Property(x => x.ZIP).HasColumnName("ZIP").HasMaxLength(15);
            builder.Property(x => x.Country).HasColumnName("Country").HasMaxLength(3);
            builder.Property(x => x.Phone).HasColumnName("Country").HasMaxLength(20);
            builder.Property(x => x.AlternatePhone).HasColumnName("Country").HasMaxLength(20);
            builder.Property(x => x.Fax).HasColumnName("Fax").HasMaxLength(20);
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(50);
            builder.Property(x => x.BillingAddressLine1).HasColumnName("BillingAddressLine1").HasMaxLength(100);
            builder.Property(x => x.BillingAddressLine2).HasColumnName("BillingAddressLine2").HasMaxLength(100);
            builder.Property(x => x.BillingCity).HasColumnName("BillingCity").HasMaxLength(50);
            builder.Property(x => x.BillingState).HasColumnName("BillingState").HasMaxLength(50);
            builder.Property(x => x.BillingCounty).HasColumnName("BillingCounty").HasMaxLength(50);
            builder.Property(x => x.BillingZIP).HasColumnName("BillingZIP").HasMaxLength(50);
            builder.Property(x => x.BillingCountry).HasColumnName("BillingCountry").HasMaxLength(50);
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);
            builder.Property(x => x.UserID).HasColumnName("UserID");
            builder.Property(x => x.LanguageID).HasColumnName("LanguageID");
            builder.Property(x => x.PreferredLanguageID).HasColumnName("PreferredLanguageID").HasMaxLength(20);
            builder.Property(x => x.MothersMaidenName).HasColumnName("MothersMaidenName").HasMaxLength(100);
            builder.Property(x => x.MedicaidID).HasColumnName("MedicaidID").HasMaxLength(20);
            builder.Property(x => x.WebsiteName).HasColumnName("WebsiteName").HasMaxLength(200);
            builder.Property(x => x.PrimaryFacilityID).HasColumnName("PrimaryFacilityID");
            builder.Property(x => x.Biography).HasColumnName("Biography").HasMaxLength(500);
            builder.Property(x => x.DoximityURL).HasColumnName("DoximityURL").HasMaxLength(100);
            builder.Property(x => x.LinkedinURL).HasColumnName("LinkedinURL").HasMaxLength(100);
            builder.Property(x => x.TwitterURL).HasColumnName("TwitterURL").HasMaxLength(100);
        }                   
    }
}