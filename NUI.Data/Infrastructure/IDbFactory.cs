using System;

namespace NUI.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NuiShopDbContext Init();
    }
}