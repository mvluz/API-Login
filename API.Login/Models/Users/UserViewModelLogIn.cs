using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Login.Models.Users
{
    public class UserViewModelLogIn
    {
        public int Codigo { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
