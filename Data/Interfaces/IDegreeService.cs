using ResumeApp.Data.Models;

namespace ResumeApp.Data.Interfaces
{
    public interface IDegreeService
    {
        Task<List<Degree>> GetAllDegrees();
        Degree GetDegreeById(int id);
        void UpdateDegree(int id, Degree degree);
        void DeleteDegree(int id);
        void AddDegree(Degree newdegree);
    }
}
