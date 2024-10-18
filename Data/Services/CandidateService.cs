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
        public async Task<bool> AddCandidate(Candidate newCandidate)
        {
            var candidate = await _context.candidate.Where(x => x.Email == newCandidate.Email || x.Mobile == newCandidate.Mobile).FirstOrDefaultAsync();
            if (candidate == null)
            {
                _context.candidate.Add(newCandidate);
            }
            else
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            var candidate = await _context.candidate.FindAsync(id);
            if (candidate == null)
            {
                return false;
            }

            _context.candidate.Remove(candidate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            return await _context.candidate.ToListAsync();
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _context.candidate.FindAsync(id);
        }

        public async Task<bool> UpdateCandidate(int id, Candidate newCandidate)
        {
            _context.Entry(newCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        private bool CandidateExists(int id)
        {
            return _context.candidate.Any(e => e.Id == id);
        }
    }
}
