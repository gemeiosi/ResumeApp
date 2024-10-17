using ResumeApp.Data.Models;

namespace ResumeApp.Data.Interfaces
{
    public interface IDegreeService
    {
        Task<List<Degree>> GetAllDegrees();
        Task<Degree> GetDegreeById(int id);
        Task<bool> UpdateDegree(int id, Degree degree);
        Task<bool> DeleteDegree(int id);
        Task<bool> DeleteAllUnusedDegrees();
        Task<bool> AddDegree(Degree newdegree);
    }
}
