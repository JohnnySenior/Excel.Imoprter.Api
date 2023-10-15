//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class ApplicantDependencyException : Xeption
    {
        public ApplicantDependencyException(Xeption innerException)
            : base(message: "Applicant dependency error occurred, contact support",
                  innerException)
        { }
    }
}
