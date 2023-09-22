using MVC_Estudo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Estudo.Services
{
    public class SellerService
    {
        private readonly MVC_EstudoContext _context;

        public SellerService(MVC_EstudoContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
