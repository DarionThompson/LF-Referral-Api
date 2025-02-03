using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly List<string> _mockExistingUsers;
        public UserService()
        {
            _mockExistingUsers = new List<string> { "janedoe@nothingspecific.com", "johndoe@nothingspecific.com" };
        }
        public async Task<bool> CheckIfUserExistsAsync(string RefferedUserEmail)
        {
            return _mockExistingUsers.Contains(RefferedUserEmail);
        }
    }
}
