using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsMediatrExample.DataStore
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        private static List<User> _users;

        public FakeDataStore()
        {
            _products = new List<Product>
            {
                new() {Id = 1, Name = "Test Product 1"},
                new() {Id = 2, Name = "Test Product 2"},
                new() {Id = 3, Name = "Test Product 3"},
                new() {Id = 4, Name = "Test Product 4"},
                new() {Id = 5, Name = "Test Product 5"},
                new() {Id = 6, Name = "Test Product 6"},
                new() {Id = 23, Name = "Test Product 23"}
            };

            _users = new List<User>
            {
                new()
                {
                    Id = 1,
                    FirstName = "D1",
                    LastName = "H1234",
                    List = new List<int>
                    {
                        1, 23, 4, 5, 6
                    },
                    Role = Role.ONE
                },
                new()
                {
                    Id = 2,
                    FirstName = "L",
                    LastName = "S",
                    List = new List<int>
                    {
                        1, 6
                    },
                    Role = Role.TWO
                },
                new()
                {
                    Id = 4,
                    FirstName = "L",
                    LastName = "H",
                    List = new List<int>
                    {
                        2, 5, 6
                    },
                    Role = Role.ADMIN,
                    Email = "test1@test.com"
                },
                new()
                {
                    Id = 10,
                    FirstName = "T",
                    LastName = "K",
                    List = new List<int>
                    {
                        6, 7, 8
                    },
                    Role = Role.USER
                }
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        
        public async Task AddUser(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task<IEnumerable<User>> GetAllUsers() => await Task.FromResult(_users);

        public async Task<Product> GetProductById(int id) =>
            await Task.FromResult(_products.Single(p => p.Id == id));

        public async Task<User> GetUserById(int id) =>
            await Task.FromResult(_users.Single(u => u.Id == id));

        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
        
        public async Task EventOccured(User user, string evt)
        {
            _users.Single(u => u.Id == user.Id).FirstName = $"{user.FirstName} {user.LastName} evt: {evt}";
            await Task.CompletedTask;
        }

        public async Task DeleteUser(int requestUserId)
        {
            var single = _users.Single(u => u.Id == requestUserId);
            _users.Remove(single);
            await Task.CompletedTask;
        }
    }
}