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
            Department d1 = new Department(0, "Electronics");
            Department d2 = new Department(1, "Computers");

            Seller s1 = new Seller(0, "Bob Brown", "bobbrown@gmail.com", new DateTime(1992, 07, 19), 2000.00, d1);
            Seller s2 = new Seller(1, "John Blue", "johnblue@gmail.com", new DateTime(1995, 04, 26), 2000.00, d2);

            SalesRecord sr1 = new SalesRecord(0, new DateTime(2005, 03, 07), 567.20, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(1, new DateTime(2005, 03, 15), 1000.00, SaleStatus.Billed, s1);
            SalesRecord sr3 = new SalesRecord(2, new DateTime(2007, 08, 20), 3999.99, SaleStatus.Billed, s2);
            SalesRecord sr4 = new SalesRecord(3, new DateTime(2007, 08, 25), 1999.99, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2);
            _context.Seller.AddRange(s1, s2);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4);

            _context.SaveChanges();
        }

    }
}