using StreamingAPI.Data;
using StreamingAPI.Model;

namespace StreamingAPI.Repositories.Impl
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Email.ToLower() == email.ToLower() &&
                u.Password == password);
        }
    }
}
