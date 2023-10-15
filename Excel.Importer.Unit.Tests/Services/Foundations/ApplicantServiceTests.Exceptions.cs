//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Data.SqlClient;
using System.Threading.Tasks;
using Excel.Importer.Models.Applicants;
using Excel.Importer.Models.Applicants.Exceptions;
using Moq;
using Xunit;

namespace Excel.Importer.Unit.Tests.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccursLogItAsync()
        {
            //given
            Applicant someApplicant = CreateRandomApplicant();

            SqlException sqlException = GetSqlError();
            var failedApplicantStorageException =
                new FailedApplicantStorageException(sqlException);

            var expectedApplicantDependencyException =
                new ApplicantDependencyException(failedApplicantStorageException);

            this.storageBrokerMock.Setup(broker => broker.InsertApplicantAsync(someApplicant))
                .ThrowsAsync(sqlException);

            //when
            ValueTask<Applicant> addApplicantTask =
                this.applicantService.AddApplicantAsync(someApplicant);

            //then
            await Assert.ThrowsAsync<ApplicantDependencyException>(() =>
                addApplicantTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(someApplicant), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedApplicantDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
