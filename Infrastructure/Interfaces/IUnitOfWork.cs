using DataAccess.Models;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<ApplicationUser> ApplicationUser { get; }
        public IGenericRepository<BougthItem> BougthItem { get; }
        public IGenericRepository<Category> Category { get; }
        public IGenericRepository<Favourite> Favourite { get; }
        public IGenericRepository<Product> Product { get; }
        public IGenericRepository<Review> Review { get; }
        public IGenericRepository<ShoppingCart> ShoppingCart { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}