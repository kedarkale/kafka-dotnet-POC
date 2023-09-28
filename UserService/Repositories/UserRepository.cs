namespace UserService.Repositories
{
    using UserService.Models;
    public class UserRepository: IUserRepository
    {
        public static List<UserModel> Users = new List<UserModel>{
            new UserModel{
                Id = 1,
                Name = "User1",
                Email = "User1@zeuslearning.com",
                OtherDetails = "NA",
            },
            new UserModel{
                Id = 2,
                Name = "User2",
                Email = "User2@zeuslearning.com",
                OtherDetails = "NA",
            },
            new UserModel{
                Id = 3,
                Name = "User3",
                Email = "User3@zeuslearning.com",
                OtherDetails = "NA",
            }
        };

        public List<UserModel> GetAllUsers()
        {
            return Users;
        }
    }
}