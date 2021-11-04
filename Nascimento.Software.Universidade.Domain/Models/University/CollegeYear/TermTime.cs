using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Domain.Models.University.CollegeYear
{
    public class TermTime
    {
        public TermTime()
        {
            Year_Semester = String.Concat(Convert.ToString(Year), ".", Convert.ToString(Semester));
        }
        public int Id { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Year_Semester { get; set; } 
    }
}
