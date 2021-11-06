using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister
{
    public class StudentCourse
    {


        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("StudentId")]
        [JsonIgnore]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        [JsonIgnore]
        public virtual Courses.Course Course { get; set; }
        public DateTime Created_At { get; set; }


    }
}
