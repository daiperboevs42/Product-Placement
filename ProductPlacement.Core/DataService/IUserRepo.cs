using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPlacement.Core.DataService
{
    public interface IUserRepo
    {
        IEnumerable<User> ReadAllUsers();
    }
}
