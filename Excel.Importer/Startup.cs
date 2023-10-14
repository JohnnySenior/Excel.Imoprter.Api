//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.DateTimes;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Spreadsheets;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Services.Foundations.Applicants;
using Excel.Importer.Services.Foundations.Groups;
using Excel.Importer.Services.Foundations.Spreadsheets;
using Excel.Importer.Services.Orchestrations;
using Excel.Importer.Services.Processings.Applicants;
using Excel.Importer.Services.Processings.Groups;
using Excel.Importer.Services.Processings.Spredsheets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Excel.Importer
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ISpreadsheetService, SpreadsheetService>();
            services.AddTransient<IOrchestrationService, OrchestrationService>();
            services.AddTransient<IApplicantProcessingService, ApplicantProcessingService>();
            services.AddTransient<IGroupProcessingService, GroupProcessingService>();
            services.AddTransient<ISpreadsheetsProcessingService, SpreadsheetsProcessingService>();

            var openApiInfo = new OpenApiInfo
            {
                Title = "Excel.Importer",
                Version = "v1"
            };

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(
                    name: "v1",
                    info: openApiInfo);
            });
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(config =>
                    config.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "Excel.Importer v1"));
            }

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
