using AutoMapper;
using Nascimento.Software.Universidade.Api.DTO;
using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;

namespace Nascimento.Software.Universidade.Api.Helpers
{
    public class UniversidadeProfile : Profile
    {
        public UniversidadeProfile()
        {
            CreateMap<StudentCourse, AcademicRegisterDTO>().ReverseMap();
        }
    }
}
