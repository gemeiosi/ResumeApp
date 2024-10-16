using Microsoft.EntityFrameworkCore;
using ResumeApp.Data.Interfaces;
using ResumeApp.Data.Models;
using System.Linq;

namespace ResumeApp.Data.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly AppDBContext _context;

        public CandidateService(AppDBContext context)
        {
            _context = context;
        }
        public void AddCandidate(Candidate newCandidate)
        {
            Console.WriteLine(newCandidate.Id);
            _context.candidate.Add(newCandidate);
            _context.Entry(newCandidate).State = EntityState.Added;
            _context.SaveChangesAsync();
        }

        public void DeleteCandidate(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            var results = new List<Candidate>();
            return await _context.candidate.ToListAsync();
        }

        public Candidate GetCandidateById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCandidate(int id, Candidate newCandidate)
        {
            throw new System.NotImplementedException();
        }
    }
}
