using BusinessServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.InterfacesViewModel
{
    public interface IActionParameterType<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllTypeAsyncData();
        public Task Create(ActionParameterTypeViewModel model);
        public Task<ActionParameterTypeViewModel> GetDataEditActionParamatertype(int? id);
        public Task Update(ActionParameterTypeViewModel model);
        public Task Delete(int? id);

    }
}
