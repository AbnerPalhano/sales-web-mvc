using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebContext _context;

        public SellerService(SalesWebContext context)
        {
            _context = context;
        }

        /*public async Task<List<Seller>> FindAllAsync()
        {
            return await Task.Run(() => _context.Seller.ToList());
        }*/

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}