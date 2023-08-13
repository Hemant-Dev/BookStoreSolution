using BookStore.Data;
using BookStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext _db;

        public ShoppingCartRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart shoppingCartObj)
        {
            _db.ShoppingCarts.Update(shoppingCartObj);
        }
    }
}
