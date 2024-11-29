using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }


        public void CreateUser(User user)
        {
            // Kullanıcı oluşturma işlemleri
            // Örneğin, validasyon yapabilirsiniz
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Kullanıcı nesnesi null olamaz.");
            }

            _userRepository.Create(user);
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.Get(u => u.user_id == userId);
            if (user != null)
            {
                _userRepository.Delete(user);
            }
            else
            {
                throw new KeyNotFoundException("Kullanıcı bulunamadı.");
            }
        }

        public List<User> GetAllUsers()
        {
           
            return _userRepository.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new KeyNotFoundException("Bu e-posta adresine sahip kullanıcı bulunamadı.");
            }
            return user;
        }

        public object GetUserById(int id)
        {
            var user = _userRepository.Get(u => u.user_id == id);
            if (user == null)
            {
                throw new KeyNotFoundException("Bu kullanıcı bulunamadı.");
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            // Kullanıcı güncelleme işlemleri
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Kullanıcı nesnesi null olamaz.");
            }

            _userRepository.Update(user);
        }
    }
}
