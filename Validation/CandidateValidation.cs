using FluentValidation;
using JobCandidate.Models;

namespace JobCandidate.Validation
{
    public class CandidateValidation : AbstractValidator<CandidateModel>
    {
        public CandidateValidation()
        {
            RuleFor(user => user.FirstName)
           .NotEmpty().WithMessage("FirstName is required.");

            RuleFor(user => user.LastName)
           .NotEmpty().WithMessage("LastName is required.");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email is required.")
                 .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Comment)
          .NotEmpty().WithMessage("Comment is required.");

        }
    }
}
