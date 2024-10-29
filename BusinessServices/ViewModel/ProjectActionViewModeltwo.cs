using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ViewModel
{
    public class ProjectActionViewModeltwo
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
    }
}
