//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Models.ExternalApplicants.Exceptions;
using System.Collections.Generic;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public partial class SpreadsheetService
    {
        private void ValidateExternalApplicantsOnImport(List<ExternalApplicant> externalApplicants)
        {
            ExternalApplicantNotNull(externalApplicants);
        }

        private List<ExternalApplicant> ExternalApplicantNotNull(List<ExternalApplicant> externalApplicants)
        {
            foreach (var applicant in externalApplicants)
            {
                if (applicant is null)
                {
                    externalApplicants.Remove(applicant);
                    throw new NullExternalApplicantException();
                }
            }

            return externalApplicants;
        }
    }
}
