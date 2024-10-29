using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.InterfacesViewModel
{
    public interface IProjectActionParameterOperation<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllData();
        public Task Create(ProjectActionParameterViewModel model);
        public Task<ProjectActionParameterViewModel> GetDataUpdate(int id);
        public Task Update(ProjectActionParameterViewModel model);
        public Task Delete(int id);
        public Task<IEnumerable<ProjectActionParameter>> SelectById(int projectactionParamId);
    }
}
