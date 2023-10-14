//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Groups;
using Excel.Importer.Models.Groups.Exceptions;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xeptions;

namespace Excel.Importer.Services.Foundations.Groups
{
    public partial class GroupService
    {
        private delegate ValueTask<Group> ReturningApplicantFunction();

        private async ValueTask<Group> TryCatch(ReturningApplicantFunction returningApplicantFunction)
        {
            try
            {
                return await returningApplicantFunction();
            }
            catch (SqlException sqlException)
            {
                var failedGroupStorageException = new FailedGroupStorageException(sqlException);

                throw CreateAndLogDependencyException(failedGroupStorageException);
            }
        }

        private Exception CreateAndLogDependencyException(Xeption exception)
        {
            var groupDependencyException = new GroupDependencyException(exception);
            this.loggingBroker.LogCritical(groupDependencyException);

            return groupDependencyException;
        }
    }
}
