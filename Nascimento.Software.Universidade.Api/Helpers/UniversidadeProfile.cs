using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Nascimento.Software.Universidade.Api.DTO;
using Nascimento.Software.Universidade.Api.DTO.Identity;
using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using Nascimento.Software.Universidade.Domain.Models.User;

namespace Nascimento.Software.Universidade.Api.Helpers
{
    public class UniversidadeProfile : Profile
    {
        public UniversidadeProfile()
        {
            CreateMap<StudentCourse, AcademicRegisterDTO>().ReverseMap();
            CreateMap<Course_Disciplines, DisciplineCourseDTO>().ReverseMap();

            CreateMap<UserLogin, LoginDTO>().ReverseMap();
            CreateMap<UserRegistration, UserRegisterDTO>().ReverseMap();
            CreateMap<IdentityUser, UserLogin>().ReverseMap();
            CreateMap<IdentityUser, UserRegistration>().ReverseMap();

        }
    }
}
