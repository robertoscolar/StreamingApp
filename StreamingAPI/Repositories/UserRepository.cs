using StreamingAPI.Model;

namespace StreamingAPI.Repositories
{
    public static class UserRepository
    {
        public static User Get(string email, string password)
        {
            var users = new List<User>
            {
                new User {ID = 1, Name = "Roberto", Email = "testando@123.com", Password = "123"},
                new User {ID = 1, Name = "Manuel", Email = "testando@1232.com", Password = "123"}
            };

            return users.FirstOrDefault(x => 
                x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase) && 
                x.Password == password);
        }
    }
}
