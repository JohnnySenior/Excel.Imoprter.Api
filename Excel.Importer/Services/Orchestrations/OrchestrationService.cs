//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Services.Processings.Spredsheets;

namespace Excel.Importer.Services.Orchestrations
{
    public partial class OrchestrationService : IOrchestrationService
    {
        private readonly ISpreadsheetsProcessingService spreadsheetProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public OrchestrationService(
            ISpreadsheetsProcessingService spreadsheetProcessingService,
            ILoggingBroker loggingBroker)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
            this.loggingBroker = loggingBroker;
        }

        public Task ProcessImportRequest(string filePath) =>
         TryCatch(async () =>
        {
            List<ExternalApplicant> validExternalApplicants =
                this.spreadsheetProcessingService.ReadExternalApplicants(filePath);

            foreach (var externalApplicant in validExternalApplicants)
            {
                var ensureGroup =
                    await groupProcessingService
                    .EnsureGroupExistsByName(externalApplicant.GroupName);

                var applicant = MapToApplicant(externalApplicant, ensureGroup);

                await applicantProcessingService.AddApplicantAsync(applicant);
            }
        });

        private Applicant MapToApplicant(ExternalApplicant externalApplicant, Group ensureGroup)
        {
            return new Applicant
            {
                ApplicantId = Guid.NewGuid(),
                FirstName = externalApplicant.FirstName,
                LastName = externalApplicant.LastName,
                BirthDate = externalApplicant.BirthDate,
                Email = externalApplicant.Email,
                PhoneNumber = externalApplicant.PhoneNumber,
                GroupId = ensureGroup.GroupId,
                GroupName = ensureGroup.GroupName
            };
        }
    }
}
