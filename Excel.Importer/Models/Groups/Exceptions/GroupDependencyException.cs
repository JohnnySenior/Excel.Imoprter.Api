//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using Xeptions;

namespace Excel.Importer.Models.Groups.Exceptions
{
    public class GroupDependencyException : Xeption
    {
        public GroupDependencyException(Exception innerException)
            : base(message: "Group dependency error occurred, contact support.", innerException)
        { }
    }
}
