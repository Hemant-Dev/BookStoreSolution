using BookStore.Data;
using BookStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly AppDbContext _db;
        public ApplicationUserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
