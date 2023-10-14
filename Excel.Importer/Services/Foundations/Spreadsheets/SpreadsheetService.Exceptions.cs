//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Models.ExternalApplicants.Exceptions;
using System.Collections.Generic;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public partial class SpreadsheetService
    {
        private delegate List<ExternalApplicant> ReturningExternalApplicantsFunction();

        private List<ExternalApplicant> TryCatch(ReturningExternalApplicantsFunction returningExternalApplicantsFunction)
        {
            try
            {
                return returningExternalApplicantsFunction();
            }
            catch (NullExternalApplicantException nullExternalApplicantException)
            {
                throw CreateAndLogValidationException(nullExternalApplicantException);
            }
        }

        private ExternalApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var externalApplicantValidationException =
                new ExternalApplicantValidationException(exception);

            this.loggingBroker.LogError(externalApplicantValidationException);

            return externalApplicantValidationException;
        }
    }
}
