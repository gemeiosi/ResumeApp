using ResumeApp.Data.Models;

namespace ResumeApp.Data.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<bool> UpdateCandidate(int id, Candidate candidate);
        Task<bool> DeleteCandidate(int id);
        Task<bool> AddCandidate(Candidate newCandidate);
    }
}
