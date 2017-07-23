namespace NUI.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NuiShopDbContext dbContext;

        public NuiShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NuiShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}