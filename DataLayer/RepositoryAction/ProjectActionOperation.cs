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
    public class ProjectActionOperation<T> : IProjectActionOperation<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public ProjectActionOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllProjectActionData()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Delete(int? id)
        {
            var project = await _context.ProjectActions.FindAsync(id);

            _context.ProjectActions.Remove(project);
            _context.SaveChanges();
        }

        public async Task Create(ProjectActionViewModeltwo model)
        {
            var projectaction = new ProjectAction
            {
                Name = model.Name,
                ActionUrl = model.ActionUrl,
                IsAuthorized = model.IsAuthorized,
                isChecked = model.isChecked,
                MethodName = model.MethodName,
                ProjectId = model.ProjectId
            };

            await _context.ProjectActions.AddAsync(projectaction);
            _context.SaveChanges();
        }

        public async Task<ProjectActionViewModeltwo> GetDataEditProjectAction(int? id)
        {
            var projectaction = await _context.ProjectActions.FindAsync(id);

            if (projectaction == null)
            {
                return null;
            }

            var projects = new ProjectActionViewModeltwo
            {
                Id = projectaction.Id,
                Name = projectaction.Name,
                ActionUrl = projectaction.ActionUrl,
                MethodName = projectaction.MethodName,
                ProjectId = projectaction.ProjectId,
                IsAuthorized = projectaction.IsAuthorized,
                isChecked = projectaction.isChecked
            };
            return projects;
        }

        public async Task Update(ProjectActionViewModeltwo model)
        {
            var project = await _context.ProjectActions.FindAsync(model.Id);

            project.Id = model.Id;
            project.Name = model.Name;
            project.MethodName = model.MethodName;
            project.IsAuthorized = model.IsAuthorized;
            project.isChecked = model.isChecked;
            project.ActionUrl = model.ActionUrl;
            project.ProjectId = model.ProjectId;

            _context.SaveChanges();
        }

        public async Task<IEnumerable<ProjectAction>> GetProjectAcyionId(int proctactionId)
        {
            return await _context.ProjectActions.
                Where(x => x.ProjectId == proctactionId).
                ToListAsync();
        }

    }
}
