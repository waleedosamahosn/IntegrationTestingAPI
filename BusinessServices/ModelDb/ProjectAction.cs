using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ModelDb
{
    public class ProjectAction
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string MethodName { get; set; }
        public bool IsAuthorized { get; set; }
        public bool isChecked { get; set; }
        public int ProjectId { get; set; }

        [Required]
        public string ActionUrl { get; set; }
        public Project Project { get; set; }
        public ICollection<ProjectActionParameter> ProjectActionParameters { get; set; }
    }
}
