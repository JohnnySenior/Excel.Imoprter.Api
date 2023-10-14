﻿//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Applicants;
using Excel.Importer.Models.Applicants.Exceptions;
using System.Threading.Tasks;
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
        }

        private ApplicantValidationException CreateAndLogValidationException(Xeption exception)
        {
            var applicantValidationException =
                new ApplicantValidationException(exception);

            this.loggingBroker.LogError(applicantValidationException);

            return applicantValidationException;
        }
    }
}