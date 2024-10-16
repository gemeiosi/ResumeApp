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
        }
        public void AddDegree(Degree newDegree)
        {
            _context.degree.Add(newDegree);
            _context.SaveChangesAsync();
        }

        public void DeleteDegree(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Degree>> GetAllDegrees()
        {
            var results = new List<Degree>();
            return await _context.degree.ToListAsync();
        }

        public Degree GetDegreeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDegree(int id, Degree newDegree)
        {
            throw new System.NotImplementedException();
        }
    }
}
