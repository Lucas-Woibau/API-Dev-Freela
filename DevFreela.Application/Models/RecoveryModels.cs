using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Models
{
    public class PasswordRecoveryRequestInputModel
    {
        public string Email { get; set; }
    }

    public class ValidateRecoveryCodeInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class ChangePasswordInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
