using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.SalesRecord.Any() || _context.Seller.Any())
            {
                return;
            }
            Department d2 = new Department(1, "Computers");

            Seller s1 = new Seller(2, "Bob Brown", "bob@gmail.com", new DateTime(1997, 09, 5), 2000.00, d2);
            Seller s2 = new Seller(1, "John Blue", "john@gmail.com", new DateTime(1995, 04, 26), 2000.00, d2);

            SalesRecord sr1 = new SalesRecord(0, new DateTime(2005, 03, 07), 567.20, SaleStatus.Billed, s2);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2005, 03, 26), 1500.00, SaleStatus.Billed, s1);


            _context.Department.Add(d2);
            _context.Seller.AddRange(s1, s2);
            _context.SalesRecord.AddRange(sr1, sr2);

            _context.SaveChanges();
        }

    }
}