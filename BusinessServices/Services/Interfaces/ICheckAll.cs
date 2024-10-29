using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services.Interfaces
{
    public interface ICheckAll
    {
        Task<string> GetResult();
    }
}
