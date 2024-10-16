using AutoMapper;
using ResumeApp.Data.Dtos;
using ResumeApp.Data.Models;

namespace ResumeApp.Data.Profiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Degree,DegreeDto>().ReverseMap();
        }
        
    }
}
