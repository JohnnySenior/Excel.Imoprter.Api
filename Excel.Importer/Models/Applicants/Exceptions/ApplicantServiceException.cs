//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class ApplicantServiceException : Xeption
    {
        public ApplicantServiceException(Xeption innerException)
            : base(message: "Appplicant service error occurred, contact support",
                  innerException)
        { }
    }
}
