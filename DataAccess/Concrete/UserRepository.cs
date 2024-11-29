using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, BiletOtomasyonu>, IUserRepository
    {
        private readonly BiletOtomasyonu _context;

        public UserRepository(BiletOtomasyonu context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

       
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.email == email);
        }
    }
}