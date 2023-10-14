//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class NullApplicantException : Xeption
    {
        public NullApplicantException()
           : base(message: "Applicant is null.")
        { }
    }
}
