namespace UserService.Repositories
{
    using UserService.Models;
    public interface IUserRepository
    {
        public List<UserModel> GetAllUsers();
    }
}