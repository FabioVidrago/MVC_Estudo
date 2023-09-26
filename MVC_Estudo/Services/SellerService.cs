using Microsoft.EntityFrameworkCore;
using MVC_Estudo.Models;
using MVC_Estudo.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Estudo.Services
{
    public class SellerService
    {
        private readonly MVC_EstudoContext _context;

        public SellerService(MVC_EstudoContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task Insert(Seller obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIDAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            if (!await _context.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
