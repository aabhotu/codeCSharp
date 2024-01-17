using RestApi.Models;

namespace RestApi.Data
{
    public class UserDatas
    {
        public static List<User> UserList = new List<User>
        {
            new User{id=1, username="abc", password="abc", fullname="Nguyen abc", isActive=true},
            new User{id=2, username="www", password="www", fullname="Nguyen www", isActive=true},
            new User{id=3, username="ddd", password="ddd", fullname="Nguyen ddd", isActive=false},
            new User{id=4, username="ccc", password="ccc", fullname="Nguyen ccc", isActive=true},
        };

    }
}
