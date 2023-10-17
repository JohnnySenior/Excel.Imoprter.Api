//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Models.Applicants;
using Excel.Importer.Models.Applicants.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace Excel.Importer.Unit.Tests.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfInputIsNullAndLogItAsync()
        {
            // given
            Applicant nullApplicant = null;
            var nullApplicantException = new NullApplicantException();
            var expectedApplicantValidationException =
                new ApplicantValidationException(nullApplicantException);

            // when
            ValueTask<Applicant> addApplicantTask = this.applicantService.AddApplicantAsync(nullApplicant);

            ApplicantValidationException actualApplicantValidationException =
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            // then
            actualApplicantValidationException.Should().BeEquivalentTo(expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedApplicantValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertApplicantAsync(It.IsAny<Applicant>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnAddIfApplicantIsInvalidLogItAsync(
            string invalidText)
        {
            // given
            var invalidApplicant = new Applicant
            {
                FirstName = invalidText
            };

            var invalidApplicantException = new InvalidApplicantException();

            invalidApplicantException.AddData(
                key: nameof(Applicant.ApplicantId),
                values: "Id is required");

            invalidApplicantException.AddData(
                key: nameof(Applicant.FirstName),
                values: "Text is required");

            invalidApplicantException.AddData(
                key: nameof(Applicant.LastName),
                values: "Text is required");

            invalidApplicantException.AddData(
                key: nameof(Applicant.Email),
                values: "Text is required");

            invalidApplicantException.AddData(
                key: nameof(Applicant.PhoneNumber),
                values: "Text is required");

            invalidApplicantException.AddData(
                key: nameof(Applicant.BirthDate),
                values: "Date is required");

            var expectedApplicantValidationException =
                new ApplicantValidationException(invalidApplicantException);

            // when
            ValueTask<Applicant> addApplicantTask =
                this.applicantService.AddApplicantAsync(invalidApplicant);

            ApplicantValidationException actualApplicantValidationException =
                await Assert.ThrowsAsync<ApplicantValidationException>(addApplicantTask.AsTask);

            // then
            actualApplicantValidationException.Should()
                .BeEquivalentTo(expectedApplicantValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    actualApplicantValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertApplicantAsync(It.IsAny<Applicant>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
