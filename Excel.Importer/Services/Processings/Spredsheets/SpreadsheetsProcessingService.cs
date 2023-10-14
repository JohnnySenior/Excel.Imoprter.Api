//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Services.Foundations.Spreadsheets;

namespace Excel.Importer.Services.Processings.Spredsheets
{
    public partial class SpreadsheetsProcessingService : ISpreadsheetsProcessingService
    {
        private readonly ISpreadsheetService spreadsheetService;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetsProcessingService(ISpreadsheetService spreadsheetService, ILoggingBroker loggingBroker)
        {
            this.spreadsheetService = spreadsheetService;
            this.loggingBroker = loggingBroker;
        }

        public List<ExternalApplicant> ReadExternalApplicants(string filePath) =>
        TryCatch(() =>
        {
            List<ExternalApplicant> validExternalApplicants =
                this.spreadsheetService.GetExternalApplicants(filePath);

            ValidateExternalApplicantsExists(validExternalApplicants);

            validExternalApplicants.ForEach(externalApplicant =>
            {
                if (string.IsNullOrWhiteSpace(externalApplicant.FirstName)
                    || string.IsNullOrWhiteSpace(externalApplicant.PhoneNumber)
                    || string.IsNullOrWhiteSpace(externalApplicant.Email))
                {
                    validExternalApplicants.Remove(externalApplicant);
                }
            });

            return validExternalApplicants;
        });
    }
}
