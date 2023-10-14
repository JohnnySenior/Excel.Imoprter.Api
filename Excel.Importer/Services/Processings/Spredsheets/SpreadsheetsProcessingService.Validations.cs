//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Models.SpreadsheetProcessings.Exceptions;
using System.Collections.Generic;

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
