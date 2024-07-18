// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using UPro.Core.Api.Models.Settings;

namespace UPro.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<CompanyProfileDefault> CompanyProfileDefaults { get; set; }
    }
}