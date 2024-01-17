using RestApi.Models;
using System.Collections;

namespace RestApi.Contracts
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int Id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
