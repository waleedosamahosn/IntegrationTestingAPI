using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ModelDb
{
    public class ProjectActionParameter
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public int ProjectActionId { get; set; }
        public ProjectAction ProjectAction { get; set; }

        public int ActionParameterTypeId { get; set; }
        public ActionParameterType ActionParameterType { get; set; }

    }
}
