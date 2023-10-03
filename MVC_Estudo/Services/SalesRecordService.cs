using MVC_Estudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MVC_Estudo.Services
{
    public class SalesRecordService
    {
        private readonly MVC_EstudoContext _context;

        public SalesRecordService(MVC_EstudoContext context)
        {
            _context = context;
        }

        public async Task <List<SalesRecord>> FindBydateAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderBy(x => x.Date).ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>>> FindBydateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderBy(x => x.Date).GroupBy(x=>x.Seller.Department).ToListAsync();
        }
    }
}
