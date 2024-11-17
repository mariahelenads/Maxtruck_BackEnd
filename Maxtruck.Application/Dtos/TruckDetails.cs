using Maxtruck.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxtruck.Application.Dtos
{
    public class TruckDetails : Truck
    {
        public List<Bridge>? CriticalBridges { get; set; }
    }
}
