using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUserService
    {
        public Task<bool> CheckIfUserExistsAsync(string RefferedUserEmail);
    }
}
