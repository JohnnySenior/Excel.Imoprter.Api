//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class InvalidApplicantException : Xeption
    {
        public InvalidApplicantException()
            : base(message: "Applicant is invalid.")
        { }
    }
}
