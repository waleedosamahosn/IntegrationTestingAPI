using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.RepositoryAction
{
    public class ProjectActionParameterOperation<T> : IProjectActionParameterOperation<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public ProjectActionParameterOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProjectActionParameterViewModel model)
        {
            var projects = new ProjectActionParameter
            {
                Value = model.Value,
                ProjectActionId = model.ProjectActionId,
                ActionParameterTypeId = model.ActionParameterTypeId
                
            };

            await _context.ProjectActionParameters.AddAsync(projects);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var project = await _context.ProjectActionParameters.FindAsync(id);

            _context.ProjectActionParameters.Remove(project);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllData()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<ProjectActionParameterViewModel> GetDataUpdate(int id)
        {
            var project = await _context.ProjectActionParameters.FindAsync(id);

            if (project == null)
            {
                return null;
            }

            var projects = new ProjectActionParameterViewModel
            {
                Id = project.Id,
                ProjectActionId= project.ProjectActionId,
                ActionParameterTypeId = project.ActionParameterTypeId,
                Value = project.Value
            };
            return projects;
        }

        public async Task<IEnumerable<ProjectActionParameter>> SelectById(int projectactionParamId)
        {
            return await _context.
                ProjectActionParameters.
                Where(x => x.ProjectActionId == projectactionParamId).
                ToListAsync();
        }

        public async Task Update(ProjectActionParameterViewModel model)
        {
            var project = await _context.ProjectActionParameters.FindAsync(model.Id);

            project.Value = model.Value;
            project.ActionParameterTypeId = model.ActionParameterTypeId;
            project.ProjectActionId = model.ProjectActionId;

            _context.SaveChanges();
        }
    }
}
