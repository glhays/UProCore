﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UPro.Core.Api.Models.Settings;

namespace UPro.Core.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            //Database.Migrate();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            string connectionString =
                this.configuration.GetConnectionString(name: "UProDbConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyProfile>().ToTable("CompanyProfiles", "Settings");
            modelBuilder.Entity<CompanyProfileDefault>().ToTable("CompanyProfileDefaults", "Settings");

            AddSettingsCompanyProfileConfigurations(modelBuilder.Entity<CompanyProfile>());
            AddSettingsCompanyProfileDefaultConfigurations(modelBuilder.Entity<CompanyProfileDefault>());
        }

        private async ValueTask<T> InsertAsync<T>(T entity)
        {
            var broker = new StorageBroker(this.configuration);
            broker.Entry(entity).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return entity;
        }

        private IQueryable<T> SelectAll<T>() where T : class => this.Set<T>();

        private async ValueTask<T> SelectAsync<T>(params object[] @objectIds)
            where T : class => await this.FindAsync<T>(objectIds);

        private async ValueTask<T> UpdateAsync<T>(T @object)
        {
            this.Entry(@object).State = EntityState.Modified;
            await this.SaveChangesAsync();
            DetachSavedEntity(@object);

            return @object;
        }

        private async ValueTask<T> DeleteAsync<T>(T @object)
        {
            this.Entry(@object).State = EntityState.Deleted;
            await this.SaveChangesAsync();

            return @object;
        }

        private void DetachSavedEntity<T>(T @object)
        {
            this.Entry(@object).State = EntityState.Detached;
        }
    }
}