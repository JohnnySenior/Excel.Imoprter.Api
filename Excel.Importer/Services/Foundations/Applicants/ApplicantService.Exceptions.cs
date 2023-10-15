//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Excel.Importer.Models.Applicants;
using Excel.Importer.Models.Applicants.Exceptions;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Applicants
{
    public partial class ApplicantService
    {
        private delegate ValueTask<Applicant> ReturningApplicantFunction();

        private async ValueTask<Applicant> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (NullApplicantException nullApplicantExeption)
            {
                throw CreateAndLogValidationException(nullApplicantExeption);
            }
            catch (InvalidApplicantException invalidApplicantException)
            {
                throw CreateAndLogValidationException(invalidApplicantException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsApplicantException =
                    new AlreadyExistsApplicantException(duplicateKeyException);

                throw CreateAndALogDependencyValidationException(alreadyExistsApplicantException);
            }
            catch (SqlException sqlException)
            {
                var failedApplicantStorageException = new FailedApplicantStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedApplicantStorageException);
            }
            catch (Exception exception)
            {
                var failedApplicantServiceException = new FailedApplicantServiceException(exception);

                throw CreateAndLogServiceException(failedApplicantServiceException);
            }
        }

        private ApplicantDependencyValidationException CreateAndALogDependencyValidationException(Xeption exception)
        {
            var applicantDependencyValidationException =
                new ApplicantDependencyValidationException(exception);
            this.loggingBroker.LogError(applicantDependencyValidationException);

            return applicantDependencyValidationException;
        }

        private ApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantValidationException =
                new ApplicantValidationException(exception);
            this.loggingBroker.LogError(applicantValidationException);

            return applicantValidationException;
        }

        private ApplicantDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var applicantDependencyException = new ApplicantDependencyException(exception);
            this.loggingBroker.LogCritical(applicantDependencyException);

            return applicantDependencyException;
        }

        private ApplicantServiceException CreateAndLogServiceException(Xeption exception)
        {
            var applicantServiceException = new ApplicantServiceException(exception);
            this.loggingBroker.LogError(applicantServiceException);

            return applicantServiceException;
        }
    }
}
