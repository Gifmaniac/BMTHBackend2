using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public abstract class IntegrationTestBase : IDisposable
{
    protected readonly StoreDbContext _context;

    public void Dispose()
    {
        _context.Dispose();
    }
}