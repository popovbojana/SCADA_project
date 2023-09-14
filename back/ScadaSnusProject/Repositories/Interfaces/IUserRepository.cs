using ScadaSnusProject.Model;

namespace ScadaSnusProject.Repositories.Interfaces;

public interface IUserRepository
{
    public ICollection<User> GetAllUsers();
    public User? GetUserByUsernameAndPassword(string username, string password);
    public void AddUser(User user);
}