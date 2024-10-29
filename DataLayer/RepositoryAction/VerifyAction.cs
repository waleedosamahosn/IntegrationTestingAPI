using BusinessServices.Services.Interfaces;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.RepositoryAction
{
    public class VerifyAction<T> : IVerifyAction<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public VerifyAction(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllProject()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllProjectAction(string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllProjectParemeter()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
