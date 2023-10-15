//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class ApplicantDependencyValidationException : Xeption
    {
        public ApplicantDependencyValidationException(Xeption innerException)
        : base(message: "Applicant dependency validation error occurred. Fix the error and try again. ", innerException)
        { }
    }
}
