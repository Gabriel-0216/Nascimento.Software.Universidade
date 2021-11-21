using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nascimento.Software.Universidade.Api.Configuration;
using Nascimento.Software.Universidade.Api.Tokens;
using Nascimento.Software.Universidade.Application.Services.AcademicRegistration;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Application.Services.TeacherServices;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.Person.Teacher;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Processment.Classes;
using Nascimento.Software.Universidade.Infra.Processment.Contracts;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using Nascimento.Software.Universidade.Infra.Repositorys.Repository;
using Nascimento.Software.Universidade.Infra.Users;
using NascimentoSoftware.Universidade.Infra.Processment;
using System;
using System.Text;

namespace Nascimento.Software.Universidade.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICommomDAO<Teacher>, TeacherDAO>();
            services.AddScoped<ICommomService<Teacher>, TeacherService>();

            services.AddScoped<TokenGenerator>();

            services.AddScoped<ICommomService<Student>, StudentService>();
            services.AddScoped<ICommomDAO<Student>, StudentDAO>();

            services.AddScoped<ICommomService<Discipline>, DisciplinesService>();
            services.AddScoped<ICommomDAO<Discipline>, DisciplinesDAO>();

            services.AddScoped<ICommomService<Course>, CoursesService>();
            services.AddScoped<ICommomDAO<Course>, CourseDAO>();

            services.AddScoped<IStudentCourseRegister, StudentCourseRegister>();
            services.AddScoped<IAcademicService, AcademicService>();

            services.AddScoped<ICourseDisciplineService, CourseDisciplineService>();
            services.AddScoped<ICourseDiscipline, CourseDisciplineRegister>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ApplicationDbContext>();

            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                };
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(
               x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nascimento.Software.Universidade.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nascimento.Software.Universidade.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
