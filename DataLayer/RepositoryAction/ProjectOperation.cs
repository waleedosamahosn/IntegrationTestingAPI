using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.RepositoryAction
{
    public class ProjectOperation<T> : IProjectOperation<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public ProjectOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProject(ProjectViewModel model)
        {
            Project project = new Project
            {
                Name = model.Name,
                BaseUrl = model.BaseUrl
            };

            await _context.Projects.AddAsync(project);

            _context.SaveChanges();
        }

        public async Task Delete(int? id)
        {
            var project = await _context.Projects.FindAsync(id);

            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllProjectAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<ProjectViewModel> GetDataEditProject(int? id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return null;
            }

            var projects = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                BaseUrl = project.BaseUrl
            };
            return projects;
        }

        public async Task Update(ProjectViewModel model)
        {
            var project = await _context.Projects.FindAsync(model.Id);

            project.Id = model.Id;
            project.Name = model.Name;
            project.BaseUrl = model.BaseUrl;

            _context.SaveChanges();
        }
    }
}
