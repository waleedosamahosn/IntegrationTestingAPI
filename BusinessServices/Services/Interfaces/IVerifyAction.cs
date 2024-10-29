using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services.Interfaces
{
    public interface IVerifyAction<T> where T : class
    {
        Task<IEnumerable<T>> GetAllProjectAction(string[] includes = null);
        Task<IEnumerable<T>> GetAllProject();
        Task<IEnumerable<T>> GetAllProjectParemeter();
    }
}
