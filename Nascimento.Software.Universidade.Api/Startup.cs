using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nascimento.Software.Universidade.Domain.Models.Person.Teacher;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using Nascimento.Software.Universidade.Infra.Repositorys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Application.Services.TeacherServices;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;

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


            services.AddScoped<ICommomService<Student>, StudentService>();
            services.AddScoped<ICommomDAO<Student>, StudentDAO>();

            services.AddScoped<ICommomService<Discipline>, DisciplinesService>();
            services.AddScoped<ICommomDAO<Discipline>, DisciplinesDAO>();

            services.AddScoped<ICommomService<Course>, CoursesService>();
            services.AddScoped<ICommomDAO<Course>, CourseDAO>();

            services.AddScoped<ApplicationDbContext>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}