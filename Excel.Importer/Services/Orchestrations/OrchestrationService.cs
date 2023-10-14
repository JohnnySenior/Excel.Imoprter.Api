//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.Applicants;
using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Models.Groups;
using Excel.Importer.Services.Processings.Applicants;
using Excel.Importer.Services.Processings.Groups;
using Excel.Importer.Services.Processings.Spredsheets;

namespace Excel.Importer.Services.Orchestrations
{
    public partial class OrchestrationService : IOrchestrationService
    {
        private readonly ISpreadsheetsProcessingService spreadsheetProcessingService;
        private readonly IApplicantProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public OrchestrationService(
            ISpreadsheetsProcessingService spreadsheetProcessingService,
            IApplicantProcessingService applicantProcessingService,
            IGroupProcessingService groupProcessingService,
            ILoggingBroker loggingBroker)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
            this.applicantProcessingService = applicantProcessingService;
            this.groupProcessingService = groupProcessingService;
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
