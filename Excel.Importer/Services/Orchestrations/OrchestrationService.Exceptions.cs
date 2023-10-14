//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Orchestrations.Exceptions;
using Excel.Importer.Models.Spreadsheets.Exceptions;
using System.Threading.Tasks;
using Xeptions;

namespace Excel.Importer.Services.Orchestrations
{
    public partial class OrchestrationService
    {
        private delegate Task ReturningTaskFunction();

        private async Task TryCatch(ReturningTaskFunction returningTaskFunction)
        {
            try
            {
                await returningTaskFunction();
            }
            catch (ExternalApplicantsProcessingValidationException externalApplicantsProcessingValidationException)
            {
                throw CreateAndLogValidationException(
                    externalApplicantsProcessingValidationException.InnerException as Xeption);
            }
        }

        private ExternalApplicantsOrchestrationValidationException CreateAndLogValidationException(Xeption exception)
        {
            var externalApplicantsOrchestrationValidationException =
                new ExternalApplicantsOrchestrationValidationException(exception);

            this.loggingBroker.LogError(externalApplicantsOrchestrationValidationException);

            return externalApplicantsOrchestrationValidationException;
        }
    }
}
