using System;
using MiniDARMAS.Data;
using MiniDARMAS.Domain;

namespace MiniDARMAS.Business
{
    public class AuthService
    {
        private UserDao _userDao;

        public AuthService()
        {
            _userDao = new UserDao();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            return _userDao.Authenticate(username, password);
        }
    }
}
