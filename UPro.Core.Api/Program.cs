// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UPro.Core.Api.Brokers.DateTimes;
using UPro.Core.Api.Brokers.Loggings;
using UPro.Core.Api.Brokers.Storages;

namespace UPro.Core.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StorageBroker>();

            builder.Services.AddTransient<
                IStorageBroker,
                StorageBroker>();

            builder.Services.AddTransient<
                ILoggingBroker,
                LoggingBroker>();

            builder.Services.AddTransient<
                IDateTimeBroker,
                DateTimeBroker>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}