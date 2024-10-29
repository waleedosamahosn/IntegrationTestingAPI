using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ModelDb
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BaseUrl { get; set; }
        public ICollection<ProjectAction> projectActions {  get; set; }
    }
}
