using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Infra.Repositories
{
    public class TruckRepository : Repository<Truck>, ITruckRepository
    {
        private readonly AppDbContext _context;

        public TruckRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
