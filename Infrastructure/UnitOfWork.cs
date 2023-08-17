using DataAccess.Data;
using DataAccess.Models;
using Infrastructure.Interfaces;
namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;  //dependency injection of Data Source

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IGenericRepository<ApplicationUser> _ApplicationUser;
        private IGenericRepository<BougthItem> _BougthItem;
        private IGenericRepository<Category> _Category;
        private IGenericRepository<Favourite> _Favourite;
        private IGenericRepository<Product> _Product;
        private IGenericRepository<Review> _Review;
        private IGenericRepository<ShoppingCart> _ShoppingCart;

        public IGenericRepository<ApplicationUser> ApplicationUser
        {
            get
            {
                if (_ApplicationUser == null)
                {
                    _ApplicationUser = new GenericRepository<ApplicationUser>(_dbContext);
                }
                return _ApplicationUser;
            }
        }

        public IGenericRepository<BougthItem> BougthItem
        {
            get
            {
                if (_BougthItem == null)
                {
                    _BougthItem = new GenericRepository<BougthItem>(_dbContext);
                }
                return _BougthItem;
            }
        }

        public IGenericRepository<Category> Category
        {
            get
            {
                if (_Category == null)
                {
                    _Category = new GenericRepository<Category>(_dbContext);
                }
                return _Category;
            }
        }

        public IGenericRepository<Favourite> Favourite
        {
            get
            {
                if (_Favourite == null)
                {
                    _Favourite = new GenericRepository<Favourite>(_dbContext);
                }
                return _Favourite;
            }
        }

        public IGenericRepository<Product> Product
        {
            get
            {
                if (_Product == null)
                {
                    _Product = new GenericRepository<Product>(_dbContext);
                }
                return _Product;
            }
        }

        public IGenericRepository<Review> Review
        {
            get
            {
                if (_Review == null)
                {
                    _Review = new GenericRepository<Review>(_dbContext);
                }
                return _Review;
            }
        }

        public IGenericRepository<ShoppingCart> ShoppingCart
        {
            get
            {
                if (_ShoppingCart == null)
                {
                    _ShoppingCart = new GenericRepository<ShoppingCart>(_dbContext);
                }
                return _ShoppingCart;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
