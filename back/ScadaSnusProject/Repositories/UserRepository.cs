using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.DbContext;

namespace ScadaSnusProject.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public ICollection<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User? GetUserByUsernameAndPassword(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}