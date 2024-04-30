﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTask.Models
{
    internal class Employee
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} | Name: {Name} | Surname: {Surname} | Salary: {Salary}";
        }
    }
}
