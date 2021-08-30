using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Login.Models.Users
{
    public class UserViewModelSignIn
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string Password { get; set; }

    }
}
