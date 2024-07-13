// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UPro.Core.Api.Brokers.Storages
{
    internal partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            Database.Migrate();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                this.configuration.GetConnectionString(name: "UProDbConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        private async ValueTask<T> InsertAsync<T>(T entity)
        {
            var broker = new StorageBroker(this.configuration);
            broker.Entry(entity).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return entity;
        }

        private IQueryable<T> SelectAll<T>() where T : class => this.Set<T>();

        private void DetachSavedEntity<T>(T @object)
        {
            this.Entry(@object).State = EntityState.Detached;
        }
    }
}