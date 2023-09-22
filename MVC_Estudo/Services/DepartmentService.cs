using MVC_Estudo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Estudo.Services
{
    public class DepartmentService
    {
        private readonly MVC_EstudoContext _context;

        public DepartmentService(MVC_EstudoContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
