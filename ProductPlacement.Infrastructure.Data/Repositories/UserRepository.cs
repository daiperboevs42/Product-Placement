using ProdductPlacement.Core.Entity;
using ProductPlacement.Core.DataService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepo
    {
        private ProductPlacementAppContext _ctx;

        public UserRepository(ProductPlacementAppContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<User> ReadAllUsers()
        {
            return _ctx.Users;
        }
    }
}
