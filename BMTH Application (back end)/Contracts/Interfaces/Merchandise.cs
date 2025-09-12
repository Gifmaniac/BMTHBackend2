using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    interface Merchandise
    {
        int ID { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
