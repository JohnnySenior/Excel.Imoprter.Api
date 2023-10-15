//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Spreadsheets;
using Excel.Importer.Models.ExternalApplicants;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public partial class SpreadsheetService : ISpreadsheetService
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetService(
            ISpreadsheetBroker spreadsheetBroker,
            ILoggingBroker loggingBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
            this.loggingBroker = loggingBroker;
        }

        public List<ExternalApplicant> GetExternalApplicants(string filePath) =>
        TryCatch(() =>
        {
            List<ExternalApplicant> externalApplicants =
                this.spreadsheetBroker.ImportApplicants(filePath);

            ValidateExternalApplicantsOnImport(externalApplicants);

            return externalApplicants;
        });
    }
}
