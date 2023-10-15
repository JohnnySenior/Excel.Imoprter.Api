//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Models.ExternalApplicants;
using Excel.Importer.Models.ExternalApplicants.Exceptions;
using Excel.Importer.Models.Spreadsheets.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Processings.Spredsheets
{
    public partial class SpreadsheetsProcessingService
    {
        private delegate List<ExternalApplicant> ReturningExternalApplicantsFunction();

        private List<ExternalApplicant> TryCatch(ReturningExternalApplicantsFunction returningExternalApplicantsFunction)
        {
            try
            {
                return returningExternalApplicantsFunction();
            }
            catch (ExternalApplicantValidationException externalApplicantValidationException)
            {
                throw CreateAndLogValidationException(externalApplicantValidationException.InnerException as Xeption);
            }
            catch (EmptySpreadsheetException emptySpreadsheetException)
            {
                throw CreateAndLogValidationException(emptySpreadsheetException);
            }
        }

        private ExternalApplicantsProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var externalApplicantsProcessingValidationException =
                new ExternalApplicantsProcessingValidationException(exception);

            this.loggingBroker.LogError(externalApplicantsProcessingValidationException);

            return externalApplicantsProcessingValidationException;
        }
    }
}
