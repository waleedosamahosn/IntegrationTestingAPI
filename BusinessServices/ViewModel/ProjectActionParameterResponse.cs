using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ViewModel
{
    public class ProjectActionParameterResponse
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public int ProjectActionId { get; set; }

        public int ActionParameterTypeId { get; set; }
    }
}
