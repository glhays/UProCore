// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UPro.Core.Api.Models.Settings;

namespace UPro.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        void AddSettingsCompanyProfileConfigurations(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.Property(companyProfile => companyProfile.CompanyName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.FictitiousBusinessName)
                .HasMaxLength(255);

            builder.Property(companyProfile => companyProfile.Address1)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.Address2)
                .HasMaxLength(255);

            builder.Property(companyProfile => companyProfile.Address3)
                .HasMaxLength(255);

            builder.Property(companyProfile => companyProfile.City)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.State)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.PostalCode)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.Country)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.Telephone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(companyProfile => companyProfile.TelephoneAlternate)
                .HasMaxLength(20);

            builder.Property(companyProfile => companyProfile.EmailAddress)
                .HasMaxLength(254);

            builder.Property(companyProfile => companyProfile.CompanyLogo)
                .HasColumnType("varbinary(max)");

            builder.Property(companyProfile => companyProfile.CompanyLogoPath)
                .HasMaxLength(255);

            builder
                .HasOne(companyProfile => companyProfile.ProfileDefaults)
                .WithOne(companyProfileDefault => companyProfileDefault.CompanyProfile)
                .HasForeignKey<CompanyProfileDefault>(companyProfileDefault => companyProfileDefault.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}