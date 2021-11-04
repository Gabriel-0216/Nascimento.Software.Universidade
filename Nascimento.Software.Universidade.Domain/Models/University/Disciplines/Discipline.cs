﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Domain.Models.University.Disciplines
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollegeYearId { get; set; }
        public CollegeYear.TermTime CollegeYear { get; set; }

    }
}