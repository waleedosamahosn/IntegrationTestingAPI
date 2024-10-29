using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.RepositoryAction
{
    public class ActionParameterType<T> : IActionParameterType<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public ActionParameterType(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllTypeAsyncData()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task Create(ActionParameterTypeViewModel model)
        {
            var actionparametertype = new ActionParameterType
            {
                Id = model.Id,
                Name = model.Name
            };
            await _context.ActionParameterTypes.AddAsync(actionparametertype);
            _context.SaveChanges();
        }

        public async Task<ActionParameterTypeViewModel> GetDataEditActionParamatertype(int? id)
        {
            var actionparametertype = await _context.ActionParameterTypes.FindAsync(id);

            if(actionparametertype == null)
            {
                return null;
            }

            var parametertypes = new ActionParameterTypeViewModel
            {
                Id = actionparametertype.Id,
                Name = actionparametertype.Name
            };

            return parametertypes;
        }

        public async Task Update(ActionParameterTypeViewModel model)
        {
            var paramtype = await _context.ActionParameterTypes.FindAsync(model.Id);

           paramtype.Id = model.Id;
           paramtype.Name = model.Name;

            _context.SaveChanges();

        }

        public async Task Delete(int? id)
        {
            var paramtyp = await _context.ActionParameterTypes.FindAsync(id);

            _context.ActionParameterTypes.Remove(paramtyp);
            _context.SaveChanges();
        }
    }
}
