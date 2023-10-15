//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class FailedApplicantStorageException : Xeption
    {
        public FailedApplicantStorageException(Exception innerException)
            : base(message: "Failed applicant storage error occurred, contact support",
                  innerException)
        { }
    }
}
