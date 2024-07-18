// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UPro.Core.Api.Models.Settings;

namespace UPro.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        void AddSettingsCompanyProfileDefaultConfigurations(EntityTypeBuilder<CompanyProfileDefault> builder)
        {
            builder.Property(companyProfileDefault => companyProfileDefault.FirstMonthFiscalYear)
                .HasMaxLength(255);

            builder.Property(companyProfileDefault => companyProfileDefault.EmployerIdentificationNumber)
                .HasMaxLength(255);

            builder.Property(companyProfileDefault => companyProfileDefault.StateTaxID)
                .HasMaxLength(255);

            builder.Property(companyProfileDefault => companyProfileDefault.LastGLType)
                .HasMaxLength(255);

            builder.Property(companyProfileDefault => companyProfileDefault.LastPeriodClosedYear)
                .HasMaxLength(10);

            builder.Property(companyProfileDefault => companyProfileDefault.LastPeriodClosedMonth)
                .HasMaxLength(15);

            builder.Property(companyProfileDefault => companyProfileDefault.InventoryCostingMethod)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.HasOne(companyProfileDefault => companyProfileDefault.CompanyProfile)
                .WithOne(companyProfile => companyProfile.ProfileDefaults)
                .HasForeignKey<CompanyProfileDefault>(
                    companyProfileDefault => companyProfileDefault.CompanyProfileId);
        }
    }
}