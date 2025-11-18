
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Context;

public abstract class IntegrationTestBase : IDisposable
{
    protected readonly StoreDbContext _context;

    public void Dispose()
    {
        _context.Dispose();
    }
}