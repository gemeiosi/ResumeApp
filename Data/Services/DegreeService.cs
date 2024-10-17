using Microsoft.EntityFrameworkCore;
using ResumeApp.Data.Interfaces;
using ResumeApp.Data.Models;
using System.Linq;

namespace ResumeApp.Data.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly AppDBContext _context;

        public DegreeService(AppDBContext context)
        {
            _context = context;
            OnInit();
        }
        void OnInit()
        {
            if (!_context.degree.Any())
            {
                var degrees = new List<Degree>
                {
                    new Degree { Name = "Bsc" },
                    new Degree { Name = "Msc" },
                    new Degree { Name = "PhD" }

                };
                _context.AddRange(degrees);
                _context.SaveChanges();
            }
        }
        public async Task<bool> AddDegree(Degree newDegree)
        {
            _context.degree.Add(newDegree);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDegree(int id)
        {
            var degree = await _context.degree.FindAsync(id);
            if (degree == null)
            {
                return false;
            }

            _context.degree.Remove(degree);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllUnusedDegrees()
        {
            var candidates = await _context.candidate.Select(x=> x.Degree).ToListAsync();
            var degreesDb = await _context.degree.ToListAsync();
            var degrees = degreesDb.Select(x=>x.Name).Except(candidates).ToList();
            List<Degree> degreesDbTodDelete = new List<Degree>();
            foreach (var degree in degrees)
            {
                degreesDbTodDelete.Add(degreesDb.Where(x => x.Name == degree).FirstOrDefault());
            }
            if (degreesDbTodDelete == null)
            {
                return false;
            }
            _context.degree.RemoveRange(degreesDbTodDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Degree>> GetAllDegrees()
        {
            var results = new List<Degree>();
            return await _context.degree.ToListAsync();
        }

        public async Task<Degree> GetDegreeById(int id)
        {
            return await _context.degree.Where(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDegree(int id, Degree newDegree)
        {

            _context.Entry(newDegree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(id))
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
        private bool DegreeExists(int id)
        {
            return _context.degree.Any(e => e.Id == id);
        }
    }
}
