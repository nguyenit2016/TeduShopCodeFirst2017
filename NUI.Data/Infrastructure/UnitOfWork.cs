namespace NUI.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private NuiShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public NuiShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = new NuiShopDbContext()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}