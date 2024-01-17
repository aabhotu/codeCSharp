using Microsoft.EntityFrameworkCore;
using RestApi.Contracts;
using RestApi.Entities;
using RestApi.Models;
using System.Collections;

namespace RestApi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repoContext) : base(repoContext) { }
        public IEnumerable<User> GetAllUser()
        {
            return All().OrderBy(i => i.username).ToList();
        }
        public User GetUserById(int Id)
        {
            return Find(u => u.id.Equals(Id)).FirstOrDefault();
        }
        public void CreateUser(User user) => Create(user);
        public void UpdateUser(User user) => Update(user);
        public void DeleteUser(User user) => Delete(user);

       
    }
}
