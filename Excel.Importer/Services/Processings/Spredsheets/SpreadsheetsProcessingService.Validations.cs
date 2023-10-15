//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Models.Spreadsheets.Exceptions;

namespace Excel.Importer.Services.Processings.Spredsheets
{
    public partial class SpreadsheetsProcessingService
    {
        private static void ValidateExternalApplicantsExists(List<ExternalApplicant> validExternalApplicants)
        {
            if (validExternalApplicants is null
               || validExternalApplicants.Count is 0)
            {
                throw new EmptySpreadsheetException();
            }
        }
    }
}
