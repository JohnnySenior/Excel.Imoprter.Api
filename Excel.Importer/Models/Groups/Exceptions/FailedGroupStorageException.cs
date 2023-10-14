//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Models.Groups.Exceptions
{
    public class FailedGroupStorageException : Xeption
    {
        public FailedGroupStorageException(Exception innerException)
           : base(message: "Failed group storage error occurred, contact support.", innerException)
        { }
    }
}
