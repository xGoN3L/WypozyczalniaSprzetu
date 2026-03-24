using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Models.Users;

namespace WypozyczalniaSprzetu.Services
{
    public class UserService
    {
        private readonly InMemoryStore _store;
        public UserService(InMemoryStore store)
        {
            _store = store;
        }
        public void AddUser(User user)
        {
            _store.Users.Add(user);
        }
    }
}
