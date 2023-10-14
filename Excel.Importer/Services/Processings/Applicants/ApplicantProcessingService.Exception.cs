//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Applicants;
using Excel.Importer.Models.Applicants.Exceptions;
using System.Threading.Tasks;
using Xeptions;

namespace Excel.Importer.Services.Processings.Applicants
{
    public partial class ApplicantProcessingService
    {
        private delegate ValueTask<Applicant> ReturningApplicantsFunction();

        private ValueTask<Applicant> TryCatch(ReturningApplicantsFunction returningExternalApplicantsFunction)
        {
            try
            {
                return returningExternalApplicantsFunction();
            }
            catch (NullApplicantException nullApplicantExeption)
            {
                throw CreateAndLogValidationException(nullApplicantExeption);
            }
            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
        }

        private ApplicantProcessingValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantProcessingValidationException =
                new ApplicantProcessingValidationException(exception);

            this.loggingBroker.LogError(applicantProcessingValidationException);

            return applicantProcessingValidationException;
        }
    }
}

