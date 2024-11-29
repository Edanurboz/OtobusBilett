using Business.DTO;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface IUserService
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        object GetUserById(int id);
    }
}
