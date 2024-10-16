using ResumeApp.Data.Models;

namespace ResumeApp.Data.Interfaces
{
    public interface ICandidateService
    {
        Task<List<Candidate>> GetAllCandidates();
        Candidate GetCandidateById(int id);
        void UpdateCandidate(int id, Candidate candidate);
        void DeleteCandidate(int id);
        void AddCandidate(Candidate newCandidate);
    }
}
