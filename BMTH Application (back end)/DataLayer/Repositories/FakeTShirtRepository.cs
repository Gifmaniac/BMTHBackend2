using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class FakeTShirtRepository : ITShirtRepository
    {
        private static readonly List<TShirtEntity> _tShirts = new()
        {
            new TShirtEntity { Id = 1, Name = "Limited Edition Tee", Price = 29.99m },
            new TShirtEntity { Id = 2, Name = "Classic Tee", Price = 19.99m }
        };

        public List<TShirtEntity> GetAll() => _tShirts;

    }
}
