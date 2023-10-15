//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class FailedApplicantServiceException : Xeption
    {
        public FailedApplicantServiceException(Exception innerException)
            : base(message: "Failed applicant service error occurred, contact support",
                  innerException)
        { }
    }
}
