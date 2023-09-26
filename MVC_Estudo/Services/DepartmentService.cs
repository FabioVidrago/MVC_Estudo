using MVC_Estudo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_Estudo.Services
{
    public class DepartmentService
    {
        private readonly MVC_EstudoContext _context;

        public DepartmentService(MVC_EstudoContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
