using Xeptions;

namespace Excel.Importer.Models.Applicants.Exceptions
{
    public class ApplicantProcessingValidationException : Xeption
    {
        public ApplicantProcessingValidationException(Xeption innerException)
            : base(message: "Applicant processing validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
