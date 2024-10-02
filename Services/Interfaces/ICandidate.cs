using JobCandidate.Models;

namespace JobCandidate.Services.Interfaces
{
    public interface ICandidate
    {
        Task<CandidateModel> AddUpdateCandidateAsync(CandidateModel model);
    }
}
