using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.InterfacesViewModel
{
    public interface IProjectOperation<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllProjectAsync();
        public Task CreateProject(ProjectViewModel model);
        public Task<ProjectViewModel> GetDataEditProject(int? id);
        public Task Update(ProjectViewModel model);
        public Task Delete(int? id);
    }
}
