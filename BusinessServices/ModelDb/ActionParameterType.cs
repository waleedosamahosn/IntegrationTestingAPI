﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ModelDb
{
    public class ActionParameterType
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public ICollection<ProjectActionParameter> ProjectActionParameters { get; set; }


    }
}
