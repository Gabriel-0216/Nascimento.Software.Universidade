using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Domain.Models.University.CollegeYear
{
    public class TermTime
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Year_Semester { get; set; }
        
    }
}
