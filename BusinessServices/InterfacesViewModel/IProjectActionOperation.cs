using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.InterfacesViewModel
{
    public interface IProjectActionOperation<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllProjectActionData();
        public Task Create(ProjectActionViewModeltwo model);
        public Task<ProjectActionViewModeltwo> GetDataEditProjectAction(int? id);
        public Task Update(ProjectActionViewModeltwo model);
        public Task Delete(int? id);
        public Task<IEnumerable<ProjectAction>> GetProjectAcyionId(int proctactionId);
    }
}
